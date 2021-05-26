using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace COVID19.Client.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class COVID19CaseCharts : BaseContentPage
    {
        public COVID19CaseCharts()
        {
            InitializeComponent();
        }
    }
}