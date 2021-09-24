using System;
using Exiled.API.Features;
using PlayerHandler = Exiled.Events.Handlers.Player;
using ServerHandler = Exiled.Events.Handlers.Server;
using Scp106Handler = Exiled.Events.Handlers.Scp106;

namespace Scp053
{
    public class Plugin : Plugin<Config>
    {
        private readonly static Lazy<Plugin> LazyInstance = new Lazy<Plugin>(() => new Plugin());
        public static Plugin Instance => LazyInstance.Value;

        private EventHandler handler;
        public override string Name => "Scp053";
        public override string Author => "Enterr";
        public override Version Version => new Version(0,1,0);
        public override Version RequiredExiledVersion => new Version(3,0,0);
        public override void OnEnabled()
        {
            RegisterEvents();
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            UnregisterEvents();
            base.OnDisabled();
        }
        
        public override void OnReloaded(){ }

        public void RegisterEvents() 
        {
            handler = new EventHandler();

            PlayerHandler.Left += handler.OnLeft;
            PlayerHandler.Hurting += handler.OnHurting;
            PlayerHandler.EnteringPocketDimension += handler.OnEnteringPocketDimension;
            PlayerHandler.Died += handler.OnDied;
            PlayerHandler.ChangingRole += handler.OnChangingRole;
            PlayerHandler.Escaping += handler.OnEscaping;

            ServerHandler.EndingRound += handler.OnEndingRound;
            ServerHandler.RoundStarted += handler.OnRoundStart;
        }
        public void UnregisterEvents() 
        {
            PlayerHandler.Left -= handler.OnLeft;
            PlayerHandler.Hurting -= handler.OnHurting;
            PlayerHandler.EnteringPocketDimension -= handler.OnEnteringPocketDimension;
            PlayerHandler.Died -= handler.OnDied;
            PlayerHandler.ChangingRole -= handler.OnChangingRole;
            PlayerHandler.Escaping -= handler.OnEscaping;

            ServerHandler.EndingRound -= handler.OnEndingRound;
            ServerHandler.RoundStarted -= handler.OnRoundStart;

            handler = null;
        }
    }
}
