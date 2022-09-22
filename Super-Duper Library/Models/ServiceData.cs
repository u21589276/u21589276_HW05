using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;


namespace Super_Duper_Library.Models
{
    public class ServiceData
    {
        private static ServiceData instance;
        SqlConnection myConnection = new SqlConnection("Data Source=cmsa\\tew_sqlexpress;Initial Catalog=Library;Integrated Security=True");

        public static ServiceData getInstance()
        {
            if (instance == null)
            {
                instance = new ServiceData();
            }
            return instance;
        }

        public List<Books> getAllBooks()
        {
            List<Books> bookData = new List<Books>();
            //TODO: Complete this
            try
            {
                myConnection.Open();
                SqlCommand getbookCommand = new SqlCommand("select * from books", myConnection);
                SqlDataReader myReader = getbookCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Books books = new Books();
                    books.BookId = Convert.ToInt32(myReader["bookId"]);
                    books.Name = myReader["name"].ToString();
                    books.Pagecount = Convert.ToInt32(myReader["pagecount"]);
                    books.Point = Convert.ToInt32(myReader["point"]);
                    books.AuthorId = Convert.ToInt32(myReader["authorId"]);
                    books.TypeId = Convert.ToInt32(myReader["typeId"]);


                    bookData.Add(books);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                myConnection.Close();
            }
            return bookData;
        }

    }
}