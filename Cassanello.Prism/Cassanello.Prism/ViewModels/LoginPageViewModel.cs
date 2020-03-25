using Cassanello.Common.Models;
using Cassanello.Common.Service;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cassanello.Prism.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly IApiService _apiService;
        private string _contrasena;
        private bool _corriendo;
        private bool _activado;
        private DelegateCommand _accesoComando;


        public LoginPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            Title = "Iniciar Sesion";
            Activado = true;
            _apiService = apiService;
        }

        public DelegateCommand IngresarComando => _accesoComando ?? (_accesoComando = new DelegateCommand(login));

        public string Correo { get; set; }

        public string Contrasena
        {
            get => _contrasena;
            set => SetProperty(ref _contrasena, value);
        }

        public bool Corriendo
        {
            get => _corriendo;
            set => SetProperty(ref _corriendo, value);
        }

        public bool Activado
        {
            get => _activado;
            set => SetProperty(ref _activado, value);
        }

        private async void login()
        {
            if (string.IsNullOrEmpty(Correo))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debe ingresar un correo", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(Contrasena))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debe ingresar una contraseña", "Aceptar");
                return;
            }

            Corriendo = true;
            Activado = false;

            var request = new TokenRequest
            {
                Username = Correo,
                Password = Contrasena
            };

            var url = App.Current.Resources["UrlAPI"].ToString();
            var response = await _apiService.GetTokenAsync(url,"Account","/CreateToken",request);

            Corriendo =false;
            Activado = true;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", "El correo o contraseña incorrecto", "Aceptar");
                Contrasena = string.Empty;
                return;
            }

            await App.Current.MainPage.DisplayAlert("Mensaje", "Bienvenido a la APP", "Aceptar");


        }
    }
}
