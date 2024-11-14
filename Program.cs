
using System.Data;

using Microsoft.Data.SqlClient;

namespace DEMO1
{
    class Demo
    {
        public void SelectOpreation()
        {
            SqlConnection con = new SqlConnection(); //step 1

            con.ConnectionString = "Data Source = VivoBook\\SQLEXPRESS; Initial Catalog = demo; Integrated Security = True; Connect Timeout = 30; Encrypt = True; Trust Server Certificate = True; Application Intent = ReadWrite; Multi Subnet Failover = False";
            con.Open();                             // step 2

            SqlCommand cmd = new SqlCommand();      //step 3
            cmd.Connection = con;                   //step 4
            cmd.CommandText = "select * from empl"; //step 5
            cmd.CommandType = CommandType.Text;
            SqlDataReader rdr = cmd.ExecuteReader();
            while(rdr.Read())
            {
                Console.WriteLine(rdr[0].ToString() + " " + rdr[1].ToString());
            }
            con.Close();
        }
        
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            //Demo cr1 = new Demo();
            //cr1.SelectOpreation();
            //Car car= new Car();
            //car.InsertIntoTable();

            Laptop laptop = new Laptop();
            laptop.InsertIntoLaptop();

        }
    }
}
