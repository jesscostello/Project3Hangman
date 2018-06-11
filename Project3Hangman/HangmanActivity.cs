using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Environment = Android.OS.Environment;

namespace Project3Hangman
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class HangmanActivity : Activity
    {
        Button btnA;
        Button btnB;
        Button btnC;
        Button btnD;
        Button btnE;
        Button btnF;
        Button btnG;
        Button btnH;
        Button btnI;
        Button btnJ;
        Button btnK;
        Button btnL;
        Button btnM;
        Button btnN;
        Button btnO;
        Button btnP;
        Button btnQ;
        Button btnR;
        Button btnS;
        Button btnT;
        Button btnU;
        Button btnV;
        Button btnW;
        Button btnX;
        Button btnY;
        Button btnZ;

        ListView lv1;
        List<words> myList;
      

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //CopyTheDB();
            //gettheword();

            // Set our view from the Game layout resource
            SetContentView(Resource.Layout.Game);

            btnA = FindViewById<Button>(Resource.Id.btnA);
            btnB = FindViewById<Button>(Resource.Id.btnB);
            btnC = FindViewById<Button>(Resource.Id.btnC);
            btnD = FindViewById<Button>(Resource.Id.btnD);
            btnE = FindViewById<Button>(Resource.Id.btnE);
            btnF = FindViewById<Button>(Resource.Id.btnF);
            btnG = FindViewById<Button>(Resource.Id.btnG);
            btnH = FindViewById<Button>(Resource.Id.btnH);
            btnI = FindViewById<Button>(Resource.Id.btnI);
            btnJ = FindViewById<Button>(Resource.Id.btnJ);
            btnK = FindViewById<Button>(Resource.Id.btnK);
            btnL = FindViewById<Button>(Resource.Id.btnL);
            btnM = FindViewById<Button>(Resource.Id.btnM);
            btnN = FindViewById<Button>(Resource.Id.btnN);
            btnO = FindViewById<Button>(Resource.Id.btnO);
            btnP = FindViewById<Button>(Resource.Id.btnP);
            btnQ = FindViewById<Button>(Resource.Id.btnQ);
            btnR = FindViewById<Button>(Resource.Id.btnR);
            btnS = FindViewById<Button>(Resource.Id.btnS);
            btnT = FindViewById<Button>(Resource.Id.btnT);
            btnU = FindViewById<Button>(Resource.Id.btnU);
            btnV = FindViewById<Button>(Resource.Id.btnV);
            btnW = FindViewById<Button>(Resource.Id.btnW);
            btnX = FindViewById<Button>(Resource.Id.btnX);
            btnY = FindViewById<Button>(Resource.Id.btnY);
            btnZ = FindViewById<Button>(Resource.Id.btnZ);

            btnA.Click += onAnyLetterClick;
            btnB.Click += onAnyLetterClick;
            btnC.Click += onAnyLetterClick;
            btnD.Click += onAnyLetterClick;
            btnE.Click += onAnyLetterClick;
            btnF.Click += onAnyLetterClick;
            btnG.Click += onAnyLetterClick;
            btnH.Click += onAnyLetterClick;
            btnI.Click += onAnyLetterClick;
            btnJ.Click += onAnyLetterClick;
            btnK.Click += onAnyLetterClick;
            btnL.Click += onAnyLetterClick;
            btnM.Click += onAnyLetterClick;
            btnN.Click += onAnyLetterClick;
            btnO.Click += onAnyLetterClick;
            btnP.Click += onAnyLetterClick;
            btnQ.Click += onAnyLetterClick;
            btnR.Click += onAnyLetterClick;
            btnS.Click += onAnyLetterClick;
            btnT.Click += onAnyLetterClick;
            btnU.Click += onAnyLetterClick;
            btnV.Click += onAnyLetterClick;
            btnW.Click += onAnyLetterClick;
            btnX.Click += onAnyLetterClick;
            btnY.Click += onAnyLetterClick;
            btnZ.Click += onAnyLetterClick;
            lv1 = FindViewById<ListView>(Resource.Id.listView1);
            DoThis();
        }

        public void DoThis()
        {
            Database mydb = new Database();
            myList = mydb.ViewAll();
            lv1.Adapter = new DataAdapter(this, myList);

            if (myList.Count() > 0)
            {
                words WordItem = myList[1];

                string theword = WordItem.Word;

                Toast.MakeText(this, theword, ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(this, "There is nothing in the list.", ToastLength.Long).Show();
            }
        }

        private void onAnyLetterClick(object sender, EventArgs e)
        {
            string letter = (sender as Button).Text;

            Toast.MakeText(this, letter, ToastLength.Long).Show();

            // disable button so it can't be clicked again
            (sender as Button).Enabled = false;
        }

        //private void gettheword()
        //{
        //    Database mydb = new Database();

        //    string guessingWord = mydb.GetWords().ToString();

        //    Toast.MakeText(this, guessingWord, ToastLength.Long).Show();
        //}

        //private void CopyTheDB()
        //{
        //    // Check if your DB has already been extracted. If the file does not exist move it.
        //    //WARNING!!!!!!!!!!! If your DB changes from the first time you install it, ie: you change the tables, and you get errors then comment out the if wrapper so that it is FORCED TO UPDATE. Otherwise you spend hours staring at code that should run OK but the db, that you can’t see inside of on your phone, is diffferent from the db you are coding to.
        //    string dbName = "Hangman.db";
        //    string dbPath = Path.Combine(System.Environment.SpecialFolder.Personal.ToString(), dbName);

        //    //if (!File.Exists(dbPath))
        //    //{
        //        using (BinaryReader br = new BinaryReader(Assets.Open(dbName)))
        //        {
        //            using (BinaryWriter bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
        //            {
        //                byte[] buffer = new byte[2048];
        //                int len = 0;
        //                while ((len = br.Read(buffer, 0, buffer.Length)) > 0)
        //                {
        //                    bw.Write(buffer, 0, len);
        //                }
        //            }
        //        }
        //    //}
        //}
    }
}