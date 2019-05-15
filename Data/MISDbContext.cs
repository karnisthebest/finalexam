//step5.1 import the following lib

using test.Models;//don't forget to put app2.Models to support
//you data model here
using Microsoft.EntityFrameworkCore;

namespace test.Data{

//step11 : create a new class that extends from DbContext
//the context will house the abstraction for three tables including products, carts,cartitems
 public class MISDbContext:DbContext{

        //Inject MISDBContext option in the constructor 
        public MISDbContext(DbContextOptions<MISDbContext> option) : base(option)
        {
        }

        //table connection 
        //create a meta data to support physical table 
        //step6: go ahead and create the Product Model file
        public DbSet<Product> products {get;set;}
        public DbSet<Cart> carts {get;set;}
        public DbSet<CartItem> cartItems {get;set;}

        public DbSet<CarCheckin> CarCheckins {get;set;}
        public DbSet<CarCheckOut> CarCheckOuts {get;set;}



 }//ec

}//en