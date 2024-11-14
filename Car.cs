using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;


namespace DEMO1
{
    class Car
    {
        string RegisNo;
        string Name;
        int Model;
        string color;
        string FuleType;
        int Seatingcapacity;

        public void InsertIntoTable()
        {
            SqlConnection conn = new SqlConnection("Data Source=VivoBook\\SQLEXPRESS;Initial Catalog=Car;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
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
                    Console.WriteLine("Enter Registration Number : ");
                    RegisNo = Console.ReadLine();
                    Console.WriteLine("Enter Name : ");
                    Name = Console.ReadLine();
                    Console.WriteLine("Enter MODEL : ");
                    Model = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Colour : ");
                    color = Console.ReadLine();
                    Console.WriteLine("Enter Fule Type : ");
                    FuleType = Console.ReadLine();
                    Console.WriteLine("Enter Seating Capacity : ");
                    Seatingcapacity = int.Parse(Console.ReadLine());
                    cmd.CommandText = $"insert into Cars values('{RegisNo}', '{Name}', {Model}, '{color}', '{FuleType}', {Seatingcapacity})";
                    cmd.CommandType = CommandType.Text;

                }
                Console.WriteLine("Do You Want TO Continue ? Press Y For Exit Press Any Key");
                c = char.Parse(Console.ReadLine());

            } while (c == 'Y' || c == 'y');

            int rows=cmd.ExecuteNonQuery();
            if(rows>0)
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
