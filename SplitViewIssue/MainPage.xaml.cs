using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SplitViewIssue
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.SizeChanged += MainPage_SizeChanged;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ContentFrame.Navigate(typeof(BlankPage1));
        }

        private void MainPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width < 280 || e.NewSize.Height < 300)
            {
                Debug.WriteLine($"Page Width: {((Page)ContentFrame.Content).ActualWidth} and Height: {((Page)ContentFrame.Content).ActualHeight}");
                Debug.WriteLine($"ContentFrame Width: {ContentFrame.ActualWidth} and Height: {ContentFrame.ActualHeight}");
                Debug.WriteLine("Smallest there is.");
            }
            else
            {
                Debug.WriteLine($"Page Width: {((Page)ContentFrame.Content).ActualWidth} and Height: {((Page)ContentFrame.Content).ActualHeight}");
                Debug.WriteLine($"ContentFrame Width: {ContentFrame.ActualWidth} and Height: {ContentFrame.ActualHeight}");
                Debug.WriteLine($"Width: {e.NewSize.Width} and Height: {e.NewSize.Height}");
            }
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationSplitView.IsPaneOpen = !NavigationSplitView.IsPaneOpen;
        }
    }
}