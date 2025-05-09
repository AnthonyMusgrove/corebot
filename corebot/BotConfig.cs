using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace corebot
{
    public class BotConfigFile
    {
        public String ?BotNick { get; set; }
        public String ?AltNick { get; set; }

        public String ?UserID { get; set; }

        public String ?Gecos { get; set; }

        public Dictionary<string, int>? ServerList { get; set; } = new Dictionary<string, int>();

    }

    public class BotConfig
    {
        public String filename = "";
        public BotConfigFile loadedConfig = new BotConfigFile();

        public BotConfig(String configFile)
        {
            this.filename = configFile;

            if (!File.Exists(this.filename))
            {
                //create a blank/default config file
                loadedConfig.BotNick = "Nickname";
                loadedConfig.AltNick = "AltNickname";
                loadedConfig.UserID = "corebot";
                loadedConfig.Gecos = "I am corebot!";

                loadedConfig?.ServerList?.Add("irc.libera.chat", 6697);

                this.Save();
            }
            else
            {
                this.Load();
            }
        }

        public void Save()
        {
            File.WriteAllText(this.filename, JsonConvert.SerializeObject(this.loadedConfig, Formatting.Indented));
        }

        public void Load()
        {
            try
            {
                this.loadedConfig = JsonConvert.DeserializeObject<BotConfigFile>(File.ReadAllText(this.filename));
            }
            catch (Exception ex)
            {

            }

        }


    }
}
