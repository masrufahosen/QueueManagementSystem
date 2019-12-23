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
    public partial class ServiceProviderTokenInfoForm : Form
    {
        private int clientId;
        private string clientName;
        ClientRepo _clientRepo;
        TokenRepo tokenRepo;
        int previousTokenId;
        public ServiceProviderTokenInfoForm(int _clientID,string _clientName)
        {
            InitializeComponent();
            clientName = _clientName;
            clientId = _clientID;
            this.Text = "Client Service Form:"+_clientName;
            _clientRepo = new ClientRepo();
            tokenRepo = new TokenRepo();
            this.FormClosing += ServiceProviderTokenInfoForm_FormClosing;
        }

        private void ServiceProviderTokenInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (previousTokenId > 0)
            {
                tokenRepo.ServiceProvidedToToken(previousTokenId);
            }
            _clientRepo.ClientLogout(clientId);
            Application.Exit();
        }

        private void ServiceProviderTokenInfoForm_Load(object sender, EventArgs e)
        {
            gvWaitingToken.DataSource = tokenRepo.GetTodaysWaitingTokenbyClient(clientId);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            CallNext();
        }
        private void CallNext()
        {
            var dataTable = tokenRepo.GetTodaysNextTokenbyClientId(clientId);
            if (previousTokenId > 0)
            {
                tokenRepo.ServiceProvidedToToken(previousTokenId);
            }
            if (dataTable.Rows.Count > 0)
            {
                var serviceName = dataTable.Rows[0]["Name"].ToString();
                var TokenNumber = dataTable.Rows[0]["TokenNumber"].ToString();
                var tokenId = (int)dataTable.Rows[0]["Id"];
                if (TokenNumber.Length == 1)
                {
                    lblTokenNumber.Text = serviceName[0].ToString() + TokenNumber.PadLeft(2, '0');
                }
                else
                {
                    lblTokenNumber.Text = serviceName[0].ToString() + TokenNumber;
                }
                tokenRepo.UpdateTokenCalledStatus(tokenId);
                previousTokenId = tokenId;
                gvWaitingToken.DataSource = tokenRepo.GetTodaysWaitingTokenbyClient(clientId);
            }
            else
            {
                MessageBox.Show("There are no more token. Please wait and try again");
            }
        }
        private void btnPass_Click(object sender, EventArgs e)
        {
            var dataTable = tokenRepo.GetTodaysNextTokenbyClientId(clientId);
            if (previousTokenId > 0)
            {
                tokenRepo.UpdateTokenCalledStatusToPassed(previousTokenId);
            }
            if (dataTable.Rows.Count > 0)
            {
                var serviceName = dataTable.Rows[0]["Name"].ToString();
                var TokenNumber = dataTable.Rows[0]["TokenNumber"].ToString();
                var tokenId = (int)dataTable.Rows[0]["Id"];
                if (TokenNumber.Length == 1)
                {
                    lblTokenNumber.Text = serviceName[0].ToString() + TokenNumber.PadLeft(2, '0');
                }
                else
                {
                    lblTokenNumber.Text = serviceName[0].ToString() + TokenNumber;
                }
                tokenRepo.UpdateTokenCalledStatus(tokenId);
                previousTokenId = tokenId;
                gvWaitingToken.DataSource = tokenRepo.GetTodaysWaitingTokenbyClient(clientId);
            }
            else
            {
                MessageBox.Show("There are no more token. Please wait and try again");
            }
            
        }

        private void btnRefreshGrid_Click(object sender, EventArgs e)
        {
            gvWaitingToken.DataSource = tokenRepo.GetTodaysWaitingTokenbyClient(clientId);
        }
    }
}
