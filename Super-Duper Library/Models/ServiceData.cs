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
            try
            {
                myConnection.Open();
                SqlCommand getbookCommand = new SqlCommand("select B.*,A.name as Author,T.name as Type from books as B,authors as A,types as T where B.authorId = A.authorId and b.typeId = T.typeId", myConnection);
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

        public List<Authors> getAllAuthors()
        {
            List<Authors> authors = new List<Authors>();
            try
            {
                myConnection.Open();
                SqlCommand getauthorsCommand = new SqlCommand("select * from authors", myConnection);
                SqlDataReader myReader = getauthorsCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Authors author = new Authors();
                    author.AuthorId = Convert.ToInt32(myReader["authorId"]);
                    author.Name = myReader["name"].ToString();
                    author.Surname = myReader["surname"].ToString();
                    authors.Add(author);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                myConnection.Close();
            }
            return authors;
        }

        public List<Types> getAllBtypes()
        {
            List<Types> Type = new List<Types>();
            try
            {
                myConnection.Open();
                SqlCommand getTypeCommand = new SqlCommand("select * from types", myConnection);
                SqlDataReader myReader = getTypeCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Types types = new Types();
                    types.TypeId = Convert.ToInt32(myReader["authorId"]);
                    types.Name = myReader["name"].ToString();
                    
                    Type.Add(types);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                myConnection.Close();
            }
            return Type;
        }


    }
}