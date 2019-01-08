﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ConsumindoAPI.Model;

namespace ConsumindoAPI.Services
{
    public class ApiXamarinHelpersService : IApiService
    {
        public ApiXamarinHelpersService()
        {
        }


        public async Task<Usuario> GetUsuario()
        {
            try
            {
                var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //GetAsync Return with Object
                var response = await httpClient.GetAsync<Usuario>("person");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return response.Value;
                }
                else
                {
                    throw new Exception(
                           $"HttpStatusCode: {response.StatusCode.ToString()} Message: {response.Content}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
