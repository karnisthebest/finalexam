using System;


namespace test.Models{
    //step10: create data structure of cartview to be used by razor file
    public class CheckView{
        public int Id {get;set;}
        public string time {get;set;}  

        public DateTime hour {get;set;}
        public string licensePlate  {get;set;}

        public int count { get; set; }

    }//ec
}//en