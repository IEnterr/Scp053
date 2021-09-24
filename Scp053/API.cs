using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using Mirror;
using Exiled.API.Extensions;
using UnityEngine;

namespace Scp053
{
    public static class API
    {
        public static bool IsScp053(Player player) => player.SessionVariables.ContainsKey("IsScp053");

        //To detect is there SCP-053 in round
        public static IEnumerable<Player> AllScp053 => Player.List.Where(IsScp053);
        public static void Spawn053(Player player) 
        {
            //Dont do anything when player already spawned as Scp053
            if (IsScp053(player)) return;
            player.SessionVariables.Add("IsScp053", null);
            Scp096.TurnedPlayers.Add(player);
            Scp173.TurnedPlayers.Add(player);
            player.SetRole(RoleType.ClassD);
            SpawnPlayer(player, 0.5f, 0.5f);
            string roleName = string.Empty;

            roleName += "";

            roleName += $"<color=orange>{player.Nickname}\nSCP-053</color>";

            player.CustomInfo = roleName;
            player.ReferenceHub.nicknameSync.ShownPlayerInfo &= ~PlayerInfoArea.Nickname;
            player.ReferenceHub.nicknameSync.ShownPlayerInfo &= ~PlayerInfoArea.Role;
            

            Map.Broadcast((ushort)Plugin.Instance.Config.GlobalMessageDuration, Plugin.Instance.Config.GlobalMessage);
            Cassie.Message("attention . detected scp 0 5 3 in light containment zone");
            if (Plugin.Instance.Config.UseHints) player.ShowHint(Plugin.Instance.Config.SpawnMessage, 8);
            else player.Broadcast(8, Plugin.Instance.Config.SpawnMessage);
        }
        public static void Destroy053(Player player)
        {
            //Dont do anything when player don`t spawned as Scp053
            if (!IsScp053(player)) return;
            
            player.SessionVariables.Remove("IsScp053");
            Scp096.TurnedPlayers.Remove(player);
            Scp173.TurnedPlayers.Remove(player);
            player.CustomInfo = string.Empty;
            player.ReferenceHub.nicknameSync.ShownPlayerInfo |= PlayerInfoArea.Nickname;
            player.ReferenceHub.nicknameSync.ShownPlayerInfo |= PlayerInfoArea.Role;
            SpawnPlayer(player, 1, 1);
            Cassie.Message("SCP 0 5 3 terminatedsuccesfully . . termination cause unspecified");
        }

        public static void SpawnPlayer(Player ply, float Scale1, float Scale2)
        {
            try
            {
                NetworkIdentity identity = ply.GameObject.GetComponent<NetworkIdentity>();
                ply.GameObject.transform.localScale = new Vector3(1 * Scale2, 1 * Scale1, 1 * Scale2);

                ObjectDestroyMessage destroyMessage = new ObjectDestroyMessage();
                destroyMessage.netId = identity.netId;

                foreach (GameObject player in PlayerManager.players)
                {
                    NetworkConnection playerCon = player.GetComponent<NetworkIdentity>().connectionToClient;
                    if (player != ply.GameObject)
                        playerCon.Send(destroyMessage, 0);

                    object[] parameters = new object[] { identity, playerCon };
                    typeof(NetworkServer).InvokeStaticMethod("SendSpawnMessage", parameters);
                }
            }
            catch (Exception e)
            {
                Log.Info($"Set Scale error: {e}");
            }
        }

    }
}
