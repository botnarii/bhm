using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BHM.Database;
using BHM.Ui;
using Dapper;
using BHM.Entities;
using DapperExtensions;

namespace BHM
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            using (var connection = Connection.Instance.GetMySqlConnection())
            {
                System.Diagnostics.Debug.WriteLine("Connection open!!");
                var session = new Session();
                session.Id = 0;
                session.StartAt = DateTime.Now;
                session.Status = (int) SessionStatus.Running;
                var email = new Email { EmailAddress = Guid.NewGuid()+"@livec.a" };
                var server = new SmtpServer { Address = Guid.NewGuid() + ".smtp.gmail.com", Port = 785, SSL = true, WaitInterval = 10 };
                var proxy = new ProxyServer { Address = "localhost", Port = 8080 };

                var sessionId = connection.Insert(session);
                var emailId = connection.Insert(email);
                var serverId = connection.Insert(server);
                var proxyId = connection.Insert(proxy);
                var details = new SessionDetail();
                var account = new SmtpAccount
                {
                    SmtpServerId = serverId,
                    Login = Guid.NewGuid().ToString(),
                    Password = "DDD",
                    Status = (int) AccountStatus.Ok
                };
                var accountId = connection.Insert(account);
                details.EmailId = emailId;
                details.SmtpServerId = serverId;
                details.SessionId = sessionId;
                details.ProxyServerId = proxyId;
                details.SmtpAccountId = accountId;
                details.Status = (int) SentStatus.Ok;
                var id = connection.Insert(details);
                MessageBox.Show(string.Format("{0}",id));
            }           
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            var front = new FrontView {Dock = DockStyle.Fill};
            Controls.Add(front);
            Controls[front.Name].BringToFront();
        }
    }
}
