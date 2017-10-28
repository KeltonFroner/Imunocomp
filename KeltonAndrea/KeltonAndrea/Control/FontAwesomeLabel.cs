using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KeltonAndrea.Control
{
    public class FontAwesomeLabel : Label
    {
        public static readonly string FontAwesomeName = "FontAwesome";

        //Parameterless constructor for XAML
        public FontAwesomeLabel()
        {
            FontFamily = FontAwesomeName;
        }

        public FontAwesomeLabel(string fontAwesomeLabel = null)
        {
            FontFamily = FontAwesomeName;
            Text = fontAwesomeLabel;
        }
    }

    // https://github.com/neilkennedy/FontAwesome.Xamarin/blob/master/FontAwesome.Xamarin/FontAwesome.cs
    // For a huge list of icon codes
    public static class Icon
    {
        public static readonly string FAUser = "\uf007";
        public static readonly string FAInstitute = "\uf19c";
        public static readonly string FAPassword = "\uf13e";
        public static readonly string FAArchive = "\uf187";
        public static readonly string FACalendar = "\uf073";
        public static readonly string FAText = "\uf0e6";
        public static readonly string FANumber = "\uf162 ";
        public static readonly string FAArrowRight = "\uf061 ";
        public static readonly string FAArrowDown = "\uf063 ";
        public static readonly string FASquareEmpty = "\uf096 ";
        public static readonly string FASquareCheck = "\uf046 ";
        public static readonly string FASearch = "\uf002 ";
        public static readonly string FAGear = "\uf085 ";
        public static readonly string FAComputer = "\uf109 ";
        public static readonly string FADelete = "\uf014 ";
        public static readonly string FAOpen = "\uf08e ";
        public static readonly string FAEdit = "\uf044 ";
        public static readonly string FAIdentity = "\uf2c2  ";
        public static readonly string FALogo = "\uf21e ";
    }
}