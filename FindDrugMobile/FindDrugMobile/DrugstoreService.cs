﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FindDrugMobile
{
    class DrugstoreService
    {
        const string Url = "http://192.168.43.221:5000/FindRoutes?id_grud=1&id_ost=3";
        // настройка клиента
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<IEnumerable<Drugstore>> Get(int id_drug, int id_ost)
        {
            HttpClient client = GetClient();
            string route = "http://192.168.43.221:5000/FindRoutes?id_grud=" + id_drug + "&id_ost=" + id_ost;
            string result = await client.GetStringAsync(route);
            return JsonConvert.DeserializeObject<IEnumerable<Drugstore>>(result);
        }
    }
}
