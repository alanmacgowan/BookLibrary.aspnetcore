using BookLibrary.aspnetcore.Domain;
using BookLibrary.aspnetcore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookLibrary.aspnetcore.Services.Implementations
{
    public class BaseService<T> where T : class, IBaseEntity
    {
        private string _baseUrl;
        private string _apiName;

        public BaseService(string baseUrl, string apiName)
        {
            _baseUrl = baseUrl;
            _apiName = apiName;
        }

        public virtual async Task<bool> Create(T entity)
        {
            var result = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);

                var response = await client.PostAsJsonAsync(_apiName, entity);
                if (response.IsSuccessStatusCode)
                {
                    result = true;
                }
            }
            return result;
        }

        public virtual async Task<bool> Delete(int id)
        {
            var result = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);

                var response = await client.DeleteAsync(_apiName + id);
                if (response.IsSuccessStatusCode)
                {
                    result = true;
                }
            }
            return result;
        }

        public virtual async Task<T> Get(int id)
        {
            T entity = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);

                var response = await client.GetAsync(_apiName + id);
                if (response.IsSuccessStatusCode)
                {
                    entity = await response.Content.ReadAsAsync<T>();
                }
            }
            return entity;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            var entities = new List<T>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);
                var response = await client.GetAsync(_apiName);
                if (response.IsSuccessStatusCode)
                {
                    entities = await response.Content.ReadAsAsync<List<T>>();
                }
            }
            return entities;
        }

        public virtual async Task<bool> Update(T entity)
        {
            var result = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUrl);

                var response = await client.PutAsJsonAsync(_apiName + entity.GetID(), entity);
                if (response.IsSuccessStatusCode)
                {
                    result = true;
                }
            }
            return result;
        }

    }
}
