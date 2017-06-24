using System.Windows.Forms;

namespace UserInterface
{
    using System;
    using System.Drawing;

    using B17_Ex02;

    public class FormGame : Form
    {
        GameLogic m_GameLogic = new GameLogic();

        FormStart m_FormStart = new FormStart();

        enum eFormSize
        {
            Width = 500,
            Height = 683
        }
        
        public FormGame()
        {
            this.Text = FormStart.k_FormText;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Size = new Size((int) eFormSize.Height, (int) eFormSize.Width);
            this.StartPosition = FormStartPosition.CenterScreen;
            showStart();
        }

        private void showStart()
        {
            this.Visible = false;
            m_FormStart.ShowDialog();
        }
    }
}
