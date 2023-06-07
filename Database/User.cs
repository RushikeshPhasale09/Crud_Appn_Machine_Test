using CRUD_Application.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUD_Application.Database
{
    public class User
    {
        private SqlConnection con;
        string connectionstring = "";

        public User()
        {
            connectionstring = ConfigurationManager.ConnectionStrings["CRUDConnectionstring"].ConnectionString;
        }
        public string insertproductdtls(Product pdtls)
        {
            string result = "Failed";
            try
            {
                con = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand("AddProductDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pid", pdtls.ProductId);
                cmd.Parameters.AddWithValue("@pname", pdtls.ProductName);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i >= 1)
                {
                    result = "Success";
                }
                else
                {
                    result = "Failed";
                }
                return result;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.Close();
            }

        }

        public List<Productinq> getproductdtls()
        {
            Productinq output = null;
            List<Productinq> inqlist = new List<Productinq>();


            DataSet objDataSet;
            SqlDataAdapter sda;
            try
            {
                con = new SqlConnection(connectionstring);
                con.Open();
                string strquerry = "select * from ProductDetailsTbl";

                SqlCommand command = new SqlCommand(strquerry, con);
                objDataSet = new DataSet();


                sda = new SqlDataAdapter(command);
                sda.Fill(objDataSet);
                if (objDataSet.Tables.Count > 0)
                {
                    if (objDataSet.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                        {
                            output = new Productinq();
                            output.ProductId = objDataSet.Tables[0].Rows[i]["ProductId"].ToString();
                            output.ProductName = objDataSet.Tables[0].Rows[i]["ProductName"].ToString();

                            inqlist.Add(output);
                        }

                    }
                }
                return inqlist;
            }
            catch (Exception ex)
            {
                return inqlist;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public string deleteproductdtls(int id)
        {
            string result = "Failed";
            try
            {
                con = new SqlConnection(connectionstring);
                con.Open();
                string strquery1 = "DELETE  FROM CategoryDetailsTbl WHERE ProductId  = '" + id + "' ";
                string strquery2 = "DELETE  FROM ProductDetailsTbl WHERE ProductId  = '" + id + "' ";
                SqlCommand cmd1 = new SqlCommand(strquery1, con);
                SqlCommand cmd2 = new SqlCommand(strquery2, con);

                var data1 = cmd1.ExecuteNonQuery();
                var data2 = cmd2.ExecuteNonQuery();
                if (data2 == 1)
                {

                    result = "Success";
                    return result;
                }

            }
            catch (Exception ex)
            {
                return result;
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        public string updateproductdtls(Product pdtupdate)
        {
            string result = "Failed";
            try
            {
                con = new SqlConnection(connectionstring);
                con.Open();
                string strquery1 = "Update  ProductDetailsTbl set ProductName = '" + pdtupdate.ProductName + "' WHERE ProductId  = '" + pdtupdate.ProductId + "' ";
                SqlCommand cmd1 = new SqlCommand(strquery1, con);

                var data1 = cmd1.ExecuteNonQuery();
                if (data1 == 1)
                {

                    result = "Success";
                    return result;
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                return result;
            }
            finally
            {
                con.Close();
            }
            return result;
        }


        public string Insertcatdtls(Category insertdtls)
        {

            {
                string result = "Failed";
                try
                {
                    con = new SqlConnection(connectionstring);
                    SqlCommand cmd = new SqlCommand("AddCategoryDtls", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prid", insertdtls.ProductId);
                    cmd.Parameters.AddWithValue("@cid", insertdtls.CategoryId);
                    cmd.Parameters.AddWithValue("@cname", insertdtls.CategoryName);

                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i >= 1)
                    {
                        result = "Success";
                    }
                    else
                    {
                        result = "Failed";
                    }
                    return result;



                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    con.Close();
                }

            }

        }

        public List<Productinq> Getcatdata()

        {
            Productinq output = null;
            List<Productinq> inqlist = new List<Productinq>();


            DataSet objDataSet;
            SqlDataAdapter sda;
            try
            {
                con = new SqlConnection(connectionstring);
                con.Open();
                string strquerry = "select * from CategoryDetailsTbl";

                SqlCommand command = new SqlCommand(strquerry, con);
                objDataSet = new DataSet();


                sda = new SqlDataAdapter(command);
                sda.Fill(objDataSet);
                if (objDataSet.Tables.Count > 0)
                {
                    if (objDataSet.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                        {
                            output = new Productinq();
                            output.ProductId = objDataSet.Tables[0].Rows[i]["ProductId"].ToString();
                            output.CategoryId = objDataSet.Tables[0].Rows[i]["CategoryId"].ToString();
                            output.CategoryName = objDataSet.Tables[0].Rows[i]["CategoryName"].ToString();

                            inqlist.Add(output);
                        }

                    }
                }
                return inqlist;
            }
            catch (Exception ex)
            {
                return inqlist;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public string Deletecatdata(int id)


        {
            string result = "Failed";
            try
            {
                con = new SqlConnection(connectionstring);
                con.Open();
                string strquery1 = "DELETE  FROM CategoryDetailsTbl WHERE ProductId  = '" + id + "' ";
                SqlCommand cmd1 = new SqlCommand(strquery1, con);

                var data1 = cmd1.ExecuteNonQuery();
                if (data1 == 1)
                {

                    result = "Success";
                    return result;
                }

            }
            catch (Exception ex)
            {
                return result;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public string editcategorydata(Category catupdate)
        {
            string result = "Failed";
            try
            {
                con = new SqlConnection(connectionstring);
                con.Open();
                string strquery1 = "Update  CategoryDetailsTbl set CategoryId = '" + catupdate.CategoryId + "' , CategoryName = '" + catupdate.CategoryName + "' WHERE ProductId  = '" + catupdate.ProductId + "' ";
                SqlCommand cmd1 = new SqlCommand(strquery1, con);

                var data1 = cmd1.ExecuteNonQuery();
                if (data1 == 1)
                {

                    result = "Success";
                    return result;
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                return result;
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        public string insertcategorydtls(Category cdtls)
        {
            String result = "Failed";
            try
            {
                con = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand("AddCategoryDtls", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prid", cdtls.ProductId);
                cmd.Parameters.AddWithValue("@cid", cdtls.CategoryId);
                cmd.Parameters.AddWithValue("@cname", cdtls.CategoryName);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (i >= 1)
                {
                    result = "Success";
                }
                else
                {
                    result = "Failed";
                }
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }

        public List<Productinq> showproductdata()
        {
            Productinq output = null;
            List<Productinq> inqlist = new List<Productinq>();


            DataSet objDataSet;
            SqlDataAdapter sda;
            try
            {
                con = new SqlConnection(connectionstring);
                con.Open();
                string strquerry = "select P.ProductId,P.ProductName,C.CategoryId,C.CategoryName from ProductDetailsTbl as P join CategoryDetailsTbl as C on P.ProductId = C.ProductId";

                SqlCommand command = new SqlCommand(strquerry, con);
                objDataSet = new DataSet();


                sda = new SqlDataAdapter(command);
                sda.Fill(objDataSet);
                if (objDataSet.Tables.Count > 0)
                {
                    if (objDataSet.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
                        {
                            output = new Productinq();
                            output.ProductId = objDataSet.Tables[0].Rows[i]["ProductId"].ToString();
                            output.ProductName = objDataSet.Tables[0].Rows[i]["ProductName"].ToString();
                            output.CategoryId = objDataSet.Tables[0].Rows[i]["CategoryId"].ToString();
                            output.CategoryName = objDataSet.Tables[0].Rows[i]["CategoryName"].ToString();

                            inqlist.Add(output);
                        }

                    }
                }
                return inqlist;
            }
            catch (Exception ex)
            {
                return inqlist;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

        }


    }

}