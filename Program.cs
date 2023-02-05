using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConnectionsqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDatabase"].ConnectionString);
            string sql = "Select * from Users";

            Users newUser= new Users();
            Console.WriteLine("Enter firstname");
            newUser.Firstname= Console.ReadLine();
            Console.WriteLine("Enter lastname");
            newUser.Lastname= Console.ReadLine();
            Console.WriteLine("Enter phonenumber");
            newUser.Phonenumber= Console.ReadLine();
            Console.WriteLine("Enter email");
            newUser.Email= Console.ReadLine();

            var inserQuery = "INSERT INTO Users (Firstname,Lastname,Phonenumber,Email) VALUES ('" + newUser.Firstname + "','" + newUser.Lastname + "','" + newUser.Phonenumber + "','" + newUser.Email + "')";

            var insertResult = sqlConnectionsqlConnection.Execute(inserQuery);

            Console.WriteLine("New list of users");
            using (sqlConnectionsqlConnection)
            {
                sqlConnectionsqlConnection.Open();
                var usersList = (List<Users>)sqlConnectionsqlConnection.Query<Users>(sql);
                foreach (Users user in usersList) 
                {
                    Console.WriteLine(user.Firstname);
                }
                Console.ReadLine();
            }

        }
    }
}
