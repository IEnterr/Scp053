using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;

namespace Scp053
{
    public class Plugin : Plugin<Config>
    {
        private readonly static Lazy<Plugin> LazyInstance = new Lazy<Plugin>(() => new Plugin());
        public static Plugin Instance => LazyInstance.Value;

        public override string Name => "Scp053";
        public override string Author => "Enterr";
        public override Version Version => new Version(1,0,0);
        public override Version RequiredExiledVersion => new Version(3,0,0);
        public override void OnEnabled()
        {
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            base.OnDisabled();
        }
        public override void OnReloaded(){ }
    }
}
