using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using log4net;
using log4net.Config;

using TP_KP_DLS.Models;

namespace TP_KP_DLS.DAO
{
    public class Lecturer : DAO
    {
        public List<Book> Get_All_Books()
        {
            Connect();
            List<Book> BookList = new List<Book>();
            Log.For(this).Info("Showing books");
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Book", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book();
                    book.ID_Book = Convert.ToInt32(reader["ID_Book"]);
                    book.Book_Author_Surname = Convert.ToString(reader["Book_Author_Surname"]);
                    book.Book_Author_Name = Convert.ToString(reader["Book_Author_Name"]);
                    book.Book_Name = Convert.ToString(reader["Book_Name"]);
                    book.Book_Link = Convert.ToString(reader["Book_Link"]);
                    book.Book_ID_Subject = Convert.ToInt32(reader["Book_ID_Subject"]);
                    BookList.Add(book);
                }
                reader.Close();
            }
            catch (Exception) { }
            finally { Disconnect(); }
            return BookList;
        }

        public List<Subject> Get_All_Subject()
        {
            Connect();
            List<Subject> SubjectList = new List<Subject>();
            Log.For(this).Info("Showing subjects");
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Subject", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Subject subject = new Subject();
                    subject.ID_Subject = Convert.ToInt32(reader["ID_Subject"]);
                    subject.Subject_Name = Convert.ToString(reader["Subject_Name"]);
                    SubjectList.Add(subject);
                }
                reader.Close();
            }
            catch (Exception) { }
            finally { Disconnect(); }
            return SubjectList;
        }

        public bool Create_Subject(Subject subject)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(
                "INSERT INTO Subject(Subject_Name)" + "VALUES ( @Subject_Name)", Connection);
                cmd.Parameters.AddWithValue("@Subject_Name", subject.Subject_Name);
                cmd.ExecuteNonQuery();

            }
            catch (Exception) { result = false; }
            finally { Disconnect(); }
            return result;
        }

        public void Update_Subject(Subject subject)
        {
            try
            {
                Connect();
                string str = "UPDATE Subject SET Subject_Name = '" + subject.Subject_Name;
                SqlCommand com = new SqlCommand(str, Connection);
                com.ExecuteNonQuery();
            }
            finally
            {
                Disconnect();
            }
        }

        public void Delete_Subject(int ID_Subject)
        {
            try
            {
                Connect();
                string str = "DELETE FROM Subject WHERE ID_Subject=" + ID_Subject;
                SqlCommand com = new SqlCommand(str, Connection);
                com.ExecuteNonQuery();
            }
            finally
            {
                Disconnect();
            }
        }

        public bool Create_Book(Book book)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(
                "INSERT INTO Book(Book_Author_Surname, Book_Author_Name, Book_Name, Book_Link, Book_ID_Subject )" + "VALUES (@Book_Author_Surname, @Book_Author_Name, @Book_Name, @Book_Link, @Book_ID_Subject)", Connection );
                cmd.Parameters.AddWithValue("@Book_Author_Surname", book.Book_Author_Surname);
                cmd.Parameters.AddWithValue(" @Book_Author_Name", book.Book_Author_Name);
                cmd.Parameters.AddWithValue("@Book_Name", book.Book_Name);
                cmd.Parameters.AddWithValue("@Book_Link", book.Book_Link);
                cmd.Parameters.AddWithValue("@Book_ID_Subject", book.Book_ID_Subject);
                cmd.ExecuteNonQuery();

            }
            catch (Exception) { result = false; }
            finally { Disconnect(); }
            return result;
        }

        public void Update_Book(Book book)
        {
            try
            {
                Connect();
                string str = "UPDATE Book SET Book_Author_Surname = '" + book.Book_Author_Surname
                + "', Book_Author_Name = '" + book.Book_Author_Name
                + "', Book_Name = '" + book.Book_Name
                + "', Book_Link = '" + book.Book_Link
                + "', Book_ID_Subject = '" + book.Book_ID_Subject
                + "'WHERE ID_Book = " + book.ID_Book;
                SqlCommand com = new SqlCommand(str, Connection);
                com.ExecuteNonQuery();
            }
            finally
            {
                Disconnect();
            }
        }
        public void Delete_Book(int ID_Book)
        {
            try
            {
                Connect();
                string str = "DELETE FROM Book WHERE ID_Book=" + ID_Book;
                SqlCommand com = new SqlCommand(str, Connection);
                com.ExecuteNonQuery();
            }
            finally
            {
                Disconnect();
            }
        }
    }
}
