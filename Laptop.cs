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
    class Laptop
    {
        //create table Laptops(Brand_Name varchar (20),ScreenSize varchar (7),OS varchar (10),Ram int  ,Storage int,WebCam int,Processor varchar (20));
        string Name;
        string ScreenSize;
        string OS;
        int RAM;
        int Storage;
        int WebCam;
        string Processor;

        public void InsertIntoLaptop()
        {
            SqlConnection conn = new SqlConnection("Data Source=VivoBook\\SQLEXPRESS;Initial Catalog=Laptop;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            Console.WriteLine("How Many Entires You Want To Enter ?");
            int entry = int.Parse(Console.ReadLine());
            char c;
            int rows;
            do
            {
                Console.Clear();
                for (int i = 0; i < entry; i++)
                {
                    Console.WriteLine("Enter Name of Laptop Brand : ");
                    Name = Console.ReadLine();
                    Console.WriteLine("Enter Screen Size : ");
                    ScreenSize = Console.ReadLine();
                    Console.WriteLine("Enter Opreating System : ");
                    OS = Console.ReadLine();
                    Console.WriteLine("Enter RAM IN GB : ");
                    RAM = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Storage in GB : ");
                    Storage = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter WEBCAM in MP : ");
                    WebCam = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Processor Name : ");
                    Processor = Console.ReadLine();
                    cmd.CommandText = $"insert into Laptops values('{Name}', '{ScreenSize}', '{OS}', {RAM}, {Storage},{WebCam}, '{Processor}')";
                    cmd.CommandType = CommandType.Text;
                }
                rows = cmd.ExecuteNonQuery();
                Console.WriteLine("Do You Want TO Continue ? Press Y For Exit Press Any Key");
                c = char.Parse(Console.ReadLine());
            } while (c == 'Y' || c == 'y');

            //cmd.CommandText = $"insert into Laptops values('{Name}', '{ScreenSize}', '{OS}', {RAM}, {Storage},{WebCam}, '{Processor}')";
            //cmd.CommandType = CommandType.Text;
            // rows = cmd.ExecuteNonQuery();
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
