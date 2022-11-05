using SnelToetsenSjezer.Business;
using SnelToetsenSjezer.Domain.Models;

namespace SnelToetsenSjezer.WinForms.Forms;

public partial class GameOverForm : Form
{
    public GameOverForm(HotKeyGameService gameService)
    {
        InitializeComponent();

        List<HotKey> gameHotKeys = gameService.GetGameHotKeys();
        double gameDuration = gameService.GetGameDuration();

        NumHotKeysValue.Text = gameHotKeys.Count.ToString();
        TimeSpentValue.Text = (gameDuration / 1000).ToString() + " s";

        int hotKeyCounter = 0;

        gameHotKeys.ForEach(hotKey =>
        {
            Panel detailPanel = new()
            {
                Size = new Size(768, 25),
                Location = new Point(0, 25 * hotKeyCounter)
            };

            Label lblHotKey = new()
            {
                Size = new Size(430, 25),
                Text = hotKey.Description,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblAttempts = new()
            {
                Size = new Size(160, 25),
                Location = new Point(440, 0),
                Text = hotKey.Attempt.ToString(),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblTime = new();
            lblTime.Size = new Size(160, 25);
            lblTime.Location = new Point(600, 0);
            lblTime.Text = (hotKey.MilliSeconds / 1000).ToString() + " s";
            lblTime.BorderStyle = BorderStyle.FixedSingle;

            detailPanel.Controls.Add(lblHotKey);
            detailPanel.Controls.Add(lblAttempts);
            detailPanel.Controls.Add(lblTime);

            HotKeyDetailsPanel.Controls.Add(detailPanel);

            hotKeyCounter++;
        });
    }
}