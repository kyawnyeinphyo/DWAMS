using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace DWAMS
{
    public class Globalizer
    {
        public enum MessageType
        {
            Information, Warning, Error, Question
        }

        public static DialogResult ShowMessage(MessageType messageType, string message)
        {
            DialogResult result = DialogResult.None;

            switch (messageType)
            {
                case MessageType.Information:
                    MessageBox.Show(message, ConfigurationManager.AppSettings["MessageBoxTitle"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case MessageType.Warning:
                    MessageBox.Show(message, ConfigurationManager.AppSettings["MessageBoxTitle"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;

                case MessageType.Error:
                    MessageBox.Show(message, ConfigurationManager.AppSettings["MessageBoxTitle"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case MessageType.Question:
                    result = MessageBox.Show(message, ConfigurationManager.AppSettings["MessageBoxTitle"].ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    break;

            }
            return result;
        }

    }
}
