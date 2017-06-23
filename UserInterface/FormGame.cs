using System.Windows.Forms;

namespace UserInterface
{
    using System;
    using System.Drawing;

    public class FormGame : Form
    {
        public FormGame()
        {
            this.Text = FormStart.k_FormText;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Size = new Size(500, 683);
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
