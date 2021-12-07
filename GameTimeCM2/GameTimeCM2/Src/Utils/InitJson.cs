using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTimeCM2.Src.Utils
{
    class InitJson
    {

        public static JsonTextReader UJsonTextReader(string url)
        {
            string URL_FILE_JSON_GAME = "json/game.json";
            StreamReader file = File.OpenText(Path.Combine(Directory.GetCurrentDirectory(), URL_FILE_JSON_GAME));
            return new JsonTextReader(file);
        }


    }
}
