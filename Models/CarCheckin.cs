using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using test.Models;

namespace test.Models{
    
    public class CarCheckin {

        [Key]
        public int checkinId {get;set;}
        public string checkinLicensePlate { get; set; }

        public DateTime checkinTime {get;set;}
        

        
    }//ec
}//en