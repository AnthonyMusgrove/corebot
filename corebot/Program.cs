namespace corebot
{

    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("corebot loading ...");

            Console.Write("loading bot configuration [corebot.conf] ... ");
            BotConfig _config = new BotConfig("corebot.conf");

            Console.WriteLine(" [OK]");

            Console.Write("loading user configuration [users.conf] ...");
            UserConfig _userConfig = new UserConfig("users.conf");
            Console.WriteLine(" [OK]");

            Console.WriteLine("Bot Nickname: " + _config.loadedConfig.BotNick + " [alt: " + _config.loadedConfig.AltNick + "]");
            Console.WriteLine("UserID: " + _config.loadedConfig.UserID);
            Console.WriteLine("Gecos: " + _config.loadedConfig.Gecos);

            Console.WriteLine("Servers: ");

            Array serversList = _config.loadedConfig.ServerList.ToArray();

            for(int x=0; x< serversList.Length; x++)
            {

                Console.WriteLine(x + 1 + ".  " + serversList.GetValue(x));
            }

        }
    }
}
