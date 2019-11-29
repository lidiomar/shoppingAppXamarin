using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ShoppingApp.app.model.catalog;
using SQLite;

namespace ShoppingApp.app.db
{
    public class AppDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public static readonly string dbName = "Shopping.db3";
        readonly string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbName);

        public AppDatabase()
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Category>().Wait();
            //_database.CreateTableAsync<Sale>().Wait();
            _database.CreateTableAsync<Product>().Wait();
        }

        /************ Categories*/

        public Task<List<Category>> GetCategoriesAsync()
        {
            return _database.Table<Category>().ToListAsync();
        }

        public Task<Category> GetCategoryAsync(int id)
        {
            return _database.Table<Category>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveCategoryAsync(Category category)
        {
            Task<int> task = _database.InsertAsync(category);
            return task;
        }

        /************ Products*/

        public Task<List<Product>> GetProductsAsync()
        {
            return _database.Table<Product>().ToListAsync();
        }

        public Task<Product> GetProductAsync(int id)
        {
            return _database.Table<Product>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<List<Product>> GetProductsByCategoryAsync(string categoryId)
        {
            return _database.Table<Product>()
                            .Where(i => i.Category.Equals(categoryId))
                            .ToListAsync();
        }

        public Task<int> SaveProductAsync(Product product)
        {
            return _database.InsertAsync(product);
        }

        public Task<int> UpdateProductAsync(Product product)
        {
            return _database.UpdateAsync(product);
        }

        /************ Sale*/

        /*public Task<List<Sale>> GetSalesAsync()
        {
            return _database.Table<Sale>().ToListAsync();
        }

        public Task<Sale> GetSaleAsync(string id)
        {
            return _database.Table<Sale>()
                            .Where(i => i.Category.Equals(id))
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveSaleAsync(Sale sale)
        {
            return _database.InsertAsync(sale);
        }*/
    }
}
