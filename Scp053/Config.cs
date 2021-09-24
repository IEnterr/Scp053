using Exiled.API.Interfaces;
using System.ComponentModel;

namespace Scp053
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public string SpawnMessage { get; set; } = "You are SCP-053!";
        public bool UseHints { get; set; } = true;

        public string GlobalMessage { get; set; } = "The <color=red>SCP-053</color> has spawned this round!";
        public int GlobalMessageDuration { get; set; } = 6;
        public int SpawnChance { get; set; } = 12;

        [Description("The time before bypass will enabled (-1 to disable, 0 to activate bypass when spawn)")]
        public float EnableBypassTime { get; set; } = 300;
        
    }
}
