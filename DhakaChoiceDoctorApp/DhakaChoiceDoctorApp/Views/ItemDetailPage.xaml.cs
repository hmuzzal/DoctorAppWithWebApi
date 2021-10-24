using DhakaChoiceDoctorApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DhakaChoiceDoctorApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}