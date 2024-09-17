using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrabalhoFinal._4_Data
{
    public class InicalizadorBD
    {
        private const string ConnectionString = "Data Source=Filmax.db";
        public static void Inicializador()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS FILMES (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        NOME TEXT NOT NULL,
                        ANODECRIACAO INTEGER NOT NULL   
                    );";

                using (var command = new SQLiteCommand(commandoSQL, connection))
                {
                    command.ExecuteNonQuery();
                }
                commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS GENEROS (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        NOME TEXT NOT NULL,
                        CLASSIDADE INTEGER NOT NULL             
                    );";

                using (var command = new SQLiteCommand(commandoSQL, connection))
                {
                    command.ExecuteNonQuery();
                }
                commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS PESSOAS (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        NOME TEXT NOT NULL,
                        IDADE INTEGER NOT NULL,
                        CPF INTEGER NOT NULL
                    );";

                using (var command = new SQLiteCommand(commandoSQL, connection))
                {
                    command.ExecuteNonQuery();
                }


            }

        }
    }
}



