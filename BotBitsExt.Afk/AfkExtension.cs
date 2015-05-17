using BotBits;

namespace BotBitsExt.Afk
{
    public sealed class AfkExtension : Extension<AfkExtension>
    {
        public static void LoadInto(BotBitsClient client)
        {
            LoadInto(client, null);
        }
    }
}

