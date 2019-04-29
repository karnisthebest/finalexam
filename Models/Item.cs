 
using System;
using System.ComponentModel.DataAnnotations;
//step 31: Data structure to support cart Item from client side
namespace test.Models{
    public class Item {
        //step 6.2: put key to denote the primary for the target field

        public string productId {get;set;}
      
        public int productQty {get;set;}

        public double productPrice {get;set;}
      
 
    }//ec
}//en
