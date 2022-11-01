using SnelToetsenSjezer.Domain.Types;

namespace SnelToetsenSjezer.Domain.Models
{
    public class HotKey
    {
        public bool Failed { get; set; }
        public int Attempt { get; set; } = 1;
        public int Seconds { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public HotKeySolutions Solutions { get; set; }

        public void ResetForNewGame()
        {
            Failed = false;
            Attempt = 1;
            Seconds = 0;
        }
    }
}