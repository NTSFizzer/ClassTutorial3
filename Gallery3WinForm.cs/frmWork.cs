using Gallery3WinForm;
using Gallery3WinForm.ServiceReference1;
using System;
using System.Windows.Forms;

namespace Gallery3Winform
{
    public partial class frmWork : Form
    {
        protected clsWork _Work;

        public frmWork()
        {
            InitializeComponent();
        }

        public void SetDetails(clsWork prWork)
        {
            _Work = prWork;
            updateForm();
            ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (isValid())
                {
                    pushData();
                    if (txtName.Enabled)
                        Program.SvcClient.InsertWork(_Work);
                    else
                        Program.SvcClient.UpdateWork(_Work);
                    Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "Try again?");
            }
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected virtual bool isValid()
        {
            return true;
        }

        protected virtual void updateForm()
        {
            txtName.Text = _Work.Name;
            txtCreation.Text = _Work.Date.ToShortDateString();
            txtValue.Text = _Work.Value.ToString();
            txtName.Enabled = string.IsNullOrEmpty(_Work.Name);  //prevent editing artist works names - eg the sculpture name
        }

        protected virtual void pushData()
        {
            _Work.Name = txtName.Text;
            _Work.Date = DateTime.Parse(txtCreation.Text);
            _Work.Value = decimal.Parse(txtValue.Text);
        }
    }
}