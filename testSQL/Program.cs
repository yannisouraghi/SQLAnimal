using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
//instancier un objet en fonction d'un string
namespace testSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=Animals;Integrated Security=SSPI;MultipleActiveResultSets=true");
            conn.Open();
            Console.WriteLine("ServerVersion: {0}", conn.ServerVersion);
            Console.WriteLine("State: {0}", conn.State);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ \n");
            Console.WriteLine("Saisir un animal : \n");
            string animal = Console.ReadLine();
            Console.WriteLine("\n");
            Console.WriteLine("Saisir une rareté : \n");
            string rarete = Console.ReadLine();
            Console.WriteLine("\n");
            string query = "SELECT * FROM Animaux";
            string query2 = "INSERT INTO Animaux(nom, rarete) VALUES ('" + animal+"', '"+rarete+"')";
            SqlCommand insert = new SqlCommand(query2, conn);
            insert.ExecuteReader();
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["id"].ToString() + " "+ reader["nom"].ToString() + " " + reader["rarete"].ToString());
                Thread.Sleep(500);
            }
            conn.Close();
        }
    }
}
