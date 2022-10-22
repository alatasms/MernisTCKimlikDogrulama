using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MernisService2022;
using MernisService2022.MernisIdentityService;

namespace MernisService2022
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void btnValidate_Click(object sender, EventArgs e)
        {

            TCKimlikNoDogrulaResponse task = await Validate();
            if (task.Body.TCKimlikNoDogrulaResult)
            {
                lblResponse.Text = "Verification successful";
                lblResponse.ForeColor = Color.Green;
            }
            else
            {
                lblResponse.Text = "Verification failed";
                lblResponse.ForeColor = Color.Red;
            }
        }
        public async Task<TCKimlikNoDogrulaResponse> Validate()
        {
            long identityNumber = long.Parse(txtIdentity.Text);
            string name = txtName.Text;
            string surname = txtSurname.Text;
            int year = int.Parse(txtDate.Text);
            KPSPublicSoapClient kPSPublicSoapClient = new MernisIdentityService.KPSPublicSoapClient();
            return await kPSPublicSoapClient.TCKimlikNoDogrulaAsync(identityNumber, name, surname, year);
        }
    }
}
