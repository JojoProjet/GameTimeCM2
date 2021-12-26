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

       
        ///////////// Card /////////////

        // Ressources Application Card
        public static string APPLICATION_RESSOURCES_CARD = "Card";
        private const string RESSOURCES_ANIMATE_CARD_FRONT = "AnimateCardFront";
        private const string RESSOURCES_ANIMATE_CARD_BACK = "AnimateCardBack";

        // Animate Card
        public const int ANIMATE_DURATION_MILLI_SECONDES = 1500;
        public const string ANIMATE_SIDE_FRONT = "Front";
        public const string ANIMATE_SIDE_BACK = "Back";

        // Target Property Card
        public const string TARGET_PROPERTY_PROJECTION_PLANE_PROJECTION_ROTATION_X = "(UIElement.Projection).(PlaneProjection.RotationX)";


        //////////////////////////////

    }
}
