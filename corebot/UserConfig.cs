using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace corebot
{

    public class BotUser
    {
        public string? nickname { get; set; }
        public string? userid { get; set; }
        public string? host { get; set; }
        public string? password { get; set; }
        public DateTime lastseen { get; set; }
    }

    public class UserConfigFile
    {
        public List<BotUser>? owners { get; set; } = new List<BotUser>();
    }

    public class UserConfig
    {
        public String filename = "";
        public UserConfigFile loadedConfig = new UserConfigFile();

        public UserConfig(String configFile)
        {
            this.filename = configFile;

            if (!File.Exists(this.filename))
            {
                BotUser rootUser = new BotUser();

                //create a blank/default config file
                rootUser.nickname = "rootUserNickname";
                rootUser.userid = "rootUserId";
                rootUser.host = "rootUserHost";
                rootUser.password = "rootPassword";
                rootUser.lastseen = DateTime.Now;

                loadedConfig?.owners?.Add(rootUser);

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
                 this.loadedConfig = JsonConvert.DeserializeObject<UserConfigFile>(File.ReadAllText(this.filename));
            }
            catch(Exception ex)
            {
                throw new Exception("Error loading users configuration.  Check users.conf for errors.");
            }
        }


    }
}
