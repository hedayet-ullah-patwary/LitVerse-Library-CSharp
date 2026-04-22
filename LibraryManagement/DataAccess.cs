using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    internal class DataAccess : IDisposable
    {
        private SqlConnection sqlcon;
        public SqlConnection Sqlcon
        {
            get { return this.sqlcon; }
            set { this.sqlcon = value; }
        }

        private SqlCommand sqlcom;
        public SqlCommand Sqlcom
        {
            get { return this.sqlcom; }
            set { this.sqlcom = value; }
        }

        private SqlDataAdapter sda;
        public SqlDataAdapter Sda
        {
            get { return this.sda; }
            set { this.sda = value; }
        }

        private DataSet ds;
        public DataSet Ds
        {
            get { return this.ds; }
            set { this.ds = value; }
        }

        public DataAccess()
        {
            this.Sqlcon = new SqlConnection(@"Data Source=MSI;Initial Catalog=LibraryManagement;Persist Security Info=True;User ID=sa;Password=l197238");
            Sqlcon.Open();
        }

        private void QueryText(string query)
        {
            this.Sqlcom = new SqlCommand(query, this.Sqlcon);
        }

        public DataSet ExecuteQuery(string sql)
        {
            this.Sqlcom = new SqlCommand(sql, this.Sqlcon);
            this.Sda = new SqlDataAdapter(this.Sqlcom);
            this.Ds = new DataSet();
            this.Sda.Fill(this.Ds);
            return Ds;
        }

        public DataTable ExecuteQueryTable(string sql)
        {
            this.Sqlcom = new SqlCommand(sql, this.Sqlcon);
            this.Sda = new SqlDataAdapter(this.Sqlcom);
            this.Ds = new DataSet();
            this.Sda.Fill(this.Ds);
            return Ds.Tables[0];
        }

        public int ExecuteDMLQuery(string sql)
        {
            this.Sqlcom = new SqlCommand(sql, this.Sqlcon);
            int u = this.Sqlcom.ExecuteNonQuery();
            return u;
        }

        // ================================
        // IDisposable implementation start
        // ================================
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (this.Sqlcom != null)
                    {
                        this.Sqlcom.Dispose();
                        this.Sqlcom = null;
                    }

                    if (this.Sda != null)
                    {
                        this.Sda.Dispose();
                        this.Sda = null;
                    }

                    if (this.Sqlcon != null)
                    {
                        this.Sqlcon.Close();
                        this.Sqlcon.Dispose();
                        this.Sqlcon = null;
                    }

                    if (this.Ds != null)
                    {
                        this.Ds.Dispose();
                        this.Ds = null;
                    }
                }

                disposed = true;
            }
        }

        ~DataAccess()
        {
            Dispose(false);
        }
    }
}
