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

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "My Toolbar";

            //txtThisScore = FindViewById<TextView>(Resource.Id.txtThisScore);
            //txtThisScore.Text = "Your score this time was: " + Player.score;
        }

        private void StartNewGame_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
                ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item);
        }


        ////When you choose Add from the Menu run the Add Activity. Good to know to add more options
        //public override bool OnOptionsItemSelected(IMenuItem item)
        //{
        //    var itemTitle = item.TitleFormatted.ToString();

        //    switch (itemTitle)
        //    {
        //        case "Add":
        //            //StartActivity(typeof(AddItem));
        //            Toast.MakeText(this, "Note Added", ToastLength.Long).Show();
        //            break;
        //    }
        //    return base.OnOptionsItemSelected(item);
        //}
        ////Basically reload stuff when the app resumes operation after being pauused
        //protected override void OnResume()
        //{
        //    base.OnResume();
        //    myList = DataManager.ViewAll();
        //    lvHighScores.Adapter = new DataAdapter(this, myList);
        //}
    }
}