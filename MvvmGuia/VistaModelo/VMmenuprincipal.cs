using MvvmGuia.Modelo;
using MvvmGuia.Vistas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmGuia.VistaModelo
{
    public class VMmenuprincipal : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        public List<Mmenuprincipal> listapaginas { get; set; }
        #endregion

        #region CONSTRUCTOR
        public VMmenuprincipal(INavigation navigation)
        {
            Navigation = navigation;
            MostrarPaginas();
        }
        #endregion

        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        #endregion

        #region PROCESOS
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }
        //Cuando no son procesos Asíncronos se
        //remplaza el async Task por void 
        public void MostrarPaginas()
        {
            listapaginas = new List<Mmenuprincipal>
            {
                new Mmenuprincipal
                {
                    Pagina = "Entry, datepicker, picker, label, navegación",
                    Icono = "https://i.postimg.cc/fLF1H03f/angry.png"
                },
                new Mmenuprincipal
                {
                    Pagina = "CollectionView sin enlace a Base de datos",
                    Icono = "https://i.postimg.cc/KY06MWxV/annoyed.png"
                },
                new Mmenuprincipal
                {
                    Pagina = "Crud pokemon",
                    Icono = "https://i.postimg.cc/FF0dHQRx/pokeball.png"
                }
            };
        }
        public async Task Navegar(Mmenuprincipal parametros)
        {
            string pagina;
            pagina = parametros.Pagina;

            if(pagina.Contains("Entry, datepicker"))
            {
                await Navigation.PushAsync(new Pagina1());
            }
            if (pagina.Contains("CollectionView sin enlace"))
            {
                await Navigation.PushAsync(new Pagina2());
            }
            if (pagina.Contains("Crud pokemon"))
            {
                await Navigation.PushAsync(new Crudpokemon());
            }
        }
        #endregion

        #region COMANDOS
        //Llamar al Proceso Asincrona: await es para tareas asincronas
        //public ICommand Volvercommand => new Command(async () => await Volver());
        //Llamar al Proceso Simple o no Asincrono
        //public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        public ICommand Navegarcommand => new Command<Mmenuprincipal>(async (p) => await Navegar(p));
        #endregion
    }
}
