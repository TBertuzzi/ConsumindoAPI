﻿using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ConsumindoAPI.Helpers;
using ConsumindoAPI.Model;
using ConsumindoAPI.Services;
using Refit;
using Xamarin.Forms.MVVMBase.ViewModels;

namespace ConsumindoAPI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Pessoa> Pessoas { get; }
        IApiService _ApiService;
       // IRefitApiService _ApiService;

        public MainViewModel() : base("Main View")
        {
            Title = "Herois Marvel";

            Pessoas = new ObservableCollection<Pessoa>();

            // _ApiService = new ApiService();

             _ApiService = new ApiXamarinHelpersService();

            // _ApiService = RestService.For<IRefitApiService>(Constantes.ApiBaseUrl);
        }

        public override async Task LoadAsync(object navigationData)
        {
            try
            {
                IsBusy = true;

                var usuario = await _ApiService.GetUsuario();

                Pessoas.Clear();

                foreach (var personagem in usuario.Pessoas)
                {
                    Pessoas.Add(personagem);
                }

            }
            catch (Exception ex)
            {
                await DialogService.AlertAsync("Erro", "Erro ao Carregar pessoas:" + ex.Message, "OK");
            }
            finally
            {

                IsBusy = false;
            }
        }
    }
}
