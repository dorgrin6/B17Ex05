namespace UserInterface
{
    using System.Drawing;
    using System.Windows.Forms;

    using B17_Ex02;

    public class FormGame : Form
    {
        FormStart m_FormStart = new FormStart();

        GameLogic m_GameLogic = new GameLogic();

        public FormGame()
        {
            this.Text = FormStart.k_FormText;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Size = new Size((int)eFormSize.Width, (int)eFormSize.Height);
            this.StartPosition = FormStartPosition.CenterScreen;
            showStart();
        }

        enum eFormSize
        {
            Width = 500,

            Height = 683
        }

        private void showStart()
        {
            this.Visible = false;
            m_FormStart.ShowDialog();
        }
    }
}