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
                    types.TypeId = Convert.ToInt32(myReader["typeId"]);
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

        //getborowsby id
        public List<Borrows> getBorrows(int id)
        {
            List<Borrows> borrows = new List<Borrows>();
            try
            {
                myConnection.Open();
                SqlCommand getborrCommand = new SqlCommand("select *, b.name from borrows, books as b where b.bookId =" + id + " and borrows.bookId =" + id + " order by takenDate desc", myConnection);
                SqlDataReader myReader = getborrCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Borrows Borrow = new Borrows();
                    Borrow.BorrowId = Convert.ToInt32(myReader["borrowId"]);
                    Borrow.BookId = Convert.ToInt32(myReader["bookId"]);
                    Borrow.StudentId = Convert.ToInt32(myReader["studentId"]);
                    Borrow.TakenDate = Convert.ToDateTime(myReader["takenDate"]);
                    Borrow.BroughtDate = Convert.ToDateTime(myReader["broughtDate"]);
                    Borrow.bookname = myReader["name"].ToString();

                    borrows.Add(Borrow);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                myConnection.Close();
            }
            return borrows;
        }

        public List<Borrows> getAllBorrows()
        {
            List<Borrows> borrows = new List<Borrows>();
            try
            {
                myConnection.Open();
                SqlCommand getborrCommand = new SqlCommand("select * borrows", myConnection);
                SqlDataReader myReader = getborrCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Borrows Borrow = new Borrows();
                    Borrow.BorrowId = Convert.ToInt32(myReader["borrowId"]);
                    Borrow.BookId = Convert.ToInt32(myReader["bookId"]);
                    Borrow.StudentId = Convert.ToInt32(myReader["studentId"]);
                    Borrow.TakenDate = Convert.ToDateTime(myReader["takenDate"]);
                    Borrow.BroughtDate = Convert.ToDateTime(myReader["broughtDate"]);

                    borrows.Add(Borrow);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                myConnection.Close();
            }
            return borrows;
        }

        public List<Students> getStudents()
        {
            List<Students> students = new List<Students>();
            try
            {
                myConnection.Open();
                SqlCommand getstuCommand = new SqlCommand("select * from students", myConnection);
                SqlDataReader myReader = getstuCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Students student = new Students();
                    student.StudentId = Convert.ToInt32(myReader["studentId"]);
                    student.Name = myReader["name"].ToString();
                    student.Surname = myReader["surname"].ToString();
                    student.Birthdate = Convert.ToDateTime(myReader["birthdate"]);
                    student.Gender = myReader["gender"].ToString();
                    student.Class = myReader["class"].ToString();
                    student.Point = Convert.ToInt32(myReader["point"]);

                    students.Add(student);
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                myConnection.Close();
            }
            return students;
        }


        public List<Books> getBooksbyName(string bookname)
        {
            /*List<Product> products = ListRepository.Products.Where(x =>
                   (x.Prices.Average(y => y.Price) >= min) && (x.Prices.Average(y => y.Price) <= max)
               ).ToList();*/

            //Books books = null;
            List<Books> wantedbook = getAllBooks();

            //var mybook = (from b in wantedbook where b.Name == bookname select b).ToList();

            if(bookname != null)
            {
                wantedbook = wantedbook.Where(s => s.Name.Contains(bookname)).ToList();
            }

            return wantedbook;
        }

        public List<Authors> getbyAuthor(string author)
        {
            //Books books = null;
            List<Authors> wantedauthor = getAllAuthors();

            //var mybook = (from a in wantedauthor where a.Name == author select a).ToList();

            if (author != null)
            {
                wantedauthor = wantedauthor.Where(b => b.Name.Contains(author)).ToList();
            }

            return wantedauthor;
        }

        public List<Types> getbyType(string type)
        {
            //Books books = null;
            List<Types> wantedtype = getAllBtypes();

            //var mybook = (from t in wantedtype where t.Name == type select t).ToList();

            if (wantedtype  != null)
            {
                wantedtype = wantedtype.Where(s => s.Name.Contains(type)).ToList();
            }

            return wantedtype;
        }

       


    }
}