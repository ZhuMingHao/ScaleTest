using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ScaleTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<Color> ColorList { get; set; } = new List<Color>();
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            // FixUpScale();
            ColorList.Add(Colors.Red);
            ColorList.Add(Colors.Gray);
            ColorList.Add(Colors.Black);
            ColorList.Add(Colors.DarkBlue);
            ColorList.Add(Colors.DarkGoldenrod);
            //  BgColorList.ItemsSource = ColorList;
        }


        private void FixUpScale()
        {
            // Need to add a using for System.Reflection;

            var displayInfo = DisplayInformation.GetForCurrentView();
            var displayType = displayInfo.GetType();
            var rawPixelsProperty = displayType.GetRuntimeProperty("RawPixelsPerViewPixel");

            if (rawPixelsProperty != null)
            {
                var realScale = (double)rawPixelsProperty.GetValue(displayInfo);

                // To get to actual Windows 10 scale, we need to convert from 
                // the de-scaled Win8.1 (100/125) back to 100, then up again to
                // the desired scale factor (125). So we get the ratio between the
                // Win8.1 pixels and real pixels, and then square it. 
                var fixupFactor = Math.Pow((double)displayInfo.ResolutionScale /
                  realScale / 100, 2);

                Window.Current.Content.RenderTransform = new ScaleTransform
                {
                    ScaleX = fixupFactor,
                    ScaleY = fixupFactor
                };
            }
        }

        private void BgColorList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //  var item = BgColorList.SelectedItem;
        }

        private void BgColor_Tapped(object sender, TappedRoutedEventArgs e)
        {

         var ll =   BgListView.GetChild("TestBtn");

        }
    }

   
}
