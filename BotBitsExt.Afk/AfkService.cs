using System;
using System.Collections.Generic;
using System.Linq;
using BotBits;
using BotBits.Events;
using BotBitsExt.Afk.Events;

namespace BotBitsExt.Afk
{
    public sealed class AfkService : EventListenerPackage<AfkService>
    {
        [EventListener]
        private void OnJoin(JoinEvent e)
        {
            e.Player.SetAutoAfk(true);

            e.Player.MetadataChanged += (sender, args) =>
                {
                    if (args.Key == "Afk")
                    {
                        new AfkEvent(e.Player, (bool)args.NewValue)
                            .RaiseIn(BotBits);
                    }
                    else if (args.Key == "AutoAfk")
                    {
                        new AutoAfkEvent(e.Player, (bool)args.NewValue)
                            .RaiseIn(BotBits);
                    }
                };
        }

        [EventListener]
        private void OnMove(MoveEvent e)
        {
            if (e.Player.IsAutoAfk())
                e.Player.SetAutoAfk(false);
        }

        [EventListener]
        private void OnFly(FlyEvent e)
        {
            if (e.Player.IsAutoAfk())
                e.Player.SetAutoAfk(false);
        }

        /// <summary>
        /// Resets the auto afk state enabling it for each player.
        /// </summary>
        public void ResetAutoAfk()
        {
            var players = Players.Of(BotBits).GetPlayers();
            foreach (var player in players)
            {
                if (!player.IsAutoAfk())
                {
                    player.SetAutoAfk(true);
                }
            }
        }

        /// <summary>
        /// Gets the afk players.
        /// </summary>
        /// <value>The afk players.</value>
        public List<Player> AfkPlayers
        {
            get
            {
                return Players.Of(BotBits).GetPlayers()
                    .Where(player => player.IsAfk())
                    .ToList();
            }
        }

        /// <summary>
        /// Gets the non afk players.
        /// </summary>
        /// <value>The non afk players.</value>
        public List<Player> NonAfkPlayers
        {
            get
            {
                return Players.Of(BotBits).GetPlayers()
                    .Where(player => !player.IsAfk())
                    .ToList();
            }
        }
    }
}

