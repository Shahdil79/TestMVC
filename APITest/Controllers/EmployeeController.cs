using APITest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace APITest.Controllers
{
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        OfficeManagmentContext context = new OfficeManagmentContext();
        [HttpGet]
        public List<Employee> GetEmployees()
        {
            var lstEmployee =  context.Employee.ToList();
            return lstEmployee;
        }

        [HttpGet,Route("GetByName/{name}")]
        public List<Employee> GetEmployeeByName(string name)
        {
            var lstEmployee = context.Employee.Where(x => x.Name==name).ToList();
            return lstEmployee;
        }

        [HttpPost,Route("Create")]
        public Employee Create([FromBody]Employee employee)
        {
            var newEmployee = context.Employee.Add(employee);
            context.SaveChanges();
            return newEmployee;
        }
        [HttpGet,Route("GetUsers")]
        public object GetUsers()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("reqres.in/api");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage result = client.GetAsync("users?page=2").Result;
            string response = result.Content.ReadAsStringAsync().Result;
            var userList = JsonConvert.DeserializeObject<object>(response);
            return userList;
        }
    }
}
