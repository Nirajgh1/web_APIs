using Microsoft.AspNetCore.Mvc;
using WebApplication1;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopsController : ControllerBase
    {
        
        [HttpPost("CreateShop")]
        public void CreateShop(int ShopID,string ShopName,int taxID,int OwnerID)
        {
            Console.WriteLine($"the shop with{ShopID} name{ShopName} is creteds{taxID}{OwnerID}");
            var dbconnect = new DBConnect();
            dbconnect.InsertShop(ShopID,ShopName,taxID,OwnerID);
        }
        [HttpPost("CreateLOcation")]
        public void CreateShopLocation(int locID,int shopID,string Sname,string address,float lat,float lng) 
        {
             var dbconnect = new DBConnect();
            dbconnect.InsertShopLocation( locID,  shopID, Sname,  address,  lat,  lng);
        
        }
        [HttpGet("GetLocations")]
        public List<ShopLocationsResults> GetShopLocation() 
        { 
          var dbconnect=new DBConnect();
            var locfromdb=dbconnect.ReadLocation();
            return locfromdb;
        }

        [HttpPost("CreateOwner")]
        public void InsertOwner(int OwnerID,string OName,string email) 
        {
            Console.WriteLine($"new owner is added {OwnerID} wit name {OName}");
            var dbconnect2=new DBConnect();
            dbconnect2.InsertOwner(OwnerID,OName,email);
        }
        [HttpGet]
        public List<OwnerResult> GetOwners() 
        { 
          var dbconnect = new DBConnect();
           var ownersFromDb = dbconnect.Read();
            return ownersFromDb;
        }

        [HttpPut("upOwner")]
        public int updateOwner(int owID) {
            var dbconnect = new DBConnect();
            var upfromdb=dbconnect.Update(owID);


            return owID;
        }
        [HttpDelete("deleteshop")]
        public int deleteShop(int shopID)
        {
            var dbconnect=new DBConnect();
            var delfromdb=dbconnect.Delete(shopID);
            return delfromdb;
        }   


    }
}
