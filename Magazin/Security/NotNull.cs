using Magazin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Magazin.Security
{
    public  class NotNull
    {
        public string errorMessage = "Introdu o valoare";
       

        public bool ifNotNull(Object input)
        { 
            if(input is null  or 0) {  return true; }
            
            return false;
        }
        public int securitLoghin(Admin ad)
        {
            int k = 0;
           if ( ifNotNull(ad.login))
            k = k + 1;
            if(ifNotNull(ad.password))
            k = k + 2;
            return k;
        }
        public string securitOrder(Order order)
        {
            string k = "";
            if (ifNotNull(order.User))
                k = k + "1" ;
            if (ifNotNull(order.Address))
                k = k + "2";
            if (ifNotNull(order.ContactPhone))
                k = k + "3";

            return k;
        }
        public string securitProdus(Produs produs)
        {
            string k = "";
            
            if (ifNotNull(produs.Name))
                k = k + "1";
            if (ifNotNull(produs.Company))
                k = k + "2";
            if (ifNotNull(produs.Favourite))
                k = k + "3";
            if (ifNotNull(produs.categoryID))
                k = k + "4";
            
            if (ifNotNull(produs.Desc))
                k = k + "6";
            if (produs.Price==0)
                k = k + "5";
            return k;

        }
    }
}
