using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemoteAdmin;
using CommandSystem;
using NorthwoodLib.Pools;
using Scp053.Commands.SubCommands;

namespace Scp053.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class Parent : ParentCommand
    {
        public Parent() => LoadGeneratedCommands();

        public override string Command { get; } = "053";

        public override string[] Aliases { get; } = Array.Empty<string>();

        public override string Description { get; } = "Parent command for SCP-053";
        public sealed override void LoadGeneratedCommands()
        {
            RegisterCommand(new Destroy());
            RegisterCommand(new Spawn());
        }
        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            StringBuilder stringBuilder = StringBuilderPool.Shared.Rent();
            stringBuilder.AppendLine("Please enter a valid subcommand! Available:");
            foreach (ICommand command in AllCommands)
            {
                stringBuilder.AppendLine(command.Aliases.Length > 0
                    ? $"{command.Command} | Aliases: {string.Join(", ", command.Aliases)}"
                    : command.Command);
            }

            response = StringBuilderPool.Shared.ToStringReturn(stringBuilder).TrimEnd();
            return false;
        }

    }
}
