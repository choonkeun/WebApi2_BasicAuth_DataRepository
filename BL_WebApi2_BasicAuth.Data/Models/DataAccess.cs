using System;
using System.Data;
using System.Data.SqlClient;

namespace BL_WebApi2_BasicAuth.Data.Models
{
    public class DataAccess
    {
        //1. return DataTable
        public static DataTable GetDataTable(string conStr, SqlCommand cmd)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    cmd.Connection = con;
                    con.Open();
                    try
                    {
                        da.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                    }
                    return dt;
                }
            }
        }

        //2-1. Return value as int - ExecuteNonQuery: INSERT, UPDATE, DELETE
        public static int ExecuteCommand(string conStr, SqlCommand cmd)
        {
            int recordAffected = 0;
            string Identity = string.Empty;

            using (SqlConnection con = new SqlConnection(conStr))
            {
                try
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Transaction = con.BeginTransaction();

                    recordAffected = cmd.ExecuteNonQuery();        //The number of rows affected
                    if (recordAffected > 0)
                    {
                        Identity = recordAffected.ToString();
                        if (cmd.CommandText.ToLower().Contains("insert"))
                        {
                            cmd.CommandText = "Select @@Identity; ";
                            Identity = cmd.ExecuteScalar().ToString();
                        }
                    }

                    cmd.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    cmd.Transaction.Rollback();
                }
                finally
                {
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    con.Close();
                }
                return Convert.ToInt32(Identity);
            }
        }

        //2-2. Return value as string(Ex.Message) - ExecuteNonQuery: INSERT, UPDATE, DELETE
        public static string StringExecuteCommand(string conStr, SqlCommand cmd)
        {
            int recordAffected = 0;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                try
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Transaction = con.BeginTransaction();
                    recordAffected = cmd.ExecuteNonQuery();        //The number of rows affected
                    cmd.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    cmd.Transaction.Rollback();
                    return ex.Message;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    con.Close();
                }
                return recordAffected.ToString();
            }
        }

        //3. return DataSet
        public DataSet GetDataSet(string conStr, SqlCommand cmd)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                DataSet ds = new DataSet();
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    con.Open();
                    da.SelectCommand = cmd;
                    try
                    {
                        da.Fill(ds);
                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                    finally
                    {
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                    }
                    return ds;
                }
            }
        }

    }

}
