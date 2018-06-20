using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Project3Hangman
{
    public static class Player
    {
        public static string name { get; set; }
        public static int score { get; set; } = 0;
        public static string outcome { get; set; }
        public static string theWord { get; set; }

        static Player()
        {

        }
    }
}