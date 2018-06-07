using System;
using System.Collections.Generic;
using System.IO;
using Android.Util;
using SQLite;

namespace Project3Hangman
{
    class Database
    {
        SQLiteConnection db;
        private static string databasePath;
        private static string databaseName;
        private string tag = "aaa";

        public Database()
        {
            DBConnect();
        }

        private void DBConnect()
        {
            databaseName = "H2.db";
            databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), databaseName);
          //  databasePath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), databaseName);

            db = new SQLiteConnection(databasePath);
           // db.CreateTable<words>();
        }

        public List<words> ViewAll()
        {

            //if (!File.Exists(databasePath))
            //{
                //List<words> NoData = new List<words>();

                //NoData.Add(new words { Word = "No Data" });
                //return NoData;

            //}

            //try
            //{
                var query = db.Query<words>("SELECT * FROM words");

                if (query.Count > 0)
                {
                    //List<words> YesData = new List<words>();
                    //return YesData;

                    return db.Query<words>("SELECT * FROM words");
                }
                else
                {
                    List<words> NoData = new List<words>();
                    //int count = query.Count;
                    NoData.Add(new words { Word = "No Data "});
                    NoData.Add(new words { Word = "testing"});
                    NoData.Add(new words { Word = "hangman"});
                    NoData.Add(new words { Word = "broken"});
                return NoData;

               }

            //}
            //catch (Exception e)
            //{
            //    Log.Info(tag, "ERROR Did the DB move across??:" + e.Message);
            //    return null;
            //}
        }

        //public IEnumerable<words> ViewAll()
        //{
        //    //try
        //    //{
        //    return db.Query<words>("SELECT * FROM words");
        //    //}
        //    //catch (Exception e)
        //    //{
        //    //    Console.WriteLine("Error:" + e.Message);

        //    //    //making some fake items to stop the system from crashing when the DB doesn't connect
        //    //    List<words> fakeword = new List<words>();
        //    //    //make a single item
        //    //    words word = new words();
        //    //    word.Id = 100;
        //    //    word.Word = "Fake word";
        //    //    fakeword.AddRange(new[] { word }); //add it to the fake item list

        //    //    return fakeword;
        //    //}
        //}
        //public IEnumerable<words> GetWords()
        //{
        //    if (db.Table<words>().Count() > 0)
        //    {
        //        return db.Query<words>("SELECT * FROM words");
        //    }
        //    else
        //    {
        //        // make a fake word to stop the system from crashing when the DB doesn't connect
        //        List<words> fakeword = new List<words>();
        //        // make a single word
        //        words word = new words();
        //        word = FakeEntry();
        //        fakeword.AddRange(new[] { word }); // add it to the fake words list
        //        return fakeword;

        //    }
        //}

        //public IEnumerable<words> GetWords()
        //{
        //    return db.Query<words>("SELECT * FROM words");
        //}

        //public static words FakeEntry()
        //{
        //    words word = new words();
        //    word.Id = 1;
        //    word.Word = "Fake word";
        //    return word;
        //}

        //public string SelectWord()
        //{
        //    string result = "blank";

        //    try
        //    {
        //        result = "this is " + db.Query<words>("SELECT Word FROM words WHERE Id = 2") + " inside";
        //    }
        //    catch (Exception e)
        //    {

        //        result = "Error: " + e.Message;
        //    }

        //    return result;
        //}
    }
}