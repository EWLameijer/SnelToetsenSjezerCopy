using SnelToetsenSjezer.Domain.Interfaces;
using SnelToetsenSjezer.Domain.Models;

namespace SnelToetsenSjezer.WinForms.Forms
{
    public partial class GameOverForm : Form
    {
        public GameOverForm(IHotKeyGameService gameService)
        {
            InitializeComponent();

            List<HotKey> gameHotKeys = gameService.GetGameHotKeys();
            int gameDuration = gameService.GetGameDuration();

            NumHotKeysValue.Text = gameHotKeys.Count().ToString();
            TimeSpentValue.Text = gameDuration.ToString();

            int hotKeyCounter = 0;

            gameHotKeys.ForEach(hotKey =>
            {
                Panel detailPanel = new Panel();
                detailPanel.Size = new Size(768, 25);
                detailPanel.Location = new Point(0, 25 * hotKeyCounter);

                Label lblHotKey = new Label();
                lblHotKey.Size = new Size(430, 25);
                lblHotKey.Text = hotKey.Description;
                lblHotKey.BorderStyle = BorderStyle.FixedSingle;

                Label lblAttempts = new Label();
                lblAttempts.Size = new Size(160, 25);
                lblAttempts.Location = new Point(440, 0);
                lblAttempts.Text = hotKey.Attempt.ToString();
                lblAttempts.BorderStyle = BorderStyle.FixedSingle;

                Label lblTime = new Label();
                lblTime.Size = new Size(160, 25);
                lblTime.Location = new Point(600, 0);
                lblTime.Text = hotKey.Seconds.ToString();
                lblTime.BorderStyle = BorderStyle.FixedSingle;

                detailPanel.Controls.Add(lblHotKey);
                detailPanel.Controls.Add(lblAttempts);
                detailPanel.Controls.Add(lblTime);

                HotKeyDetailsPanel.Controls.Add(detailPanel);

                hotKeyCounter++;
            });
        }
    }
}
