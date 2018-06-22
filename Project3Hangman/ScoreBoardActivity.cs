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
    [Activity(Label = "High Scores", Theme = "@style/AppTheme", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ScoreBoardActivity : Activity
    {
        // instantate fields
        Button StartNewGame;
        Button ResetScores;
        Button btnAll;
        Button btnAnimals;
        Button btnCountries;
        ListView lvHighScores;
        List<scores> myList;
        TextView txtHighScores;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // set scoreboard layout
            SetContentView(Resource.Layout.ScoreBoard);
            // bind fields to resource IDs and buttons to click events
            StartNewGame = FindViewById<Button>(Resource.Id.btnPlayGame);
            StartNewGame.Click += StartNewGame_Click;
            ResetScores = FindViewById<Button>(Resource.Id.btnReset);
            ResetScores.Click += ResetScores_Click;
            btnAll = FindViewById<Button>(Resource.Id.btnAll);
            btnAll.Click += BtnAll_Click;
            btnAnimals = FindViewById<Button>(Resource.Id.btnAnimals);
            btnAnimals.Click += BtnAnimals_Click;
            btnCountries = FindViewById<Button>(Resource.Id.btnCountries);
            btnCountries.Click += BtnCountries_Click;
            txtHighScores = FindViewById<TextView>(Resource.Id.txtHighScores);
            lvHighScores = FindViewById<ListView>(Resource.Id.lvScores);
            DisplayScores();
        }
        /// <summary>
        /// Display a list of the scores
        /// </summary>
        public void DisplayScores()
        {
            myList = DataManager.ViewAll();
            lvHighScores.Adapter = new DataAdapter(this, myList);
            // "reset scores" button only shows if there are scores
            if (lvHighScores.Count >= 1)
            {
                ResetScores.Visibility = ViewStates.Visible;
            }
            else
            {
                ResetScores.Visibility = ViewStates.Gone;
            }
        }
        /// <summary>
        /// When user clicks all scores button
        /// </summary>
        private void BtnAll_Click(object sender, EventArgs e)
        {
            DisplayScores();
        }
        /// <summary>
        /// When user clicks animals button
        /// </summary>
        private void BtnAnimals_Click(object sender, EventArgs e)
        {
            // show in the list only scores from the animals category
            myList = DataManager.ViewAllAnimalsScores();
            lvHighScores.Adapter = new DataAdapter(this, myList);
        }
        /// <summary>
        /// When user clicks countries button
        /// </summary>
        private void BtnCountries_Click(object sender, EventArgs e)
        {
            // show in the list only scores from the countries category
            myList = DataManager.ViewAllCountriesScores();
            lvHighScores.Adapter = new DataAdapter(this, myList);
        }
        /// <summary>
        /// When user clicks reset scores button
        /// </summary>
        private void ResetScores_Click(object sender, EventArgs e)
        {
            // reset the scores
            // delete everything from the scores table
            DataManager.ResetScores();
            // refresh the list
            OnResume();
            ResetScores.Visibility = ViewStates.Gone;
        }
        /// <summary>
        /// When user clicks start new game button
        /// </summary>
        private void StartNewGame_Click(object sender, EventArgs e)
        {
            // go back to intial main screen
            StartActivity(typeof(MainActivity));
        }
        /// <summary>
        /// Reload the screen when the app resumes
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();
            myList = DataManager.ViewAll();
            lvHighScores.Adapter = new DataAdapter(this, myList);
        }
    }
}