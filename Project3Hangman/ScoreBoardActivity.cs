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
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ScoreBoardActivity : Activity
    {
        Button StartNewGame;
        ListView lvHighScores;
        List<scores> myList;
        TextView txtThisScore;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ScoreBoard);

            StartNewGame = FindViewById<Button>(Resource.Id.btnPlayGame);
            StartNewGame.Click += StartNewGame_Click;

            lvHighScores = FindViewById<ListView>(Resource.Id.lvScores);
            myList = DataManager.ViewAll();
            lvHighScores.Adapter = new DataAdapter(this, myList);

            txtThisScore = FindViewById<TextView>(Resource.Id.txtThisScore);

            txtThisScore.Text = "Your score this time was: " + Player.score;
        }

        private void StartNewGame_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}