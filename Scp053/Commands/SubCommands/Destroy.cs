using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;
using Exiled.Permissions.Extensions;
using Exiled.API.Features;

namespace Scp053.Commands.SubCommands
{
    class Destroy : ICommand
    {
        private const string RequiredPermission = "053.destroy";

        /// <inheritdoc/>
        public string Command { get; } = "destroy";

        /// <inheritdoc/>
        public string[] Aliases { get; } = { "kill" };

        /// <inheritdoc/>
        public string Description { get; } = "destroy all alive SCP-053.";

        /// <inheritdoc/>
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission(RequiredPermission))
            {
                response = $"Insufficient permission. Required: {RequiredPermission}";
                return false;
            }
            

            foreach(Player player in API.AllScp053) 
            {
                API.Destroy053(player);
            }

            response = "Killed all SCP-053 users successfully.";
            return false;
        }
    }
}
