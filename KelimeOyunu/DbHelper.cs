using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeOyunu
{
    class DbHelper
    {
        private static DbHelper instance;

        private DbHelper()
        {

        }

        private static void createInstance()
        {
            if (instance == null)
            {
                instance = new DbHelper();

            }
        }

        public static DbHelper GetDbHelper()
        {
            if (instance == null)
            {
                createInstance();
            }

            return instance;
        }

        SqlConnection sqlConnection =
            new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KelimeOyunu;Integrated Security=True");


        public async void save(AskQuestion askQuestion)
        {
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            string ask = askQuestion.ask;
            string word = askQuestion.word;
           
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText =
                $"INSERT INTO SoruKelime (soru,kelime) VALUES (@ask,@word)";
            
            sqlCommand.Parameters.AddWithValue("@ask", askQuestion.ask);
            sqlCommand.Parameters.AddWithValue("@word", askQuestion.word);
            
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            
        }

        public  List<AskQuestion> GetAllQuestion()
        {
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
          
            //sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("Select * from SoruKelime", sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            
            var asks = new List<AskQuestion>();
            while (reader.Read())
            {
              
                AskQuestion askQuestion = new AskQuestion();
                askQuestion.ask = reader["soru"].ToString();
                askQuestion.word = reader["kelime"].ToString();
         
                asks.Add(askQuestion);
            }
            reader.Close();
            
            return asks;

        }
    }
}
