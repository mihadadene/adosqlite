using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace adosqlite
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteConnection connection = new SQLiteConnection(@"Data Source=C:\Users\MedDev\source\repos\adosqlite\adosqlite\sqllitenorthwind.s3db");
            try
            {
                Console.WriteLine("Connection sur SQLite \n");
                connection.Open();

                //creer une requete
                string query = "SELECT categoryID, description from categories";

                //preparer l'execution de la requete
                SQLiteCommand sql = new SQLiteCommand(query, connection);

                //Recuperer le curseur
                SQLiteDataReader reader = sql.ExecuteReader();

                string description;
                int id;
                //Parcourrir le courseur
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader[0]);
                    description = (string)reader[1];
                    Console.WriteLine("Categorie: {0} \t Description: {1}", id, description);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
    }

