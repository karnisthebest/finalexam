using System;

namespace test.Models{
    //step10: create data structure of cartview to be used by razor file
    public class CartView{
        public int Id {get;set;}
        public DateTime date {get;set;}  
        public double total  {get;set;}
    }//ec
}//en