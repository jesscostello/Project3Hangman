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
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button btnPlay;
        Button btnScores;
        EditText etName;
        RadioButton radAnimals;
        RadioButton radCountries;
        RadioGroup radGroup;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            // Set view to main screen layout
            SetContentView(Resource.Layout.Main);
            // Bind fields to their corressponding resource ID
            btnPlay = FindViewById<Button>(Resource.Id.btnPlay);
            btnScores = FindViewById<Button>(Resource.Id.btnScoreboard);
            etName = FindViewById<EditText>(Resource.Id.etName);
            radAnimals = FindViewById<RadioButton>(Resource.Id.radAnimals);
            radCountries = FindViewById<RadioButton>(Resource.Id.radCountries);
            radGroup = FindViewById<RadioGroup>(Resource.Id.radCategory);
            // bind methods for user events 
            radGroup.CheckedChange += RadGroup_CheckedChange;
            btnPlay.Click += BtnPlay_Click;
            btnScores.Click += BtnScores_Click;

            SetCategory();
        }
        /// <summary>
        /// On "Scores" Button click
        /// </summary>
        private void BtnScores_Click(object sender, EventArgs e)
        {
            // start up score board activity
            StartActivity(typeof(ScoreBoardActivity));
        }
        /// <summary>
        /// When a radio button is checked
        /// </summary>
        private void RadGroup_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            // make sure the correct category is set 
            SetCategory();
        }
        /// <summary>
        /// Set the correct category to the Players class to store for future use
        /// </summary>
        private void SetCategory()
        {
            // if animals is selected
            if (radAnimals.Checked == true)
            {
                Player.category = "ANIMALS";
            }
            // if countries is selected
            if (radCountries.Checked == true)
            {
                Player.category = "COUNTRIES";
            }
        }
        /// <summary>
        /// On "play game" button click
        /// </summary>
        private void BtnPlay_Click(object sender, EventArgs e)
        {
            // set a local variable to store the text in the name textbox
            string nameText = etName.Text;
            // if the textbox is empty or not the usual length of someone's name
            if (nameText == string.Empty || nameText.Length > 3)
            {
                // Ask user to enter their name
                Toast.MakeText(this, "Please enter your name", ToastLength.Long).Show();
            }
            // Else store the name in the Players class
            // And start the game activity
            else
            {
                Player.name = etName.Text;
                StartActivity(typeof(HangmanActivity));
            }
        }
    }
}