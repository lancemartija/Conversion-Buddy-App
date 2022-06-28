using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using conversion_buddy_app.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace conversion_buddy_app
{
    public class NotesRepository
    {
        readonly SQLiteAsyncConnection conn;
        public string StatusMessage { get; set; }

        public NotesRepository(string DbPath)
        {
            conn = new SQLiteAsyncConnection(DbPath);
            conn.CreateTableAsync<Items>().Wait();
        }

        public async Task AddNewNotesAsync(string item)
        {
            int result;

            try
            {
                if (string.IsNullOrEmpty(item))
                    throw new Exception("Valid item required");

                result = await conn.InsertAsync(new Items { Item = item });
                StatusMessage = string.Format("{0} record(s) added [Item: {1})", result, item);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", item, ex.Message);
            }
        }

        public async Task DeleteNotesAsync(object sender, EventArgs e)
        {
            Frame btn = sender as Frame;
            int id = int.Parse(btn.BindingContext.ToString());
            int result;

            try
            {
                result = await conn.DeleteAsync(new Items { Id = id });
                StatusMessage = string.Format("{0} record(s) deleted [Item: {1})", result, id);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete {0}. Error: {1}", id, ex.Message);
            }
        }

        public async Task<List<Items>> GetAllItemsAsync()
        {
            try
            {
                return await conn.Table<Items>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Items>();
        }
    }
}
