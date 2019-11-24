﻿using System;
using Refit;

namespace ShoppingApp.app.catalog
{
    public static class NetworkService
    {
        public static IService service;

        public static IService GetApiService()
        {
            service = RestService.For<IService>("http://pastebin.com");
            return service;
        }

    }
}