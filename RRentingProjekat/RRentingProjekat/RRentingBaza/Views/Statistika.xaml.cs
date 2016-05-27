using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RRentingProjekat.RRentingBaza.Views
{
    public class Records
    {
        public string Name { get; set; }
        public int Amount { get; set; }
    }


    public sealed partial class Statistika : Page
    {
        public List<int> iznosi = new List<int>();

       

        public Statistika()
        {
            this.InitializeComponent();
            LoadChartContents();

            NavigationCacheMode = NavigationCacheMode.Required;

            iznosi = DataSource.DataSourceRRenting.dajOcjeneGostiju();
        }

        private void LoadChartContents()
        {
           
            List<Records> records = new List<Records>();

            int i1 = 0, i2 = 0, i3 = 0, i4 = 0, i5 = 0;
            for (int i = 0; i < iznosi.Count(); i++)
            {
                if (iznosi[i] == 1) i1++;
                else if (iznosi[i] == 2) i2++;
                else if (iznosi[i] == 3) i3++;
                else if (iznosi[i] == 4) i4++;
                else if (iznosi[i] == 5) i5++;
            }
            records.Add(new Records(){
                Name = "1", Amount = i1
    });
            records.Add(new Records()
            {
                Name = "2", Amount = i2
    });
            records.Add(new Records()
            {
                Name = "3", Amount = i3
    });
            records.Add(new Records()
    {
                Name = "4", Amount = i4
    });
            records.Add(new Records()
            {
                Name = "5",
                Amount = i5
            });

            (PieChart.Series[0] as PieSeries).ItemsSource = records;
            
        }
    }
}
