using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTimeCM2.Src
{
    public class Constants
    {

        // String 
        public static string STRING_INSCRIPTION_GOOD = "Inscription Validée !";
        public static string STRING_INSCRIPTION_ERROR = "Identifiant déjà utilisée !";


        // Text
        public static string TEXT_TITLE_SCORE_FINALE = "Score Finale";

        // Button
        public static string BUTTON_CONTENT_RETURN_HOME = "Retour à l'accueil";

        // DB Constants
        public static string DB_SELECT_USER = "SELECT * FROM User WHERE Name = ?name";
        public static string DB_SELECT_USERS = "SELECT * FROM User;";
        public static string DB_INSERT_USER = "INSERT INTO User(Name, Password) VALUES(?name, ?password)";

    }
}
