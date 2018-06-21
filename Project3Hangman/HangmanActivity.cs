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
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class HangmanActivity : Activity
    {
        public string theWordToGuess { get; set; }
        public char[] theWordToGuessArray { get; set; }
        public int numberOfLetters { get; set; }
        public char[] guessingWordArray { get; set; }
        public int theCurrentLevel { get; set; } = 0;
        public int currentScore { get; set; }
        public ImageView HangmanImage { get; set; }

        #region instantiate buttons
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
        #endregion
        List<words> myList = new List<words>();
        TextView lettersOfWord;
        TextView txtName;
        TextView txtScore;
        TextView txtLetters;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the Game layout resource
            SetContentView(Resource.Layout.Game);
            #region buttons
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
            #endregion
            #region button clicks
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
            #endregion

            lettersOfWord = FindViewById<TextView>(Resource.Id.textView1);
            HangmanImage = FindViewById<ImageView>(Resource.Id.imgHangman);
            txtLetters = FindViewById<TextView>(Resource.Id.txtLetterCount);
            txtName = FindViewById<TextView>(Resource.Id.txtnPName);
            txtScore = FindViewById<TextView>(Resource.Id.txtPScore);
            
            lettersOfWord.Text = "";
            LoadWordsFromFile();
            PickARandomWord();
            SetUpPlayerDetails();
        }

        public void LoadWordsFromFile()
        {
            string cat = "";
            if (Player.category == "ANIMALS")
            {
                cat = "animals";
            }
            else if (Player.category == "COUNTRIES")
            {
                cat = "countries";
            }
            try
            {
                var assets = Assets;
                using (var sr = new StreamReader(assets.Open(cat + ".txt")))
                {
                    while (!sr.EndOfStream)
                    {
                        var text = sr.ReadLine();
                        // only get lines with words on them, or with more than 4 letters
                        if (text != string.Empty && text.Length > 4) 
                        {
                            text = text.Trim();

                            if (text.Length > 4)
                            {
                                myList.Add(new words { Word = text });
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Toast.MakeText(this, "Database didn't load", ToastLength.Long).Show();
                Console.WriteLine(e);
            }
        }

        private void PickARandomWord()
        {
            int Count = myList.Count();
            Random myrnd = new Random();
            int WordId = myrnd.Next(0, Count);

            words WordItem = myList[WordId];
            string theword = WordItem.Word;

            theWordToGuess = WordItem.Word.ToUpper();

            Player.theWord = theWordToGuess;

            LoadTheWord();
        }

        private void SetUpPlayerDetails()
        {
            txtLetters.Text += numberOfLetters;
            txtName.Text += Player.name;
            txtScore.Text += Player.score;
        }
        private void LoadTheWord()
        {
            numberOfLetters = theWordToGuess.Length;
            theWordToGuessArray = theWordToGuess.ToCharArray();
            char[] guessingArray = new char[numberOfLetters];
            
            for (int i = 0; i < numberOfLetters; i++)
            {
                char underscore = new char();
                underscore = '_';
                guessingArray[i] = underscore;
            }
            string s = new string(guessingArray);
            guessingWordArray = s.ToCharArray();
            DisplayWord();
        }

        private void DisplayWord()
        {
            string result = new string(guessingWordArray);
            lettersOfWord.Text = result;
        }

        private void onAnyLetterClick(object sender, EventArgs e)
        {
            string letter = (sender as Button).Text;

            // disable button so it can't be clicked again
            (sender as Button).Enabled = false;

            CheckForLetter(letter);
            CheckToSeeIfWordIsCompleted();
        }

        private void CheckToSeeIfWordIsCompleted()
        {
            // if array contains _ do nothing. if not end game
            if (!guessingWordArray.Contains('_'))
            {
                Player.outcome = "Win";
                EndGame();
            }
        }

        private void CheckForLetter(string letter)
        {
            char[] Letter = letter.ToCharArray();
            
            // if the letter is in the word
            if (theWordToGuess.Contains(letter))
            {
                for (int i = 0; i < theWordToGuessArray.Length; i++)
                {
                    if (theWordToGuessArray[i] == Letter[0])
                    {
                        guessingWordArray[i] = Letter[0];
                    }
                }
                DisplayWord();
            }
            else
            {
                WrongLetter();
            }
        }

        private void WrongLetter()
        {
            theCurrentLevel++;
            HangmanLevels();
        }

        private void HangmanLevels()
        {
            switch (theCurrentLevel)
            {
                case 1:
                    HangmanImage.SetImageResource(Resource.Drawable.hangman1);
                    break;
                case 2:
                    HangmanImage.SetImageResource(Resource.Drawable.hangman2);
                    break;
                case 3:
                    HangmanImage.SetImageResource(Resource.Drawable.hangman3);
                    break;
                case 4:
                    HangmanImage.SetImageResource(Resource.Drawable.hangman4);
                    break;
                case 5:
                    HangmanImage.SetImageResource(Resource.Drawable.hangman5);
                    break;
                case 6:
                    HangmanImage.SetImageResource(Resource.Drawable.hangman6);
                    break;
                case 7:
                    HangmanImage.SetImageResource(Resource.Drawable.hangman7);
                    break;
                case 8:
                    HangmanImage.SetImageResource(Resource.Drawable.hangman8);
                    Player.outcome = "Loss";
                    EndGame();
                    break;

            }
        }
        
        private void EndGame()
        {
            // if game is won or lost
            UpdateScore();
            ShowWordResults();
        }

        private void ShowWordResults()
        {
            StartActivity(typeof(RoundEndActivity));
        }

        private void UpdateScore()
        {
            int gameScore;

            if (Player.outcome == "Win")
            {
                gameScore = numberOfLetters * 5;
            }
            else
            {
                gameScore = 0;
            }
            Player.score = gameScore;
            //Player.score = Player.score + currentScore;
        }
    }
}