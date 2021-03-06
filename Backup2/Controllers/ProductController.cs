﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
//using System.Web.Http.Cors;
using DataAccess.DAL;
using Newtonsoft.Json;

namespace SimplyFindWebAPI.Controllers
{
    public class ProductController : ApiController
    {
        private ProductLocationDAL _dal = new ProductLocationDAL();

        // GET api/product/5
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(_dal.GetProductLocations(id));
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}