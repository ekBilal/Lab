using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab.Views
{
	public partial class Rest : ContentPage
	{

		int _time;
		bool nav = false;
		ContentPage _compteur;

		public Rest():this(4){}

		public Rest(int time)
		{
			InitializeComponent();
			_time = time;
			Start();
			lab.Text = _time.ToString();
			_compteur = new Compteur();
		}

		void Decompte(){
			lab.Text = (--_time).ToString();
			Start();
		}

		void Handle_Clicked(object sender, System.EventArgs e)
		{
			Next();
		}

		void Start(){
			if (_time > 0)
				Task.Delay(1000).ContinueWith(t => Device.BeginInvokeOnMainThread(Decompte));
			else
				Next();
		}

		void Next(){
			if (nav) return;
			nav = true;
			Navigation.PushModalAsync(_compteur);
		}
	}
}
