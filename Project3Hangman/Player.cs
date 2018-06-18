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
    public class Player
    {
        public string playerName { get; set; }
        public int score { get; set; } = 0;
        public string outcome { get; set; }

        public Player()
        {

        }
    }
}