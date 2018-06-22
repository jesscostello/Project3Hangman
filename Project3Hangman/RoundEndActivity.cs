using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Project3Hangman
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class RoundEndActivity : Activity
    {
        // instantiate the fields
        Button btnNextWord;
        Button btnEnd;
        ImageView image;
        TextView txtview;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the RoundEnd layout resource
            SetContentView(Resource.Layout.RoundEnd);
            // bind the fields to their corresponding resource IDs
            image = FindViewById<ImageView>(Resource.Id.imgResult);
            txtview = FindViewById<TextView>(Resource.Id.txtResult);
            btnEnd = FindViewById<Button>(Resource.Id.btnEndGame);
            btnNextWord = FindViewById<Button>(Resource.Id.btnNextWord);
            // bind the buttons to their click events
            btnEnd.Click += endGameClick;
            btnNextWord.Click += nextWordClick;

            DisplayResultPicture();
            UpdateResult();
        }
        /// <summary>
        /// Show a picture saying winner or loser
        /// </summary>
        private void DisplayResultPicture()
        {
            if (Player.outcome == "Win")
            {
                image.SetImageResource(Resource.Drawable.winner);
            }
            else
            {
                image.SetImageResource(Resource.Drawable.loser);
                // make the "next word" button invisible
                btnNextWord.Visibility = ViewStates.Invisible;
            }
        }
        /// <summary>
        /// Show text on the screen with players score
        /// </summary>
        private void UpdateResult()
        {
            if (Player.outcome == "Win")
            {
                txtview.Text = "Congrats " + Player.name + "! \nYour score is: " + Player.score + "\n\nMove onto the next word or save your current score to the leaderboard and end the game now.";
            }
            else
            {
                txtview.Text = "Bad luck! Your score is: " + Player.score + "\nThe correct word was: " + Player.theWord;
            }
        }
        /// <summary>
        /// When user clicks next word button
        /// </summary>
        private void nextWordClick(object sender, EventArgs e)
        {
            // start game activity again
            StartActivity(typeof (HangmanActivity));
        }
        /// <summary>
        /// When user clicks end game button
        /// </summary>
        private void endGameClick(object sender, EventArgs e)
        {
            // save score and name to database
            string name = Player.name;
            int score = Player.score;
            string category = Player.category;
            DataManager.AddItem(name, score, category);

            // go to scoreboard screen
            StartActivity(typeof(ScoreBoardActivity));
        }
        /// <summary>
        /// Override the "back" hardware button so user can't go back to the word
        /// </summary>
        public override bool OnKeyUp(Keycode Back, KeyEvent e)
        {
            return true;
        }

    }
}