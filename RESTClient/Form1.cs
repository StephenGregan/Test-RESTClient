using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RESTClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region UI Event Handlers
        private void btnGo_Click(object sender, EventArgs e)
        {
            // Test
            // DebugOutput("Hello");

            RestClient restClient = new RestClient();
            restClient.EndPoint = txtUrl.Text;

            DebugOutput("RESTClient Client Created");

            string strResponse = string.Empty;
            strResponse = restClient.MakeRequest();

            DebugOutput(strResponse);
        }
        #endregion

        // This method/function writes out a string to a textbox.
        private void DebugOutput(string strDebugText)
        {
            try
            {
                // Writes out input string to output window in Visual Studio.
                Debug.Write(strDebugText + Environment.NewLine);
                // This line writes it out to the text response box named [txtResponse]
                txtResponse.Text = txtResponse.Text + strDebugText + Environment.NewLine;
                txtResponse.SelectionStart = txtResponse.TextLength;
                txtResponse.ScrollToCaret();
            } catch (Exception ex)
            {
                // Writes the exception to the output window.
                Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }
        }
    }
}
