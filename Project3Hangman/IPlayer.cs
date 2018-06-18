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
    public interface IPlayer
    {
        string name { get; set; }
        int score { get; set; }
        string outcome { get; set; }
    }
}