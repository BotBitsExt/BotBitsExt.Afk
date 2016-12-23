using BotBits;

namespace BotBitsExt.Afk.Events
{
    /// <summary>
    /// Occurs when player enters or leaves automatic afk state.
    /// </summary>
    public sealed class AutoAfkEvent : Event<AutoAfkEvent>
    {
        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <value>The player.</value>
        public Player Player { get; private set; }

        /// <summary>
        /// Gets a value indicating whether player went auto afk or not.
        /// </summary>
        /// <value><c>true</c> if player went auto afk; otherwise, <c>false</c>.</value>
        public bool AutoAfk { get; private set; }

        internal AutoAfkEvent(Player player, bool autoAfk)
        {
            Player = player;
            AutoAfk = autoAfk;
        }
    }
}

