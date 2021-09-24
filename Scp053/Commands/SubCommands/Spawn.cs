using System;
using CommandSystem;
using Exiled.Permissions.Extensions;
using Exiled.API.Features;
using RemoteAdmin;

namespace Scp053.Commands.SubCommands
{

    class Spawn : ICommand
    {
        private const string RequiredPermission = "053";

        /// <inheritdoc/>
        public string Command { get; } = "spawn";

        /// <inheritdoc/>
        public string[] Aliases { get; } = { "instantiate" };

        /// <inheritdoc/>
        public string Description { get; } = "spawn player as scp682.";

        /// <inheritdoc/>
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission(RequiredPermission))
            {
                response = $"Insufficient permission. Required: {RequiredPermission}";
                return false;
            }
            Player player = Player.Get((sender as PlayerCommandSender)?.ReferenceHub);
            if (API.IsScp053(player))
            {
                response = $"The player is already SCP-053!";
                return false;
            }

            API.Spawn053(player);

            response = "Spawned player as SCP-053 successfully";
            return false;
        }
    }
}

