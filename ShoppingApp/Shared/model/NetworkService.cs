using Refit;

namespace ShoppingApp.app.model
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
