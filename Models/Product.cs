
using System;
using System.ComponentModel.DataAnnotations;
//step 5: create Product Model [productId, productName, productQty, productPrice,createdDate]
namespace test.Models{
    public class Product {
        //step 6: put key to denote the primary for the target field
        [Key]
        public int productId {get;set;}
    
        public string productName {get;set;}
        
        public int productQty {get;set;}
        public double productPrice {get;set;}
        public DateTime createdDate {get;set;}
        
      
 
    }//ec
}//en
