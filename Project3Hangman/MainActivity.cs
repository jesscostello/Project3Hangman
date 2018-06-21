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
            SetContentView(Resource.Layout.Main);

            etName = FindViewById<EditText>(Resource.Id.etName);
            btnPlay = FindViewById<Button>(Resource.Id.btnPlay);
            btnScores = FindViewById<Button>(Resource.Id.btnScoreboard);
            radAnimals = FindViewById<RadioButton>(Resource.Id.radAnimals);
            radCountries = FindViewById<RadioButton>(Resource.Id.radCountries);
            radGroup = FindViewById<RadioGroup>(Resource.Id.radCategory);
            radGroup.CheckedChange += RadGroup_CheckedChange;
            btnPlay.Click += BtnPlay_Click;
            btnScores.Click += BtnScores_Click;

            SetCategory();
        }

        private void BtnScores_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ScoreBoardActivity));
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            string nameText = etName.Text;
            if (nameText == string.Empty || nameText.Length > 3)
            {
                Toast.MakeText(this, "Please enter your name", ToastLength.Long).Show();
            }
            else
            {
                Player.name = etName.Text;
                StartActivity(typeof(HangmanActivity));
            }
        }

        private void RadGroup_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            SetCategory();
        }

        private void SetCategory()
        {
            if (radAnimals.Checked == true)
            {
                Player.category = "ANIMALS";
            }
            if (radCountries.Checked == true)
            {
                Player.category = "COUNTRIES";
            }
        }
    }
}