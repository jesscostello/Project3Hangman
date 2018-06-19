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
        EditText etName;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Main);

            etName = FindViewById<EditText>(Resource.Id.etName);
            btnPlay = FindViewById<Button>(Resource.Id.btnPlay);

            btnPlay.Click += BtnPlay_Click;
            etName.TextChanged += EtName_TextChanged;
        }

        private void EtName_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            btnPlay.Enabled = true;
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            Player.name = etName.Text;
            StartActivity(typeof(HangmanActivity));
        }
    }
}