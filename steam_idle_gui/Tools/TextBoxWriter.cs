using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace steam_idle_gui
{
    public class TextBoxWriter : TextWriter
    {
        TextBox _output = null;

        public TextBoxWriter(TextBox output)
        {
            _output = output;
        }

        public static string GetTimestamp(DateTime value)
        {
            return value.ToString("[HH:mm:ss] - ");
        }

        public override void Write(char value)
        {
            base.Write(value);
            this._output.AppendText(value.ToString());
        }

        public override void WriteLine(string value)
        {
            this.Write(GetTimestamp(DateTime.Now) + value);
            this.WriteLine();
        }

        public override System.Text.Encoding Encoding
        {
            get
            {
                return System.Text.Encoding.UTF8;
            }
        }
    }
}
