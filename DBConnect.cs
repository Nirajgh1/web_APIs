
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebApplication1
{
    internal class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }
        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "connectcsharptomysql";
            uid = "root";
            password = "nirajlapi";

            string connectionstring;

            connectionstring = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionstring);
        }

        private bool Openconnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.Write("Cannot connect to server. Contact administrator");
                        break;
                    case 1045:
                        Console.Write("Invalid username/password, please try again");
                        break;

                }
                return false;
            }
        }
        private bool Closeconnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        public void InsertShop(int shopid,string shopname,int taxid,int ownerid)
        {
            string query = $"INSERT INTO shops(ShopID,Fname,TaxID,OwnerID)VALUES('{shopid}','{shopname}','{taxid}','{ownerid}')";
            //open connection
            if (Openconnection() == true)
            {
                //create command and assign query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //execute command
                cmd.ExecuteNonQuery();
                //close connection
                Closeconnection();
            }
        }
        public void InsertOwner(int ownerid,string oname,string email)
        {
            string query = $"INSERT INTO Owners(OwnerID,Fname,email)VALUES('{ownerid}','{oname}','{email}')";
            //open connection
            if (Openconnection() == true)
            {
                //create command and assign query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //execute command
                cmd.ExecuteNonQuery();
                //close connection
                Closeconnection();
            }
        }
        public void InsertShopLocation(int loID,int shoID,string name,string addres,float latt,float lngg)
        {
            string query = $"INSERT INTO shoplocations(LocID,shopID,Sname,address,lat,lng)VALUES('{loID}','{shoID}','{name}','{addres}','{latt}','{lngg}')";
            //open connection
            if (Openconnection() == true)
            {
                //create command and assign query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //execute command
                cmd.ExecuteNonQuery();
                //close connection
                Closeconnection();
            }
        }
        public int Update(int OwnID)
        {
            string query = $"UPDATE owners SET Fname='shourya' WHERE OwnerID='{OwnID}'";
            if (Openconnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
                Closeconnection();
            }
            return OwnID;
        }
        public int Delete(int ShopID)
        {
            string query = $"DELETE FROM shops WHERE ShopID='{ShopID}'";

            if (Openconnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                Closeconnection();
            }
            return ShopID;
        }
        public List<OwnerResult> Read()
        {
            List<OwnerResult> owner = new List<OwnerResult>();


            string query = "SELECT * from owners";
           if (Openconnection() == true)
           {
               MySqlCommand cmd = new MySqlCommand(query, connection);
               MySqlDataReader reader = cmd.ExecuteReader();
               while (reader.Read())
                {
                    
                  var ownerrow=new OwnerResult();
                    ownerrow.OwnerID = reader["OwnerID"].ToString();
                    ownerrow.OwnerName = reader["Fname"].ToString();
                    ownerrow.Email = reader["email"].ToString();

                    owner.Add(ownerrow);
                    /*Console.WriteLine(reader["Ownerid"]);
                    //Console.WriteLine(reader["shopID"]);
                    Console.WriteLine(reader["Fname"]);
                    Console.WriteLine(reader["email"]);
                    //Console.WriteLine(reader["distance"]);*/


                }
                reader.Close();
                Closeconnection();


            }

            return owner;
        }
        public List<ShopLocationsResults> ReadLocation()
        {
            List<ShopLocationsResults> locations = new List<ShopLocationsResults>();
            string query = "select * from shoplocations";
            if (Openconnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    var locationsrow = new ShopLocationsResults();
                    locationsrow.LOcId = reader["LocID"].ToString();
                    locationsrow.ShopsID = reader["ShopID"].ToString();
                    locationsrow.ShopsName = reader["Sname"].ToString();
                    locationsrow.addresss = reader["address"].ToString();
                    locationsrow.laat = reader["lat"].ToString();
                    locationsrow.lnng = reader["lng"].ToString();

                    locations.Add(locationsrow);
                }
            }
            return locations;
        }
    }
}

