using BotBits;

namespace BotBitsExt.Afk
{
    public static class PlayerExtensions
    {
        /// <summary>
        /// Determines if the specified player is afk.
        /// If considerAutoAfk is set to <c>true</c> additionaly checks if player was put
        /// in automatic afk state.
        /// </summary>
        /// <returns><c>true</c> if the specified player is afk; otherwise, <c>false</c>.</returns>
        /// <param name="player">Player.</param>
        /// <param name="considerAutoAfk">If set to <c>true</c> considers auto afk.</param>
        public static bool IsAfk(this Player player, bool considerAutoAfk = true)
        {
            if (player.Get<bool>("Afk"))
                return true;

            if (!considerAutoAfk)
                return false;

            return player.Get<bool>("AutoAfk");
        }

        /// <summary>
        /// Determines if the specifecd player is in automatic state.
        /// </summary>
        /// <returns><c>true</c> if player is afk; otherwise, <c>false</c>.</returns>
        /// <param name="player">Player.</param>
        internal static bool IsAutoAfk(this Player player)
        {
            return player.Get<bool>("AutoAfk");
        }

        /// <summary>
        /// Sets the afk state of the specifed player.
        /// </summary>
        /// <param name="player">Player.</param>
        /// <param name="afk">If set to <c>true</c> afk state is enabled.</param>
        public static void SetAfk(this Player player, bool afk)
        {
            if (player.IsAfk(false) != afk)
                player.Set("Afk", afk);
        }

        /// <summary>
        /// Sets the auto afk state of the specified player.
        /// </summary>
        /// <param name="player">Player.</param>
        /// <param name="afk">If set to <c>true</c> auto afk state is enabled.</param>
        internal static void SetAutoAfk(this Player player, bool afk)
        {
            if (player.IsAutoAfk() != afk)
                player.Set("AutoAfk", afk);
        }
    }
}

