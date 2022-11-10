using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using MvvmGuia.Modelo;

namespace MvvmGuia.VistaModelo
{
    public class VMpagina2:BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        public List<Musuario> listausuarios { get; set; }
        #endregion

        #region CONSTRUCTOR
        public VMpagina2(INavigation navigation)
        {
            Navigation = navigation;
            Mostrarusuarios();
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
        public void Mostrarusuarios()
        {
            listausuarios = new List<Musuario>
            {
                new Musuario
                {
                    Nombre = "Frank",
                    Imagen = "https://i.postimg.cc/fLF1H03f/angry.png"
                },
                new Musuario
                {
                    Nombre = "Juan",
                    Imagen = "https://i.postimg.cc/KY06MWxV/annoyed.png"
                },
                new Musuario
                {
                    Nombre = "Carlos",
                    Imagen = "https://i.postimg.cc/wv3SckBB/excited.png"
                }
            };
        }
        public async Task Alerta(Musuario parametros)
        {
            await DisplayAlert("Titulo", parametros.Nombre, "Ok");
        }
        #endregion

        #region COMANDOS
        //Llamar al Proceso Asincrona: await es para tareas asincronas
        public ICommand Volvercommand => new Command(async () => await Volver());
        //Llamar al Proceso Simple o no Asincrono
        //public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        public ICommand Alertacommand => new Command<Musuario>(async (p) => await Alerta(p));
        #endregion
    }
}
