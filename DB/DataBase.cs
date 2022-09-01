using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyProject.DB
{
    public class DataBase
    {
       public MySqlConnection connection;
        
       // MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=users");

        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
            else
                Debug.WriteLine("База данных уже открыта");
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
            else
                Debug.WriteLine("База данных уже закрыта");
        }

        public DataBase()
        {
            connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=users");
            OpenConnection();
        }
        public MySqlConnection IsConnection()
        {

            return connection;
        }

        public static void AuthToLogin(string Login, string Password)
        {
            DataBase db = new DataBase();
            if (Login != null && Password != null)
            {
                
                DataTable table = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT Login, Password FROM users WHERE @log = Login AND  @pass = Password", db.IsConnection());
                SqlParameter nameParam = new SqlParameter("@log", Login);
                command.Parameters.Add("@log", MySqlDbType.VarChar).Value = Login;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = Password;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                    Debug.WriteLine("Всё чётко");
                else
                    Debug.WriteLine("Совпадений в бд нет");
            }
            else
                Debug.WriteLine("Не все поля заполнены");

            db.CloseConnection();
        }
        
        public static void RegiserUser(string Login, string Password, string PasswordRepeat, string FirstName, string LastName)
        {
            if (Login != null && Password != null && PasswordRepeat != null && FirstName != null && LastName != null)
            {
                if (Password == PasswordRepeat)
                {
                    DataBase db = new DataBase();
                    MySqlCommand command = new MySqlCommand("INSERT INTO users (Login, Password, FirstName, LastName) VALUES (@login, @password, @firstname, @lastname)", db.IsConnection());
                    command.Parameters.Add("@login", MySqlDbType.VarChar).Value = Login;
                    command.Parameters.Add("@password", MySqlDbType.VarChar).Value = Password;
                    command.Parameters.Add("@firstname", MySqlDbType.VarChar).Value = FirstName;
                    command.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = LastName;
                    
                    if (command.ExecuteNonQuery() > 0)
                        Debug.WriteLine("Регестрация успешна");
                    else
                        Debug.WriteLine("Аккаунт не создан");

                    db.CloseConnection();
                }
                else
                    Debug.WriteLine("Пароли не совпадают");
            }
            Debug.WriteLine("Не все поля заполнены");
        }
    }

}
