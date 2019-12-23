using System;
using System.Data;
using System.Speech.Synthesis;
using System.Windows.Forms;
using QMS.Token.Repo;
namespace QMS.Token.Generate
{
    public partial class ServiceHomeForm : Form
    {
        int counter = 0;
        ServiceRepo _serviceRepo;
        ClientRepo clientRepo;
        TokenRepo _tokenRepo;
        int previousTokenId;
        public ServiceHomeForm()
        {
            InitializeComponent();
            btnGenerateToken.Click += BtnRegistrationService_Click;
            this.Load += ServiceHomeForm_Load;
            _serviceRepo = new ServiceRepo();
            clientRepo = new ClientRepo();
            _tokenRepo = new TokenRepo();
            gvRunningTokens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            gvUpcommingTokens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void ServiceHomeForm_Load(object sender, EventArgs e)
        {
            cbServices.Enabled = false;
            var services = _serviceRepo.GetAllService();
            cbServices.DataSource = services;
            cbServices.DisplayMember = "Name";
            cbServices.ValueMember = "Id";
            cbServices.Enabled = true;
            Timer timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            
            var dataTable = _tokenRepo.GetTodaysNextToken();
            var runningTokens = _tokenRepo.GetTodaysTokensByServiceProvidedStatusAndCalledStatus(0, 1);
            var upcommingTokens = _tokenRepo.GetTodaysTokensByServiceProvidedStatusAndCalledStatus(0, 0);
            gvRunningTokens.DataSource = runningTokens;
            gvUpcommingTokens.DataSource = upcommingTokens;
            if (dataTable.Rows.Count > 0)
            {
                var serviceName = dataTable.Rows[0]["Name"].ToString();
                var TokenNumber = dataTable.Rows[0]["TokenNumber"].ToString();
                var tokenId = (int)dataTable.Rows[0]["Id"];
                if (previousTokenId == tokenId)
                {
                    counter++;
                }
                else
                {
                    counter = 0;
                    previousTokenId = tokenId;
                }
                
                if (TokenNumber.Length == 1)
                {
                    lblCurrentTokenNumber.Text = serviceName[0].ToString() + TokenNumber.PadLeft(2, '0');
                }
                else
                {
                    lblCurrentTokenNumber.Text = serviceName[0].ToString() + TokenNumber;
                }
                if (counter < 3)
                {
                    using (var speechSynthesizer = new SpeechSynthesizer())
                    {
                        speechSynthesizer.SetOutputToDefaultAudioDevice();
                        speechSynthesizer.Speak("Current Token Number is " + lblCurrentTokenNumber.Text);
                    }
                }
            }
        }

        private void BtnRegistrationService_Click(object sender, EventArgs e)
        {
            if(sender is Button)
            {
                var btnSender = (Button)sender;
                DataTable dataTable =_tokenRepo.GetLastTokenForToday();
                if (dataTable.Rows.Count > 0)
                {
                    int tnumber = (int)dataTable.Rows[0]["TokenNumber"];
                    tnumber++;
                    bool isInserted = _tokenRepo.InsertToken(tnumber, (int)cbServices.SelectedValue, (int)cbClientServiceBooth.SelectedValue);
                    if (isInserted)
                    {
                        lblTokenNumber.Text = cbServices.Text[0].ToString() + tnumber;
                    }
                    
                }
                else
                {
                    bool isInserted = _tokenRepo.InsertToken(1, (int)cbServices.SelectedValue, (int)cbClientServiceBooth.SelectedValue);
                    if (isInserted)
                    {
                        //MessageBox.Show("Token Created");
                        lblTokenNumber.Text = cbServices.Text[0].ToString() + 1;
                    }
                }
                
            }
            
        }

        private void cbServices_SelectedChangedCommitted(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            
            cbClientServiceBooth.Enabled = false;
            if (cbServices.Items.Count > 0)
            {
                int selectedServiceId = (int)comboBox.SelectedValue;
                cbClientServiceBooth.DataSource = clientRepo.GetActiveClientsByServiceId(selectedServiceId);
                cbClientServiceBooth.DisplayMember = "Name";
                cbClientServiceBooth.ValueMember = "Id";
                cbClientServiceBooth.Enabled = true;
            }
        }
    }
}
