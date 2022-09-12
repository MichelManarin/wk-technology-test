using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web_Application.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace Web_Application.Services
{
    public class HttpProdutoService : IHttpProdutoService
    {
        public async Task<List<CategoriaViewModel>> GetAllCategorias()
        {
            HttpClient httpClient = new HttpClient();

            var response = await httpClient.GetAsync($"http://localhost:5005/categoria/list");
            
            var value = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<CategoriaViewModel>>(value);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Something is wrong");

            return result;
        }

        public async Task<List<ProdutoViewModel>> GetAllProdutos()
        {
            HttpClient httpClient = new HttpClient();

            var response = await httpClient.GetAsync($"http://localhost:5005/produto/list");
            
            var value = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<ProdutoViewModel>>(value);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Something is wrong");

            return result;
        }

        public async Task<ProdutoViewModel> CreateProduto(ProdutoViewModel produto)
        {
            HttpClient httpClient = new HttpClient();

            var request = new HttpRequestMessage {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost:5005/produto/create"),
                Content = new StringContent(JsonConvert.SerializeObject(produto), null, "application/json")
            };

            var response = httpClient.SendAsync(request).Result;

            var value = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ProdutoViewModel>(value);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Something is wrong");

            return result;
        }

        public async Task<ProdutoViewModel> UpdateProduto(ProdutoViewModel produto){
            HttpClient httpClient = new HttpClient();

            var request = new HttpRequestMessage {
                Method = HttpMethod.Put,
                RequestUri = new Uri("http://localhost:5005/produto/update"),
                Content = new StringContent(JsonConvert.SerializeObject(produto), null, "application/json")
            };

            var response = httpClient.SendAsync(request).Result;

            var value = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ProdutoViewModel>(value);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Something is wrong");

            return result;
        }

        public async Task<CategoriaViewModel> CreateCategoria(CategoriaViewModel categoria)
        {
            HttpClient httpClient = new HttpClient();

            var request = new HttpRequestMessage {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost:5005/categoria/create"),
                Content = new StringContent(JsonConvert.SerializeObject(categoria), null, "application/json")
            };

            var response = httpClient.SendAsync(request).Result;

            var value = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<CategoriaViewModel>(value);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Something is wrong");

            return result;
        }

        public async Task DeleteCategoria(int categoriaId)
        {
            HttpClient httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync($"http://localhost:5005/categoria/delete/{categoriaId}");

            var value = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception("Something is wrong");
        }

        public async Task<List<ProdutoViewModel>> DeleteProduto(int produtoId)
        {
            HttpClient httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync($"http://localhost:5005/produto/delete/{produtoId}");

            var value = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<ProdutoViewModel>>(value);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Something is wrong");

            return result;
        }

        public async Task<ProdutoViewModel> GetProdutoById(int id)
        {
            HttpClient httpClient = new HttpClient();

            var response = await httpClient.GetAsync($"http://localhost:5005/produto/{id}");
            
            var value = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ProdutoViewModel>(value);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Something is wrong");

            return result;
        }
    }
}