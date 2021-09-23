using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;

namespace Scp053
{
    public static class API
    {
        public static bool IsScp053(Player player) => player.SessionVariables.ContainsKey("IsScp053");

        public static void Spawn053(Player player) 
        {
            //Dont do anything when player already spawned as Scp053
            if (IsScp053(player)) return;
            player.SessionVariables.Add("IsScp053", null);
            string roleName = string.Empty;

            roleName += "";

            roleName += $"<color=orange>{player.Nickname}\nSCP-053</color>";

            player.CustomInfo = roleName;
            player.ReferenceHub.nicknameSync.ShownPlayerInfo &= ~PlayerInfoArea.Nickname;
            player.ReferenceHub.nicknameSync.ShownPlayerInfo &= ~PlayerInfoArea.Role;
            player.SetRole(RoleType.ClassD);

            Map.Broadcast((ushort)Plugin.Instance.Config.GlobalMessageDuration, Plugin.Instance.Config.GlobalMessage);
            Cassie.Message("attention . detected scp 0 5 3 in light containment zone");
            if (Plugin.Instance.Config.UseHints) player.ShowHint(Plugin.Instance.Config.SpawnMessage, 8);
            else player.Broadcast(8, Plugin.Instance.Config.SpawnMessage);
        }
        public static void Destroy053(Player player)
        {
            //Dont do anything when player don`t spawned as Scp053
            if (IsScp053(player)) return;
            
            player.SessionVariables.Remove("IsScp053");

            player.CustomInfo = string.Empty;
            player.ReferenceHub.nicknameSync.ShownPlayerInfo |= PlayerInfoArea.Nickname;
            player.ReferenceHub.nicknameSync.ShownPlayerInfo |= PlayerInfoArea.Role;

            Cassie.Message("SCP 0 5 3 terminatedsuccesfully . . termination cause unspecified");
        }
        
    }
}
