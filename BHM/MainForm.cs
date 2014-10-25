using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BHM.Ui;
using Dapper;
using DapperExtensions;
using System.Data.SqlClient;
using BHM.Entities;

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
            var connection = new MySql.Data.MySqlClient.MySqlConnection("server=localhost;uid=root;database=bhm;port=9999");
            try
            {
                DapperExtensions.DapperExtensions.DefaultMapper = typeof(BHM.Extensions.CustomPluralizedMapper<>);
                DapperExtensions.DapperExtensions.SqlDialect = new DapperExtensions.Sql.MySqlDialect();
                connection.Open();
                System.Diagnostics.Debug.WriteLine("Connection open!!");
                var session = new Session();
                session.Id = 0;
                session.StartAt = DateTime.Now;
                session.Status = "RUNNING";
                var email = new Email { EmailAddress = "my.test@livec.a" };
                var server = new SmtpServer { Address = "smtp.gmail.com", Port = 785, SSL = true, WaitInterval = 10 };
                var proxy = new ProxyServer { Address = "localhost", Port = 8080 };
                
                var sessionId = connection.Insert(session);
                var emailId = connection.Insert(email);
                var serverId = connection.Insert(server);
                var proxyId = connection.Insert(proxy);
                var details = new SessionDetail();
                var account = new SmtpAccount { SmtpServerId = serverId, Login = "Test", Password = "DDD", Status = "OK"};
                var accountId = connection.Insert(account);
                details.EmailId = emailId;
                details.SmtpServerId = serverId;
                details.SessionId = sessionId;
                details.ProxyServerId = proxyId;
                details.SmtpAccountId = accountId;
                details.Status = "OK";
                var id = connection.Insert(details);
                MessageBox.Show(id.toString());
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
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
