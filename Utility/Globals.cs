using System.Windows;

namespace VolvoApp.Utility
{
    public class Globals {
        public static string CurrentUser { get; set; } = string.Empty;
        public static string CurrentUserDepartment { get; set; } = string.Empty;
        public static string MyKey { get; private set; } = "volvoplt1307";
        public static string CommonFolderPath { get; private set; } = "C:\\volvocompany\\";
        public static ResourceDictionary LanguageDictionary { get; set; } = new ResourceDictionary();
    }
}
