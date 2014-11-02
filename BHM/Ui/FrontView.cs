using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BHM.Factory;

namespace BHM.Ui
{    
    public partial class FrontView : UserControl
    {
        private readonly BindingList<String> _logList = new BindingList<String>();
        private readonly SendFactory _sendFactory = new SendFactory();
        private ISendMethod _sendMethod;
        private readonly ListBox _listBox = new ListBox();
        public FrontView()
        {
            InitializeComponent();
            InitListBox();
        }

        private void InitListBox()
        {
            _listBox.Dock = DockStyle.Fill;            
            _listBox.Name = Guid.NewGuid().ToString();
            Controls.Add(_listBox);
            _listBox.DataSource = _logList;
            Controls[_listBox.Name].BringToFront();
        }

        private delegate void TestDelegate(String log, ListBox listBox);

        private void Log(String message, ListBox listBox)
        {
            if (listBox.InvokeRequired)
            {
                listBox.Invoke(new TestDelegate(Log), new object[] {message, listBox});
            }
            else
            {
                _logList.Add(message);
                listBox.TopIndex = listBox.Items.Count - 1;
            }
        }

        private void PnlBodyPaint(object sender, PaintEventArgs e)
        {
            
        }

        private bool _started = false;

        private void TlStrpBtnStartClick(object sender, EventArgs e)
        {
            if (_started)
            {
                _sendMethod.Stop();
                tlStrpBtnStart.Image = Properties.Resources.Play;
                return;
            }
            _sendMethod = _sendFactory.Create(new BHM.Options());
            _sendMethod.OnMessage += (obj, message) => Log(message, _listBox);
            _sendMethod.Send();
            _started = true;
            tlStrpBtnStart.Image = Properties.Resources.Stop;
        }
    }

}