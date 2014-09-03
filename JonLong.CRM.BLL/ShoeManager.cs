using JonLong.CRM.DAL;
using System.Collections.Generic;

namespace JonLong.CRM.BLL
{
    public class ShoeManager
    {
        protected ShoeManager() { }
        public static readonly ShoeManager Instance = new ShoeManager();

        public List<string> LoadShoeSize(string customerCode)
        {
            return ShoeDataProvider.LoadShoeSize(customerCode);
        }

        public Dictionary<string,string> LoadShoes(string customerCode)
        {
            return ShoeDataProvider.LoadShoes(customerCode);
        }

        public List<string> LoadShoeSizeByShoe(string customerCode, string shoe)
        {
            var list = ShoeDataProvider.LoadShoeSizeByShoe(shoe, customerCode);
            int count = 0;
            if (list == null)
            {
                count = 20;
            }
            else
            {
                count = 20 - list.Count;
            }

            for (int i = 0; i < count; i++)
            {
                list.Add(string.Empty);
            }
            return list;
        }
    }


}
