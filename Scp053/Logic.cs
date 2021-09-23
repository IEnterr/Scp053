using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using MEC;

namespace Scp053
{
    public partial class EventHandler
    {
        private CoroutineHandle spawning;
        private System.Random rnd = new System.Random();
        public IEnumerator<float> spawnCoroutine() 
        {
            yield return Timing.WaitForSeconds(1);

            var classDList = Player.Get(RoleType.ClassD).ToList();

            Player classD = classDList[rnd.Next(classDList.Count)];

            API.Spawn053(classD);
            Timing.KillCoroutines(spawning);
        }
        
    }
}
