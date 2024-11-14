using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace DEMO1
{
    class Mobile
    {
        //create table Mobiles(Brand_Name varchar (20),Screen_Size_INCH varchar (7),OS varchar (10),Ram_In_GB int  ,Storage_In_GB int,Camera_in_MP int,Conectivity varchar (5));
        string Name;
        string ScreenSize;
        string OS;
        int RAM;
        int Storage;
        int Camera;
        string Connectivity;

        public void InsertIntoMobile()
        {
            SqlConnection conn = new SqlConnection("Data Source=VivoBook\\SQLEXPRESS;Initial Catalog=Mobile;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            Console.WriteLine("How Many Entires You Want To Enter ?");
            int entry = int.Parse(Console.ReadLine());
            char c;
            do
            {
                Console.Clear();
                for (int i = 0; i < entry; i++)
                {
                    Console.WriteLine("Enter Name of Mobile Brand : ");
                    Name = Console.ReadLine();
                    Console.WriteLine("Enter Screen Size : ");
                    ScreenSize = Console.ReadLine();
                    Console.WriteLine("Enter Opreating System : ");
                    OS = Console.ReadLine();
                    Console.WriteLine("Enter RAM IN GB : ");
                    RAM = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Storage in GB : ");
                    Storage = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Camera in MP : ");
                    Camera = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Connectivity As 4G/5G : ");
                    Connectivity = Console.ReadLine();

                    cmd.CommandText = $"insert into Mobiles values('{Name}', '{ScreenSize}', '{OS}', {RAM}, {Storage},{Camera}, '{Connectivity}')";
                    cmd.CommandType = CommandType.Text;

                }
                Console.WriteLine("Do You Want TO Continue ? Press Y For Exit Press Any Key");
                c = char.Parse(Console.ReadLine());
            } while (c == 'Y' || c == 'y');
            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                Console.WriteLine($"Successfully Inserted Data {rows} Rows Affected ...");
            }
            else
            {
                Console.WriteLine("SomeThing Gone Wrong!!! Insertion of Data is Unsuccessfull . Please Check Your Data !!!");
            }
        }
    }
}
