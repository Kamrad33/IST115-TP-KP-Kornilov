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
    public class Administrator:DAO
    {

        public List<User> Get_All_User()
        {
            Connect();
            List<User> UserList = new List<User>();          
            Log.For(this).Info("Showing users");
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM AspNetUsers", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.Id = Convert.ToString(reader["Id"]);
                    user.Email = Convert.ToString(reader["Email"]);
                    user.PasswordHash = Convert.ToString(reader["PasswordHash"]);
                    user.SecurityStamp = Convert.ToString(reader["SecurityStamp"]);
                    user.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
                    user.UserName = Convert.ToString(reader["UserName"]);
                    user.UserRealName = Convert.ToString(reader["UserRealName"]);
                    user.UserRealSurname = Convert.ToString(reader["UserRealSurname"]);
                    user.UserRealPatronymic = Convert.ToString(reader["UserRealPatronymic"]);
                    UserList.Add(user);
                }
                reader.Close();
            }
            catch (Exception) { }
            finally { Disconnect(); }
            return UserList;
        }

        public List<UserRole> Get_All_User_Role()
        {
            Connect();
            List<UserRole> UserRoleList = new List<UserRole>();
            Log.For(this).Info("Showing user roles");
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM AspNetUserRoles", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    UserRole userrole = new UserRole();
                    userrole.UserId = Convert.ToString(reader["UserId"]);
                    userrole.RoleId = Convert.ToString(reader["RoleId"]);
                    
                    UserRoleList.Add(userrole);
                }
                reader.Close();
            }
            catch (Exception) { }
            finally { Disconnect(); }
            return UserRoleList;
        }

        public List<Role> Get_All_Role()
        {
            Connect();
            List<Role> RoleList = new List<Role>();
            Log.For(this).Info("Showing roles");
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM AspNetRoles", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Role role = new Role();
                    role.Id = Convert.ToString(reader["Id"]);
                    role.Name = Convert.ToString(reader["Name"]);

                    RoleList.Add(role);
                }
                reader.Close();
            }
            catch (Exception) { }
            finally { Disconnect(); }
            return RoleList;
        }
        public List<Student_Group> Get_All_Student_Group()
        {
            Connect();
            List<Student_Group> GroupList = new List<Student_Group>();
            Log.For(this).Info("Showing roles");
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Student_Group", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Student_Group group = new Student_Group();
                    group.ID_Student_Group = Convert.ToInt32(reader["ID_Student_Group"]);
                    group.Student_Group_Name = Convert.ToString(reader["Student_Group_Name"]);
                    group.Student_Group_Number = Convert.ToInt32(reader["Student_Group_Number"]);
                    GroupList.Add(group);
                }
                reader.Close();
            }
            catch (Exception) { }
            finally { Disconnect(); }
            return GroupList;
        }

        public bool Create_User_Role(UserRole userrole)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(
                "INSERT INTO AspNetUserRoles ( UserId, RoleId )" + " VALUES ( @UserId, @RoleId )", Connection);
                cmd.Parameters.AddWithValue("UserId", userrole.UserId);
                cmd.Parameters.AddWithValue("RoleId", userrole.RoleId);
                cmd.ExecuteNonQuery();

            }
            catch (Exception) { result = false; }
            finally { Disconnect(); }
            return result;
        }

        public bool Create_Role(Role role)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(
                "INSERT INTO AspNetRoles (Id, Name )" + "VALUES (@Id, @Name)", Connection);
                cmd.Parameters.AddWithValue("Id", role.Id);
                cmd.Parameters.AddWithValue("Name", role.Name);              
                cmd.ExecuteNonQuery();

            }
            catch (Exception) { result = false; }
            finally { Disconnect(); }
            return result;
        }

        public void Update_User(User user)
        {
            try
            {
                Connect();
                string str = "UPDATE AspNetUsers SET PhoneNumber = '" + user.PhoneNumber
                + "', UserRealName = '" + user.UserRealName            
                + "', UserRealSurname = '" + user.UserRealSurname
                + "', UserRealPatronymic = '" + user.UserRealPatronymic
                + "' WHERE Id = '" + user.Id + "'";
                SqlCommand com = new SqlCommand(str, Connection);
                com.ExecuteNonQuery();
            }
            finally
            {
                Disconnect();
            }
        }

        public void Update_User_Role(UserRole userrole)
        {
            try
            {
                Connect();
                string str = "UPDATE AspNetUserRoles SET UserId = '" + userrole.UserId
                + "', RoleId = '" + userrole.RoleId
                + "' WHERE UserId = '" + userrole.UserId + "'";
                SqlCommand com = new SqlCommand(str, Connection);
                com.ExecuteNonQuery();
            }
            finally
            {
                Disconnect();
            }
        }

        public void Update_Role(Role role)
        {
            try
            {
                Connect();
                string str = "UPDATE AspNetRoles SET Id = '" + role.Id
                + "', Name = '" + role.Name
                + "' WHERE Id = '" + role.Id + "'";
                SqlCommand com = new SqlCommand(str, Connection);
                com.ExecuteNonQuery();
            }
            finally
            {
                Disconnect();
            }
        }
        public void Delete_User(string Id)
        {
            try
            {
                Connect();
                string str = "DELETE   FROM  AspNetUsers WHERE Id='" + Id + "'";
                SqlCommand com = new SqlCommand(str, Connection);
                com.ExecuteNonQuery();
            }
            finally
            {
                Disconnect();
            }
        }

        public void Delete_User_Role(string Id)
        {
            try
            {
                Connect();
                string str = "DELETE FROM AspNetUserRoles WHERE UserId='" + Id + "'";


                SqlCommand com = new SqlCommand(str, Connection);
                com.ExecuteNonQuery();
            }
            finally
            {
                Disconnect();
            }
        }

        public void Delete_Role(string Id)
        {
            try
            {
                Connect();
                string str = "DELETE FROM AspNetRoles WHERE AspNetRoles.Id='" + Id + "'";
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
    
