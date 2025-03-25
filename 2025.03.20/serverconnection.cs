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
    public class serverconnection
    {
        HttpClient client = new HttpClient();
        string serverurl = "";
        public serverconnection(string serverurl)
        {
            this.serverurl = serverurl;
        }
        public async Task<bool> Login(string username,string password)
        {
            string url = serverurl + "/login";
            try
            {
                var jsoninfo = new
                {
                    loginPassword = password,
                    loginUsername = username
                };
                string jsonstringified = JsonConvert.SerializeObject(jsoninfo);
                HttpContent sendthis = new StringContent(jsonstringified, Encoding.UTF8, "Application/json");
                HttpResponseMessage response = await client.PostAsync(url, sendthis);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                jsondata data = JsonConvert.DeserializeObject<jsondata>(result);
                Token.token = data.token;
                return true;


            }
            catch (Exception e )
            {

                MessageBox.Show(e.Message);
            }
            return false;
        }
        public async Task<bool> Reg(string username, string password)
        {
            string url = serverurl + "/register";
            try
            {
                var jsoninfo = new
                {
                    registerPassword = password,
                    registerUsername = username
                };
                string jsonstringified = JsonConvert.SerializeObject(jsoninfo);
                HttpContent sendthis = new StringContent(jsonstringified, Encoding.UTF8, "Application/json");
                HttpResponseMessage response = await client.PostAsync(url, sendthis);
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
            string url = serverurl + "/profiles";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                all = JsonConvert.DeserializeObject<List<jsondata>>(result).Select(item => item.username).ToList();
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }
            return all;
        }
        public async Task<List<string>> Names()
        {
            List<string> allnames = new List<string>();
            string url = serverurl + "/allNames";
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
        public async Task<List<int>> Ages()
        {
            List<int> allages = new List<int>();
            string url = serverurl + "/allAges";
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();
                allages = JsonConvert.DeserializeObject<List<jsondata2cs>>(result).Select(item => item.age).ToList();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return allages;
        }
        public async Task<bool> Reg2(string name, int age)
        {
            string url = serverurl + "/createPerson";
            try
            {
                var jsoninfo = new
                {
                    createname = name,
                    createage = age
                };
                string jsonstringified = JsonConvert.SerializeObject(jsoninfo);
                HttpContent sendthis = new StringContent(jsonstringified, Encoding.UTF8, "Application/json");
                HttpResponseMessage response = await client.PostAsync(url, sendthis);
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
    }
}
