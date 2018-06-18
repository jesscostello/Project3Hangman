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
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class RoundEndActivity : Activity, IPlayer
    {
        //Player myPlayer = new Player();

        Button btnNextWord;
        Button btnEnd;
        ImageView image;
        TextView txtview;

        public string name { get; set; }
        public int score { get; set; }
        public string outcome { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the RoundEnd layout resource
            SetContentView(Resource.Layout.RoundEnd);

            image = FindViewById<ImageView>(Resource.Id.imgResult);
            txtview = FindViewById<TextView>(Resource.Id.txtResult);
            //btnEnd = FindViewById<Button>(Resource.Id.btnEndGame);
            btnNextWord = FindViewById<Button>(Resource.Id.btnNextWord);
            btnNextWord.Click += nextWordClick;

            DisplayResultPicture();
            UpdateResult();
            
        }

        private void DisplayResultPicture()
        {
            if (outcome == "Win")
            {
                Toast.MakeText(this, "testing" + score, ToastLength.Long).Show();
                image.SetImageResource(Resource.Drawable.hangman3);
            }
            else
            {
                Toast.MakeText(this, "Game Over " + outcome + " Score: " + score, ToastLength.Long).Show();
                image.SetImageResource(Resource.Drawable.hangman8);
            }
            
        }

        private void UpdateResult()
        {
            if (outcome == "Win")
            {
                txtview.Text = "Congrats " + name + "! Move onto the next word or save your current score to the leaderboard and end the game now. \n Your score is: " + score;
            }
            else
            {
                txtview.Text = "Bad luck! Your score is: " + score;
            }
            
        }

        private void nextWordClick(object sender, EventArgs e)
        {
            // change back to game view
            // reset values
        }
    }
}