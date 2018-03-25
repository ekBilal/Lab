using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab.Views
{
	public partial class Compteur : ContentPage
	{
		int _cpt = 0;
		int _time = 5000;
		static Etat _etat = Etat.Ready;

		public Compteur()
		{
			InitializeComponent();
			cptLab.Text = "Play";
		}

		void Handle_Tapped(object sender, System.EventArgs e)
		{
			switch (_etat) {
				case Etat.Start:
					cptLab.Text = (++_cpt).ToString();
					break;
				case Etat.End:
					return;
				case Etat.Ready:
					Start();
					break;
			}
		}

		void Start(){
			_etat = Etat.Start;
			Task.Delay(_time).ContinueWith(t => Device.BeginInvokeOnMainThread(End));
		}

		async void End()
		{
			_etat = Etat.End;
			await DisplayAlert("Fin", "Ton score est de " + _cpt, "OK");
			_cpt = 0;
			await Task.Delay(500);
			Device.BeginInvokeOnMainThread(() => cptLab.Text = "Play");
			_etat = Etat.Ready;
		}	
	}
	public enum Etat
	{
		Ready, Start, End
	}
}
