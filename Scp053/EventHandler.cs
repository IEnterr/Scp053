using System.Collections.Generic;
using System.Linq;
using Exiled.Events.EventArgs;
using Exiled.API.Features;
using MEC;

namespace Scp053
{
    public partial class EventHandler
    {
        /*
         | Server events |
        */
        public void OnRoundStart() 
        {
            if(UnityEngine.Random.Range(0,100) < Plugin.Instance.Config.SpawnChance) 
            {
                spawning = Timing.RunCoroutine(spawnCoroutine());
            }
        }
        public void OnEndingRound(EndingRoundEventArgs ev) 
        {
            if (API.AllScp053.Any())
            {
                List<Team> teams = (from player in Player.List where !API.IsScp053(player) select player.Team).ToList();

                if (teams.All(team => (team == Team.TUT) || team == Team.SCP || team == Team.RIP || team == Team.CHI)) ev.IsRoundEnded = true;
                else if (teams.All(team => (team == Team.MTF) || team == Team.RSC || team == Team.RIP)) ev.IsRoundEnded = true;
                else if (teams.All(team => team == Team.CHI || team == Team.CDP || team == Team.RIP)) ev.IsRoundEnded = true;
            }
        }

        /*
         | Player events |
        */
        public void OnDied(DiedEventArgs ev) 
        {
            if (API.IsScp053(ev.Target)) API.Destroy053(ev.Target);
        }

        public void OnHurting(HurtingEventArgs ev) 
        {
            if ((!(ev.Target.UserId == ev.Attacker.UserId) || !ev.Attacker.IsScp) && API.IsScp053(ev.Target ) ) 
            {
                //Local variables ev.Attacker and ev.Target with set option
                var attacker = Player.Get(ev.Attacker.ReferenceHub);
                var target = Player.Get(ev.Target.ReferenceHub);

                attacker.Hurt(990000, target, DamageTypes.Bleeding);
            }
        }

        public void OnLeft(LeftEventArgs ev) 
        {
            if (API.IsScp053(ev.Player)) API.Destroy053(ev.Player);
        }

        public void OnPickingUpItem(PickingUpItemEventArgs ev) 
        {
            if (API.IsScp053(ev.Player)) ev.IsAllowed = false;
        }
        public void OnEscaping(EscapingEventArgs ev) 
        {
            if (API.IsScp053(ev.Player)) ev.IsAllowed = false;
        }
        public void OnChangingRole(ChangingRoleEventArgs ev) 
        {
            if (API.IsScp053(ev.Player)) API.Destroy053(ev.Player);
        }
        public void OnEnteringPocketDimension(EnteringPocketDimensionEventArgs ev) 
        {
            if (API.IsScp053(ev.Player)) ev.IsAllowed = false;
        }
       
    }
}
