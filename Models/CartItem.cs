//step6.1 create a new data model to support product
//step6.3 import the following lib->namespace below
using System;
using System.ComponentModel.DataAnnotations;

namespace test.Models{
    //step8: create cartitem data structure [cartItemId, productId, productQty, productPrice]
    //there is one reverse np to link this structure to Cart Object using cartId
    public class CartItem {
        
        [Key]
        public int cartItemId {get;set;}

        public string productId {get;set;}
      
        public int productQty {get;set;}

        public double productPrice {get;set;}
        
        //reverse NP
        public int cartId {get;set;} 
 
    }//ec
}//en
