﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Providers
{
    public class ServicesProvider<TInterface> : IServicesProvider<TInterface>
    {
        private IHttpContextAccessor _httpContextAccessor;

        public ServicesProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public TInterface GetInstance(string key)
        {
            var func = (Func<string, TInterface>)_httpContextAccessor.HttpContext.RequestServices.GetService(typeof(Func<string, TInterface>));
            return func(key);
        }
    }
}
