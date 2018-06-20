﻿using System;
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
        Button ResetScores;
        ListView lvHighScores;
        List<scores> myList;
        TextView txtHighScores;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ScoreBoard);

            StartNewGame = FindViewById<Button>(Resource.Id.btnPlayGame);
            StartNewGame.Click += StartNewGame_Click;
            ResetScores = FindViewById<Button>(Resource.Id.btnReset);
            ResetScores.Click += ResetScores_Click;
            txtHighScores = FindViewById<TextView>(Resource.Id.txtHighScores);
            lvHighScores = FindViewById<ListView>(Resource.Id.lvScores);
            DisplayScores();
        }

        public void DisplayScores()
        {
            myList = DataManager.ViewAll();
            lvHighScores.Adapter = new DataAdapter(this, myList);
            if (lvHighScores.Count >= 1)
            {
                ResetScores.Visibility = ViewStates.Visible;
            }
            else
            {
                ResetScores.Visibility = ViewStates.Gone;
            }
        }

        private void ResetScores_Click(object sender, EventArgs e)
        {
            //reset the scores
            // delete everything from the scores table
            DataManager.ResetScores();
            // refresh
            OnResume();
            ResetScores.Visibility = ViewStates.Gone;
        }

        //public override bool OnKeyUp(Keycode keyCode, KeyEvent e)
        //{
        //    if (keyCode == Keycode.Menu)
        //    {
        //        PopupMenu menu = new PopupMenu(this, StartNewGame);
        //        menu.Inflate(Resource.Menu.menu);
        //        menu.MenuItemClick += (s1, arg1) =>
        //        {
        //            // reset the scores
        //            // delete everything from the scores table
        //            DataManager.ResetScores();
        //            // refresh
        //            OnResume();
        //        };
        //        menu.Show();
        //        return true;
        //    }
        //    return base.OnKeyUp(keyCode, e);
        //}

        private void StartNewGame_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }

        //public override bool OnCreateOptionsMenu(IMenu menu)
        //{
        //    MenuInflater.Inflate(Resource.menu.top_menus, menu);
        //    return base.OnCreateOptionsMenu(menu);
        //}

        //public override bool OnOptionsItemSelected(IMenuItem item)
        //{
        //    Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
        //        ToastLength.Short).Show();
        //    return base.OnOptionsItemSelected(item);
        //}


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
        //Basically reload stuff when the app resumes operation after being pauused
        protected override void OnResume()
        {
            base.OnResume();
            myList = DataManager.ViewAll();
            lvHighScores.Adapter = new DataAdapter(this, myList);
        }
    }
}