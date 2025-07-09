using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_032025.CommonNetcore
{
    public static class HttpHelper
    {
        // HÀM GET

        // HÀM POST KHÔNG TOKEN 

        public static string HttpPost(string url, string data)
        {
            try
            {
                using (var client = new System.Net.Http.HttpClient())
                {
                    var content = new System.Net.Http.StringContent(data, Encoding.UTF8, "application/json");
                    var response = client.PostAsync(url, content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        throw new Exception($"Error: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("HttpPost error: " + ex.Message);
            }
        }

        // HÀM POST CÓ TOKEN
        public static  string HttpPostWithToken(string url, string token, string data)
        {
            try
            {
                using (var client = new System.Net.Http.HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    var content = new System.Net.Http.StringContent(data, Encoding.UTF8, "application/json");
                    var response = client.PostAsync(url, content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return  response.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        throw new Exception($"Error: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("HttpPostWithToken error: " + ex.Message);
            }
        }

    }
}
