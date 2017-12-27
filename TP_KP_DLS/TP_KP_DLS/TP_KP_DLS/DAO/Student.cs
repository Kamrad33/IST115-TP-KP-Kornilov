using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using log4net;
using log4net.Config;
using TP_KP_DLS.Models;
using TP_KP_DLS.Controllers;

namespace TP_KP_DLS.DAO
{
    public class Student:DAO
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

        public List<Subject> Get_All_Subject( string Id)//(AccountController UserId)
        {
            
            Connect();
            List<Subject> SubjectList = new List<Subject>();
            Log.For(this).Info("Showing Subject");
            try
            {
                SqlCommand command = new SqlCommand("SELECT Subject_Name FROM Subject WHERE ID_Subject IN (SELECT Access_ID_Subject FROM  Access WHERE Access_ID_User ='" + Id +"')", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Subject subject = new Subject();
                                       
                    subject.Subject_Name = Convert.ToString(reader["Subject_Name"]);
                    
                    SubjectList.Add(subject);
                }
                reader.Close();
            }
            catch (Exception) { }
            finally { Disconnect(); }
            return SubjectList;
        }

        public List<Test> Get_All_Test(AccountController UserId)
        {
            Connect();
            List<Test> TestList = new List<Test>();
            Log.For(this).Info("Showing Test");
            try
            {
                SqlCommand command = new SqlCommand("SELECT Test_Name FROM Test WHERE (SELECT Subject_Name FROM Subject WHERE (SELECT Access_ID_Subject FROM  Access WHERE Access_ID_User ='"+ UserId +"'))", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Test test = new Test();

                    test.Test_Name = Convert.ToString(reader["Test_Name"]);

                    TestList.Add(test);
                }
                reader.Close();
            }
            catch (Exception) { }
            finally { Disconnect(); }
            return TestList;
        }
    }
}