using BotBits;

namespace BotBitsExt.Afk.Events
{
    /// <summary>
    /// Occurs when player enters or leaves afk state.
    /// </summary>
    public sealed class AfkEvent : Event<AfkEvent>
    {
        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <value>The player.</value>
        public Player Player { get; private set; }

        /// <summary>
        /// Gets a value indicating whether player went afk or not.
        /// </summary>
        /// <value><c>true</c> if player went afk; otherwise, <c>false</c>.</value>
        public bool Afk { get; private set; }

        internal AfkEvent(Player player, bool afk)
        {
            Player = player;
            Afk = afk;
        }
    }
}

