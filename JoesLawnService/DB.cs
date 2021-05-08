//Abhishek Sawant, 8683623
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace JoesLawnService
{
    class DB
    {
        const string CONNECTION_STRING = @"Server=.\SQLEXPRESS;Database=LawnService;Trusted_Connection=True;";
        const string INSERT_COMMAND = "INSERT INTO customers (name, postalCode, phone, lawn, type, date) " +
            "VALUES (@NAME, @POSTALCODE, @PHONE, @LAWN, @TYPE, @DATE)";
        const string UPDATE_COMMAND = "UPDATE customers " +
            "SET name = @NAME, postalCode = @POSTALCODE, phone = @PHONE, lawn = @LAWN, type = @TYPE, date = @DATE " +
            "WHERE name = @NAME";
        const string DELETE_COMMAND = "DELETE FROM customers WHERE name = @NAME";
        const string SELECT_COMMAND = "SELECT name, postalCode, phone, lawn, type, date FROM customers";
        const string SELECTNAME_COMMAND = "SELECT name FROM customers";
        const string SELECTPHONE_COMMAND = "SELECT phone FROM customers";
        const string SELECTPOSTAL_COMMAND = "SELECT postalCode FROM customers";
        const string SELECTLAWN_COMMAND = "SELECT lawn FROM customers";
        const string SELECTTYPE_COMMAND = "SELECT type FROM customers";
        const string SELECTDATE_COMMAND = "SELECT date FROM customers";

        private readonly SqlConnection conn;

        private static DB db;

        public static DB Instance { get { db ??= new DB(); return db; } }

        private DB()
        {
            conn = new SqlConnection(CONNECTION_STRING);
            conn.Open();
        }

        #region Methods
        public void Insert(Customer customer)
        {
            using SqlCommand cmd = new SqlCommand(INSERT_COMMAND, conn);
            cmd.Parameters.AddWithValue("@NAME", customer.Name);
            cmd.Parameters.AddWithValue("@POSTALCODE", customer.PostalCode);
            cmd.Parameters.AddWithValue("@PHONE", customer.Phone);
            cmd.Parameters.AddWithValue("@LAWN", customer.Lawn);
            cmd.Parameters.AddWithValue("@TYPE", customer.SelectedType);
            cmd.Parameters.AddWithValue("@DATE", customer.Date);
            cmd.ExecuteNonQuery();
        }

        public void Update(Customer customer)
        {
            using SqlCommand cmd = new SqlCommand(UPDATE_COMMAND, conn);
            cmd.Parameters.AddWithValue("@NAME", customer.Name);
            cmd.Parameters.AddWithValue("@POSTALCODE", customer.PostalCode);
            cmd.Parameters.AddWithValue("@PHONE", customer.Phone);
            cmd.Parameters.AddWithValue("@LAWN", customer.Lawn);
            cmd.Parameters.AddWithValue("@TYPE", customer.SelectedType);
            cmd.Parameters.AddWithValue("@DATE", customer.Date);
            cmd.ExecuteNonQuery();
        }

        public void Delete(Customer customer)
        {
            using SqlCommand cmd = new SqlCommand(DELETE_COMMAND, conn);
            cmd.Parameters.AddWithValue("name", customer.Name);
            cmd.ExecuteNonQuery();
        }

        public List<Customer> GetName()
        {
            List<Customer> customers = new List<Customer>();

            using SqlCommand cmd = new SqlCommand(SELECTNAME_COMMAND, conn);
            using SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
                customers.Add(new Customer
                {
                    Name = dr.GetString(dr.GetOrdinal("name"))
                });
            dr.Close();

            return customers;
        }

        public List<Customer> GetPostal()
        {
            List<Customer> customers = new List<Customer>();

            using SqlCommand cmd = new SqlCommand(SELECTPOSTAL_COMMAND, conn);
            using SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
                customers.Add(new Customer
                {
                    PostalCode = dr.GetString(dr.GetOrdinal("postalCode"))
                });
            dr.Close();

            return customers;
        }

        public List<Customer> GetPhone()
        {
            List<Customer> customers = new List<Customer>();

            using SqlCommand cmd = new SqlCommand(SELECTPHONE_COMMAND, conn);
            using SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
                customers.Add(new Customer
                {
                    Phone = dr.GetString(dr.GetOrdinal("phone"))
                });
            dr.Close();

            return customers;
        }

        public new List<Customer> GetType()
        {
            List<Customer> customers = new List<Customer>();

            using SqlCommand cmd = new SqlCommand(SELECTTYPE_COMMAND, conn);
            using SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
                customers.Add(new Customer
                {
                    SelectedType = dr.GetString(dr.GetOrdinal("type"))
                });
            dr.Close();

            return customers;
        }

        public List<Customer> GetDate()
        {
            List<Customer> customers = new List<Customer>();

            using SqlCommand cmd = new SqlCommand(SELECTDATE_COMMAND, conn);
            using SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
                customers.Add(new Customer
                {
                    Date = dr.GetString(dr.GetOrdinal("date"))
                });
            dr.Close();

            return customers;
        }

        public List<Customer> GetLawn()
        {
            List<Customer> customers = new List<Customer>();

            using SqlCommand cmd = new SqlCommand(SELECTLAWN_COMMAND, conn);
            using SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
                customers.Add(new Customer
                {
                    Lawn = dr.GetDecimal(dr.GetOrdinal("lawn"))
                });
            dr.Close();

            return customers;
        }

        public List<Customer> Get()
        {
            List<Customer> customers = new List<Customer>();

            using SqlCommand cmd = new SqlCommand(SELECT_COMMAND, conn);
            using SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
                customers.Add(new Customer
                {
                    Name = dr.GetString(dr.GetOrdinal("name")),
                    PostalCode = dr.GetString(dr.GetOrdinal("postalCode")),
                    Phone = dr.GetString(dr.GetOrdinal("phone")),
                    Lawn = dr.GetDecimal(dr.GetOrdinal("lawn")),
                    SelectedType = dr.GetString(dr.GetOrdinal("type")),
                    Date = dr.GetString(dr.GetOrdinal("date"))
                });
            dr.Close();

            return customers;
        }
        #endregion
    }
}
