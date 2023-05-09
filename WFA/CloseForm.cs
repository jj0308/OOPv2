using DAL;
using DAL.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA
{
    public partial class CloseForm : Form
    {
        public CloseForm()
        {
            SetSettings.SetCulture(Constants.GetLanguage());
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            //ovo sam stavio da mogu havatati key eveente 
            this.KeyPreview = true;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);


            if (e.KeyCode == Keys.Enter)
            {
                Application.Exit();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
