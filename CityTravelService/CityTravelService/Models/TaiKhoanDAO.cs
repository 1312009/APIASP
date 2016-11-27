using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CityTravelService.Models
{
    public class TaiKhoanDAO : DataProvider
    {
        public List<TaiKhoan> getDsTaiKhoan()
        {
            connect();
            string query = "SELECT * FROM TAIKHOAN";
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            List<TaiKhoan> arr = new List<TaiKhoan>();
            foreach (Object o in ls)
            {
                arr.Add((TaiKhoan)o);
            }

            disconnect();
            return arr;
        }

        public TaiKhoan getTaiKhoan(string email)
        {
            connect();
            string query = "SELECT * FROM TAIKHOAN WHERE Email = '" + email + "'";
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            TaiKhoan arr = new TaiKhoan();
            foreach (Object o in ls)
            {
                arr = (TaiKhoan)o;
                break;
            }

            disconnect();
            return arr;
        }

        public TaiKhoan getTaiKhoan(string email, string password)
        {
            string result = "Null";
           
            if (HttpContext.Current.Session.Count > 0 && HttpContext.Current.Session["UserOnline"] != null && HttpContext.Current.Session["UserOnline"].ToString() == "On")
            {
                string type = "";
                if (HttpContext.Current.Session["Auth"].ToString() == "Admin")
                {
                    type = "Admin";
                }

                else
                {
                    type = "Customer";
                }
                result = type;
            }

            connect();
            string query = "SELECT * FROM TAIKHOAN WHERE Email = '" + email + "' AND MatKhau = '" + password + "'";
            adapter = new SqlDataAdapter(query, connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            ArrayList ls = ConvertDataSetToArrayList(dataset);
            TaiKhoan arr = new TaiKhoan();
            foreach (Object o in ls)
            {
                arr = (TaiKhoan)o;
                break;
            }
            try
            {
                if (arr.Email != null)
                {
                    HttpContext.Current.Session["AccountId"] = arr.Email;
                    HttpContext.Current.Session["UserOnline"] = "On";
                    if(arr.Role=="Admin")
                    {
                        HttpContext.Current.Session["Auth"] = "Admin";
                      
                    }
                    else
                    {
                        HttpContext.Current.Session["Auth"] = "Customer";
                    
                    }
                }
                
            }
            catch (NotImplementedException implementedException)
            {

            }
           
            disconnect();
            return arr;
        }

        protected override object GetDataFromDataRow(DataTable dt, int i)
        {
            TaiKhoan tk = new TaiKhoan();
            tk.Email = dt.Rows[i]["Email"].ToString();
            tk.PassWord = dt.Rows[i]["MatKhau"].ToString();
            tk.LastName = dt.Rows[i]["Ho"].ToString();
            tk.FirtName = dt.Rows[i]["Ten"].ToString();
            tk.Phone = dt.Rows[i]["SDT"].ToString();
            tk.Sex = (dt.Rows[i].IsNull("GioiTinh") == true) ? 0 : (int)dt.Rows[i]["GioiTinh"];
            tk.Birth = (dt.Rows[i].IsNull("NgaySinh") == true) ? DateTime.Now : (DateTime)dt.Rows[i]["NgaySinh"];
            tk.Address = dt.Rows[i]["DiaChi"].ToString();
            tk.Picture = dt.Rows[i]["Hinh"].ToString();
            tk.Role = dt.Rows[i]["Role"].ToString();
            return (object)tk;
        }

        public bool insertTaiKhoan(TaiKhoan tk)
        {
            try
            {
                connect();
                string insertCommand = "INSERT INTO TAIKHOAN VALUES('" +
                    tk.Email + "', '" +
                    tk.PassWord + "', N'" +
                    tk.LastName + "', N'" +
                    tk.FirtName + "', N'" +
                    tk.Phone + "', " +
                    tk.Sex + ", '" +
                    tk.Birth.Year + "-" + tk.Birth.Month + "-" + tk.Birth.Day + "', N'" +
                    tk.Address + "', '" +
                    tk.Picture +"', '" +
                    tk.Role + "')";
                executeNonQuery(insertCommand);
                disconnect();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool updateTaiKhoan(TaiKhoan tk)
        {
            try
            {
                connect();
                string updateCommand = "UPDATE TAIKHOAN SET Email = '" + tk.Email +
                    "', MatKhau = '" + tk.PassWord +
                    "', Ho = N'" + tk.LastName +
                    "', Ten = N'" + tk.FirtName +
                    "', SDT = N'" + tk.Phone +
                    "', GioiTinh = " + tk.Sex +
                    ", NgaySinh = '" + tk.Birth.Year + "-" + tk.Birth.Month + "-" + tk.Birth.Day +
                    "', DiaChi = N'" + tk.Address +
                    "', Hinh = '" + tk.Picture +
                      "', Role = '" + tk.Role +
                    "' WHERE Email = '" + tk.Email + "'";
                executeNonQuery(updateCommand);
                disconnect();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool updatePassword(string pass, string Email)
        {
            try
            {
                connect();
                string updateCommand = "UPDATE TAIKHOAN SET MatKhau = '" + pass +
                    "' WHERE Email = '" + Email + "'";
                executeNonQuery(updateCommand);
                disconnect();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool changePassword(string email,string passwordold,string passwordnew)
        {
            try
            {
                connect();
                string query = "SELECT * FROM TAIKHOAN WHERE Email = '" + email + "' AND MatKhau = '" + passwordold + "'";
                adapter = new SqlDataAdapter(query, connection);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                ArrayList ls = ConvertDataSetToArrayList(dataset);
                TaiKhoan arr = new TaiKhoan();
                foreach (Object o in ls)
                {
                    arr = (TaiKhoan)o;
                }
                if (arr.Email != null)
                {
                    string updateCommand = "UPDATE TAIKHOAN SET MatKhau = '" + passwordnew +
                       "' WHERE Email = '" + email + "'";
                    executeNonQuery(updateCommand);
                    disconnect();
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool deleteTaiKhoan(string Email)
        {
            try
            {
                connect();
                string deleteCommand = "DELETE FROM TAIKHOAN WHERE Email = '" + Email + "'";
                executeNonQuery(deleteCommand);
                disconnect();
                return true;
            } catch (Exception)
            {
                return false;
            }
        }
    }
}