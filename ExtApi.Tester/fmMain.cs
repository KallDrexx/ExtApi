using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExtApi.Engine.Data;
using ExtApi.Engine;
using System.IO;
using ExtApi.Tester.Properties;

namespace ExtApi.Tester
{
    public partial class fmMain : Form
    {
        public fmMain()
        {
            InitializeComponent();
        }

        private void fmMain_Load(object sender, EventArgs e)
        {
            var settings = Settings.Default.ExtApiSettings;
            if (settings != null)
            {
                txtAccessToken.Text = settings.LastOAuthAccessToken;
                txtApiUrl.Text = settings.LastApiUrl;
                txtConsumerKey.Text = settings.LastOAuthConsumerKey;
                txtConsumerSecret.Text = settings.LastOAuthConsumerSecret;
                txtTokenSecret.Text = settings.LastOAuthTokenSecret;

                if (settings.Parameters != null)
                    foreach (var param in settings.Parameters)
                        lstParameters.Items.Add(param);
            }
        }

        private void btnAddParameter_Click(object sender, EventArgs e)
        {
            var editor = new fmParameterEditor(new ApiParameter());
            if (editor.ShowDialog() == DialogResult.OK)
                lstParameters.Items.Add(editor.EditedParameter);
        }

        private void btnEditParam_Click(object sender, EventArgs e)
        {
            if (lstParameters.SelectedItem == null)
                return;

            var editor = new fmParameterEditor((ApiParameter)lstParameters.SelectedItem);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                int index = lstParameters.SelectedIndex;
                lstParameters.Items[index] = editor.EditedParameter;
            }
        }

        private void btnRemoveParameter_Click(object sender, EventArgs e)
        {
            if (lstParameters.SelectedItem == null)
                return;

            lstParameters.Items.Remove(lstParameters.SelectedItem);
        }

        private void chkIncludeOAuth_CheckedChanged(object sender, EventArgs e)
        {
            txtConsumerKey.Enabled = chkIncludeOAuth.Checked;
            txtConsumerSecret.Enabled = chkIncludeOAuth.Checked;
            txtAccessToken.Enabled = chkIncludeOAuth.Checked;
            txtTokenSecret.Enabled = chkIncludeOAuth.Checked;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            // Reset the GUI
            lblStatusCode.Text = string.Empty;
            txtResults.Text = string.Empty;
            txtBuiltUrl.Text = string.Empty;

            // Create parameter list
            var paramList = new List<ApiParameter>();
            foreach (var item in lstParameters.Items)
                if (item is ApiParameter)
                    paramList.Add((ApiParameter)item);

            // Save used values for automatic population next time
            if (Settings.Default.ExtApiSettings == null)
                Settings.Default.ExtApiSettings = new ExtApiSettings();

            var settings = Settings.Default.ExtApiSettings;
            settings.LastApiUrl = txtApiUrl.Text;
            settings.LastOAuthAccessToken = txtAccessToken.Text;
            settings.LastOAuthConsumerKey = txtConsumerKey.Text;
            settings.LastOAuthConsumerSecret = txtConsumerSecret.Text;
            settings.LastOAuthTokenSecret = txtTokenSecret.Text;
            settings.Parameters = paramList;
            Settings.Default.Save();

            ExtApiCallResult result = null;
            var apiRunner = new ApiRunner();

            if (chkIncludeOAuth.Checked)
            {
                // Create the token manager
                var tokenManager = new InMemoryTokenManager();
                tokenManager.ConsumerKey = txtConsumerKey.Text;
                tokenManager.ConsumerSecret = txtConsumerSecret.Text;
                tokenManager.AddKeyAndSecret(txtAccessToken.Text, txtTokenSecret.Text);

                // Call the api
                apiRunner.OAuthTokenManager = tokenManager;

                try { result = apiRunner.ExecuteOAuthApiCall(txtApiUrl.Text, paramList, txtAccessToken.Text); }
                catch (UriFormatException ex)
                {
                    HandleApiCallException(ex);
                    return;
                }
            }

            else
            {
                try { result = apiRunner.ExecuteApiCall(txtApiUrl.Text, paramList); }
                catch (UriFormatException ex)
                {
                    HandleApiCallException(ex);
                    return;
                }
            }

            // Show the results
            lblStatusCode.Text = result.StatusCode.ToString();
            txtBuiltUrl.Text = result.FinalUrl;

            if (result.XmlResponse != null)
                txtResults.Text = result.XmlResponse.ToString();
            else
                // Assume it's JSON since it's not XML
                txtResults.Text = JsonFormatter.PrettyPrint(new StreamReader(result.ResponseStream).ReadToEnd());
        }

        private void HandleApiCallException(Exception ex)
        {
            MessageBox.Show(
                string.Format("An exception occurred while executing the api call {0}{0}{1}:{0}{2}",
                    Environment.NewLine,
                    ex.GetType().ToString(),
                    ex.Message),
                "Error Performing Api Call");
        }
    }
}
