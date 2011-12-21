using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExtApi.Engine.Data;

namespace ExtApi.Tester
{
    public partial class fmParameterEditor : Form
    {
        public ApiParameter EditedParameter { get; protected set; }

        public fmParameterEditor(ApiParameter parameter)
        {
            InitializeComponent();

            // Copy the passed in parameter to the internal one
            if (parameter == null)
                EditedParameter = new ApiParameter();
            else
                EditedParameter = new ApiParameter { Name = parameter.Name, UnencodedValue = parameter.UnencodedValue };
        }

        private void fmParameterEditor_Load(object sender, EventArgs e)
        {
            txtName.Text = EditedParameter.Name;
            txtParamValue.Text = EditedParameter.UnencodedValue;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EditedParameter.Name = txtName.Text.Trim();
            EditedParameter.UnencodedValue = txtParamValue.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
