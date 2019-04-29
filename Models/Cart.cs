using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using test.Models;

namespace test.Models{
    //step 9: crate Cart data structure that holde card id, created date, and one to many 
    //one cart -> many cartitems
    public class Cart {

        [Key]
        public int cartId {get;set;}
        public DateTime createdDate {get;set;}
        
        public List<CartItem> cartItems {get;set;} //FK to caritem table

        
    }//ec
}//en