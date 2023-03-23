using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDbExample.BusinessLogic
{
    public class MainManager
    {
        private MainManager()
        {
            products = new InsertProductsInCosmos();
        }

        private static readonly MainManager _Instance = new MainManager();
        public static MainManager Instance { get { return _Instance; } }

        public InsertProductsInCosmos products;

        public void Init()
        {
            products.CreatDbAndInsertData();
        }
    }
}
