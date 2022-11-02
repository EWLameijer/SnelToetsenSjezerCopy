using System.Diagnostics;
using SnelToetsenSjezer.Business;

namespace SnelToetsenSjezer.WinForms.Forms;

public partial class GameForm : Form
{
    public static HotKeyGameService? MyHotKeyGameService = null;

    public GameForm(HotKeyGameService gameService)
    {
        InitializeComponent();

        MyHotKeyGameService = gameService;
        MyHotKeyGameService.SetGameStateUpdatedCallback(UpdateForm);
        MyHotKeyGameService.SetGameTimerCallback(UpdateTimer);

        MyHotKeyGameService.StartGame();
    }

    public void UpdateTimer(int seconds, bool paused)
    {
        TimeSpan time = TimeSpan.FromSeconds(seconds);
        lbl_timer.Text = time.ToString((seconds > 3600) ? @"hh\:mm\:ss" : @"mm\:ss");
        lbl_timer.ForeColor = paused ? Color.Gray : Color.Black;
    }

    public void UpdateForm(string basicState, Dictionary<string, string> stateDetails)
    {
        switch (basicState)
        {
            case "playing":
                string hotKeyText = $"Hotkey {stateDetails["index"]} of {stateDetails["count"]}";
                if (stateDetails.ContainsKey("attempt"))
                {
                    hotKeyText += (Int32.Parse(stateDetails["attempt"]) > 1) ? $"(Attempt #{stateDetails["attempt"]})" : "";
                }
                lbl_currhotkey.Text = hotKeyText;
                lbl_category_val.Text = stateDetails["category"];
                lbl_description_val.Text = stateDetails["description"];
                break;

            case "correct":
                lbl_description_val.Text = "Correct!\nGet ready for the next question!";
                break;

            case "failed":
                lbl_description_val.Text = "Failed!\n" +
                    "The correct answer is: " + stateDetails["solution"];
                break;

            case "finished":
                lbl_description_val.Text = "Finished!!!\n(should jump to gameover screen/form)";

                Form myGameOverForm = new GameOverForm(MyHotKeyGameService!);
                myGameOverForm.Show();
                this.Close();
                break;
        }
        if (stateDetails.ContainsKey("userinputsteps"))
        {
            lbl_userinputsteps_val.Text = stateDetails["userinputsteps"];
        }
    }

    public void GameForm_KeyDown(object sender, KeyEventArgs e)
    {
        MyHotKeyGameService!.KeyDown(e.KeyCode.ToString());
    }

    public void GameForm_KeyUp(object sender, KeyEventArgs e)
    {
        MyHotKeyGameService!.KeyUp(e.KeyCode.ToString());
    }

    public void GameForm_FormClosing(Object sender, FormClosingEventArgs e)
    {
        // below is a workaround for 'e.CloseReason == CloseReason.UserClosing' not working as advertised..
        bool closedByCode = new StackTrace().GetFrames().Any(x => x.GetMethod().Name == "Close");

        if (!closedByCode)
        {
            Debug.WriteLine("User closed GameForm! force-stopping the game!");
            MyHotKeyGameService!.StopGame(true);
        }
    }
}