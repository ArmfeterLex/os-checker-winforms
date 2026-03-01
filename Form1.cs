using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsFormsAppOS
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            RoundButton(butCheckOS, 15);
            RoundButton(button1, 15);
            OperatingSystem os = Environment.OSVersion;
            listBox1.Items.Add(os.Version);
            listBox1.Items.Add(os.Platform);
            listBox1.Items.Add(os.ServicePack);
            listBox1.Items.Add(os.VersionString);
        }

        private void RoundButton(Button button, int radius)
        {
            Rectangle rect = new Rectangle(0, 0, button.Width, button.Height);
            button.Region = new Region(CreateRoundedRectanglePath(rect, radius));
        }

        private GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            radius = Math.Min(radius, Math.Min(rect.Width / 2, rect.Height / 2));
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void CheckOSVersion()
        {
            OperatingSystem os = Environment.OSVersion;
            Version version = os.Version;
            if ((version.Major == 5 && version.Minor == 1) || version.Major >= 6)
            {
                MessageBox.Show("Программа может запускаться" + " в вашей операционной системе");
            }
            else
            {
                MessageBox.Show("Эта версия операционной системы не поддерживается." + "\r\n Используйте Windows XP или Windows Vista");
            }
        }

        private void butCheckOS_Click(object sender, EventArgs e)
        {
            CheckOSVersion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}