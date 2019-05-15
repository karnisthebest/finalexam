using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using test.Models;

namespace test.Models{
   
    public class CarCheckOut {

        [Key]
        public int checkoutId {get;set;}
        public string checkoutLicensePlate { get; set; }
        public DateTime checkoutTime {get;set;}
        

        
    }//ec
}//en