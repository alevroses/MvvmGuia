using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MvvmGuia.VistaModelo;

namespace MvvmGuia.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pagina1 : ContentPage
    {
        public Pagina1()
        {
            InitializeComponent();
            //Esto ya está enlazado al ViewModel 
            BindingContext = new VMpagina1(Navigation);
        }
    }
}