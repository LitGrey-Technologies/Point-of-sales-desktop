using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pos.App.Desktop.Abstracts
{
    public class Session
    {
        private static readonly List<NameValuePair> Collection = new List<NameValuePair>();

        public static void AddItem(string key, string value)
        {
            Collection.Add(new NameValuePair(key, value));
        }

        public static Task<NameValuePair> GetItem(string key)
        {
            var item = Task.Run(() => Collection.Find(m => m.Name == key));
            return item;
        }
    }
}
