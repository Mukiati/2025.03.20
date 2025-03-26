﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Windows;

namespace _2025._03._20
{
    public class serverConnection
    {
        HttpClient client = new HttpClient();
        string serverUrl = "";
        public serverConnection(string serverUrl)
        {
            this.serverUrl = serverUrl;
        }
        public async Task<bool> Login(string password, string username)
        {
            string url = serverUrl + "/login";
            try
            {
                var jsonInfo = new
                {
                    loginUsername = username,
                    loginPassword = password
                };
                string jsonStringified = JsonConvert.SerializeObject(jsonInfo);
                HttpContent sendThis = new StringContent(jsonStringified, Encoding.UTF8, "Application/json");
                HttpResponseMessage response = await client.PostAsync(url, sendThis);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                jsondata data = JsonConvert.DeserializeObject<jsondata>(result);
                Token.token = data.token;
                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }

            return false;
        }
        public async Task<bool> Register(string password, string username)
        {
            string url = serverUrl + "/register";
            try
            {
                var jsonInfo = new
                {
                    registerUsername = username,
                    registerPassword = password
                };
                string jsonStringified = JsonConvert.SerializeObject(jsonInfo);
                HttpContent sendThis = new StringContent(jsonStringified, Encoding.UTF8, "Application/json");
                HttpResponseMessage response = await client.PostAsync(url, sendThis);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                jsondata data = JsonConvert.DeserializeObject<jsondata>(result);
                Token.token = data.token;
                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }

            return false;
        }
        public async Task<List<string>> Profiles()
        {
            List<string> all = new List<string>();
            string url = serverUrl + "/profiles";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                all = JsonConvert.DeserializeObject<List<jsondata>>(result).Select(item => item.username).ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }

            return all;
        }

        public async Task<bool> createPerson(string name, int age)
        {
            string url = serverUrl + "/createPerson";
            try
            {
                var jsonInfo = new
                {
                    createName = name,
                    createAge = age
                };
                string jsonStringified = JsonConvert.SerializeObject(jsonInfo);
                HttpContent sendThis = new StringContent(jsonStringified, Encoding.UTF8, "Application/json");
                HttpResponseMessage response = await client.PostAsync(url, sendThis);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                jsondata data = JsonConvert.DeserializeObject<jsondata>(result);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return false;
        }

        public async Task<bool> deletePerson(string name)
        {
            string url = serverUrl + "/delPerson";
            try
            {
                var jsonInfo = new { name = name };
                string jsonStringified = JsonConvert.SerializeObject(jsonInfo);
                HttpContent sendThis = new StringContent(jsonStringified, Encoding.UTF8, "Application/json");
                HttpResponseMessage response = await client.PostAsync(url, sendThis);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                jsondata data = JsonConvert.DeserializeObject<jsondata>(result);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return false;
        }

        public async Task<List<string>> AllNames()
        {
            List<string> allnames = new List<string>();
            string url = serverUrl + "/allNames";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                allnames = JsonConvert.DeserializeObject<List<jsondata2cs>>(result).Select(item => item.name).ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
            return allnames;
        }
        public async Task<List<string>> AllAges()
        {
            List<string> allages = new List<string>();
            string url = serverUrl + "/allAges";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                allages = JsonConvert.DeserializeObject<List<jsondata2cs>>(result).Select(item => item.age.ToString()).ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }

            return allages;
        }

        public async Task<bool> deleteAllPerson()
        {
            string url = serverUrl + "/deleteAll";
            try
            {
                var jsonInfo = new { };
                string jsonStringified = JsonConvert.SerializeObject(jsonInfo);
                HttpContent sendThis = new StringContent(jsonStringified, Encoding.UTF8, "Application/json");
                HttpResponseMessage response = await client.PostAsync(url, sendThis);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                jsondata data = JsonConvert.DeserializeObject<jsondata>(result);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return false;
        }
        public async Task<bool> Upddate(string name,string oldnamee,int age)
        {
            string url = serverUrl + "/updatee";
            try
            {
                var jsonInfo = new
                {
                    name = name,
                    namee = name,
                    age = age
                };
                string jsonStringified = JsonConvert.SerializeObject(jsonInfo);
                HttpContent sendThis = new StringContent(jsonStringified, Encoding.UTF8, "Application/json");
                HttpResponseMessage response = await client.PutAsync(url, sendThis);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                jsondata2cs data = JsonConvert.DeserializeObject<jsondata2cs>(result);
                
                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }

            return false;
        }
    }
}
