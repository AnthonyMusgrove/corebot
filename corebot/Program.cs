namespace corebot
{

    internal class Program
    {

        static async Task Main(string[] args)
        {
            Console.WriteLine("corebot loading ...");

            Console.Write("loading bot configuration [corebot.conf] ... ");
            BotConfig _botConfig = new BotConfig("corebot.conf");

            Console.WriteLine(" [OK]");

            Console.Write("loading user configuration [users.conf] ...");
            UserConfig _userConfig = new UserConfig("users.conf");
            Console.WriteLine(" [OK]");

            Console.WriteLine("Bot Nickname: " + _botConfig.loadedConfig.BotNick + " [alt: " + _botConfig.loadedConfig.AltNick + "]");
            Console.WriteLine("UserID: " + _botConfig.loadedConfig.UserID);
            Console.WriteLine("Gecos: " + _botConfig.loadedConfig.Gecos);

            Console.WriteLine("Servers: ");

//            Array serversList = _botConfig.loadedConfig.ServerList.ToArray();

            for(int x=0; x< _botConfig.loadedConfig.ServerList.Count; x++)
                Console.WriteLine(x + 1 + ".  " + _botConfig.loadedConfig.ServerList[x].hostname + ":" + _botConfig.loadedConfig.ServerList[x].port.ToString() + " [pwd: " + _botConfig.loadedConfig.ServerList[x].password + "]");

            IRCHandler _coreBot = new IRCHandler(_botConfig, _userConfig);

            _coreBot.Run();
            await Task.Delay(Timeout.Infinite);

        }
    }
}
