using SneakerLocalMaui.Models;

namespace SneakerLocalMaui
{
    public partial class SneakerDetailPage : ContentPage
    {
        public SneakerDetailPage(Sneakers selectedSneaker)
        {
            InitializeComponent();

            // Set the BindingContext of the page to the selected sneaker
            BindingContext = selectedSneaker;
        }
    }
}
