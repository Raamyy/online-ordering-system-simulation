﻿using System.Collections.Generic;
using System.Data.SqlClient;

namespace SQLCommunications
{
    public static class CommBase
    {
        public static bool IsIntialized = false;
        public static SqlConnection connection = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\\OOSDB.mdf;Integrated Security = True");
        public static void Intialize()
        {
            connection.Open();
            IsIntialized = true;
        }
        public static void ShutDown()
        {
            connection.Close();
            IsIntialized = false;
        }
    }
    public static class Transmitter
    {
        static SqlCommand command = new SqlCommand();
        public static void InsertIntoTable(params ItemDisc[] id)
        {
            if (!CommBase.IsIntialized)
            {
                CommBase.Intialize();
            }
            command.Connection = CommBase.connection;
            ItemDisc[] Items = Receiver.ReadFromProduct("SELECT * FROM Product");
            foreach (ItemDisc i in id)
            {
                bool FoundDublicate = false;
                foreach (ItemDisc j in Items)
                {
                    if (i.name == j.name)
                    {
                        FoundDublicate = true;
                        ExecuteNoReturn("UPDATE Product SET quantity = quantity + " + i.Quantity + " WHERE id = " + i.ID);
                        break;
                    }
                }
                if (!FoundDublicate)
                {
                    command.CommandText = "INSERT INTO Product (name , price , quantity , type) Values('" + i.name + "', " + i.price + ", " + i.Quantity + ", '" + i.Type + "')";
                    command.ExecuteNonQuery();
                }
            }
        }
        public static bool RegisterUser(User user)
        {
            if (!CommBase.IsIntialized)
            {
                CommBase.Intialize();
            }
            command.Connection = CommBase.connection;
            User[] AllUsers = Receiver.ReadFromAccounts("SELECT * FROM Accounts");
            foreach (User i in AllUsers)
            {
                if (i.Username == user.Username)
                {
                    return false;
                }
            }
            command.CommandText = "INSERT INTO Accounts Values('" + user.Username + "','" + user.Password + "')";
            command.ExecuteNonQuery();
            return true;
        }
        public static void ExecuteNoReturn(string Query)
        {
            if (!CommBase.IsIntialized)
            {
                CommBase.Intialize();
            }
            command.Connection = CommBase.connection;
            command.CommandText = Query;
            command.ExecuteNonQuery();
        }
    }
    public static class Receiver
    {
        static SqlCommand command = new SqlCommand();
        static SqlDataReader reader;
        public static ItemDisc[] ReadFromProduct(string Query)
        {
            if (!CommBase.IsIntialized)
            {
                CommBase.Intialize();
            }
            command.Connection = CommBase.connection;
            command.CommandText = Query;
            reader = command.ExecuteReader();
            List<ItemDisc> IDlist = new List<ItemDisc>();
            while (reader.Read())
            {
                ItemDisc i;
                i.ID = (int)reader["id"];
                i.name = (string)reader["name"];
                i.price = (float)reader["price"];
                i.Quantity = (int)reader["quantity"];
                i.Type = (string)reader["type"];
                IDlist.Add(i);
            }
            return IDlist.ToArray();
        }
        public static User[] ReadFromAccounts(string Query)
        {
            if (!CommBase.IsIntialized)
            {
                CommBase.Intialize();
            }
            command.Connection = CommBase.connection;
            command.CommandText = Query;
            reader = command.ExecuteReader();
            List<User> Userlist = new List<User>();
            while (reader.Read())
            {
                User i;
                i.ID = (int)reader["id"];
                i.Username = (string)reader["username"];
                i.Password = (string)reader["password"];
                Userlist.Add(i);
            }
            return Userlist.ToArray();
        }
    }
}