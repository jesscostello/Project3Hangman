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
    class DataAdapter : BaseAdapter<words>
    {
        private readonly Activity context;
        private readonly List<words> words;

        public DataAdapter(Activity context, List<words> words)
        {
            this.context = context;
            this.words = words;
        }

        public override words this[int position]
        {
            get { return words[position]; }
        }

        public override int Count
        {
            get
            {
                return words.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var word = words[position];
            var view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.Game, null);
            view.FindViewById<TextView>(Resource.Id.textView1).Text = word.Word;
            return view;
        }
    }
}