using QMS.Token.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QMS.ServiceProvider.WindowsClient
{
    public partial class ServiceLogin : Form
    {
        ServiceRepo serviceRepo = new ServiceRepo();
        ClientRepo clientRepo = new ClientRepo();
        public ServiceLogin()
        {
            InitializeComponent();

        }

        private void ServiceLogin_Load(object sender, EventArgs e)
        {
            cbServices.DataSource = serviceRepo.GetAllService();
            cbServices.DisplayMember = "Name";
            cbServices.ValueMember = "Id";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (cbClientServiceBooth.SelectedValue != null)
            {
                clientRepo.ClientLogin((int)cbClientServiceBooth.SelectedValue);
                ServiceProviderTokenInfoForm serviceProviderTokenInfoForm =new ServiceProviderTokenInfoForm((int)cbClientServiceBooth.SelectedValue, cbClientServiceBooth.Text);
                serviceProviderTokenInfoForm.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Please Select a Service Booth First.");
        }

        private void cbServices_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbClientServiceBooth.DataSource = clientRepo.GetInactiveClientsByServiceId((int)cbServices.SelectedValue);
            cbClientServiceBooth.DisplayMember = "Name";
            cbClientServiceBooth.ValueMember = "Id";
        }

        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            cbClientServiceBooth.DataSource = clientRepo.GetAllClientsByServiceId((int)cbServices.SelectedValue);
        }
    }
}
