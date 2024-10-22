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
                    CREATE TABLE IF NOT EXISTS AVALIACAOS (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        ConteudoId INTERGER NOT NULL,
                        PessoaId INTEGER NOT NULL,
                        Nota INTERGER NOT NULL,
                        Comentario TEXT NOT NULL
                    );";
          

                using (var command = new SQLiteCommand(commandoSQL, connection))
                {
                    command.ExecuteNonQuery();
                }
                commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS CONTEUDOS (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Titulo TEXT NOT NULL,
                        Descricao TEXT NOT NULL,
                        AnoLancamento INTERGER NOT NULL,
                        Genero TEXT NOT NULL,
                        Duracao INTERGER NOT NULL,
                       CategoriaId INTERGER NOT NULL
                    );";

                using (var command = new SQLiteCommand(commandoSQL, connection))
                {
                    command.ExecuteNonQuery();
                }
                commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS PESSOAS (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nome TEXT NOT NULL,
                        Idade INTEGER NOT NULL,
                        CPF INTEGER NOT NULL
                    );";

                using (var command = new SQLiteCommand(commandoSQL, connection))
                {
                    command.ExecuteNonQuery();
                }
                commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS ASSINATURAS (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        DataInicio TEXT NOT NULL,
                        DataFim TEXT NOT NULL,
                        Tipo TEXT NOT NULL,
                        Valor DECIMAL NOT NULL,
                        Pessoaid INTERGER NOT NULL
                       
                    );";

                using (var command = new SQLiteCommand(commandoSQL, connection))
                {
                    command.ExecuteNonQuery();
                }
                commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS CONTEUDOS (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Titulo TEXT NOT NULL,
                        Descricao TEXT NOT NULL,
                        AnoLancamento INTERGER  NOT NULL,
                        Genero TEXT NOT NULL,
                        Pessoaid INTERGER NOT NULL,
                        Duracao INTERGER NOT NULL,
                        CategoriaId INTERGER NOT NULL
                      
                    );";

                using (var command = new SQLiteCommand(commandoSQL, connection))
                {
                    command.ExecuteNonQuery();
                }
                commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS CATEGORIAS  (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Tipo TEXT NOT NULL,
                        Genero TEXT NOT NULL
                      
                    );";

                using (var command = new SQLiteCommand(commandoSQL, connection))
                {
                    command.ExecuteNonQuery();
                }
                commandoSQL = @"
                    CREATE TABLE IF NOT EXISTS LOGINS  (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Email TEXT NOT NULL,
                        Senha TEXT NOT NULL,
                        PessoaId INTETGER NOT NULL
                      
                    );";
                using (var command = new SQLiteCommand(commandoSQL, connection))
                {
                    command.ExecuteNonQuery();
                }


            }

        }
    }
}



