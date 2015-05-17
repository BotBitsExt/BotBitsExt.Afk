using System;
using BotBits;
using BotBits.Permissions;
using BotBitsExt.Commands;

namespace BotBitsExt.Afk.Commands
{
    /// <summary>
    /// Afk command used to change afk state.
    /// </summary>
    public sealed class AfkCommand : Package<AfkCommand>
    {
        public AfkCommand()
        {
            InitializeFinish += delegate { CommandLoader.Of(BotBits).Load(this); };
        }

        [Command("afk", "unafk")]
        [MinGroup(Group.User)]
        private void OnCommand(ParsedCommand message)
        {
            var isAfk = message.Player.IsAfk(considerAutoAfk: false);

            if (message.Type == "unafk" || isAfk)
            {
                message.Player.SetAfk(false);
                message.Reply("You are no longer afk.");
            }
            else
            {
                message.Player.SetAfk(true);
                message.Reply("You are now afk.");
            }
        }
    }
}

