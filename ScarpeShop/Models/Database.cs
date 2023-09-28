using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ScarpeShop.Models
{
    public class Database
    {
        public static List<Prodotto> GetAllProducts()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Prodotto", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Prodotto> AllProducts = new List<Prodotto>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Prodotto prodotto = new Prodotto();
                prodotto.IdProdotto = Convert.ToInt32(sqlDataReader["IdProdotto"]);
                prodotto.Nome = sqlDataReader["Nome"].ToString();
                prodotto.Brand = sqlDataReader["Brand"].ToString();
                prodotto.Prezzo = Convert.ToDouble(sqlDataReader["Prezzo"]);
                prodotto.Disp = Convert.ToBoolean(sqlDataReader["Disp"]);
                prodotto.Descrizione = sqlDataReader["Descrizione"].ToString();
                prodotto.CoverImg = sqlDataReader["CoverImg"].ToString();
                prodotto.Img1 = sqlDataReader["Img1"].ToString();
                prodotto.Img2 = sqlDataReader["Img2"].ToString();
                AllProducts.Add(prodotto);

            }

            conn.Close();
            return AllProducts;
        }
        public static Prodotto GetProductById(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Prodotto where idProdotto = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader sqlDataReader;

            conn.Open();

            Prodotto prodotto = new Prodotto();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
   
                prodotto.IdProdotto = Convert.ToInt32(sqlDataReader["IdProdotto"]);
                prodotto.Nome = sqlDataReader["Nome"].ToString();
                prodotto.Brand = sqlDataReader["Brand"].ToString();
                prodotto.Prezzo = Convert.ToDouble(sqlDataReader["Prezzo"]);
                prodotto.Disp = Convert.ToBoolean(sqlDataReader["Disp"]);
                prodotto.Descrizione = sqlDataReader["Descrizione"].ToString();
                prodotto.CoverImg = sqlDataReader["CoverImg"].ToString();
                prodotto.Img1 = sqlDataReader["Img1"].ToString();
                prodotto.Img2 = sqlDataReader["Img2"].ToString();
              

            }

            conn.Close();
            return prodotto;
        }
        public static List<Users> GetAllUsers()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from User", conn);
            SqlDataReader sqlDataReader;

            conn.Open();
            List<Users> AllUsers = new List<Users>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Users user = new Users();
                user.IdUser = Convert.ToInt32(sqlDataReader["IdUser"]);
                user.Username = sqlDataReader["Username"].ToString();
                user.Psw = sqlDataReader["Psw"].ToString();
                user.Role = sqlDataReader["Role"].ToString();
                AllUsers.Add(user);

            }

            conn.Close();
            return AllUsers;
        }
        public static Users GetUserByUsername(string username)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Users where Username = @username", conn);
            cmd.Parameters.AddWithValue("username", username);
            SqlDataReader sqlDataReader;

            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            Users user = new Users();
            while (sqlDataReader.Read())
            {
                user.IdUser = Convert.ToInt32(sqlDataReader["IdUser"]);
                user.Username = sqlDataReader["Username"].ToString();
                user.Psw = sqlDataReader["Psw"].ToString();
                user.Role = sqlDataReader["Role"].ToString();
            }

            conn.Close();
            return user;
        }
        public static void SignIn(string username, string password, string role = "user")
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO User VALUES(@Username, @Psw, @Role)";
                cmd.Parameters.AddWithValue("Username", username);
                cmd.Parameters.AddWithValue("Psw", password);
                cmd.Parameters.AddWithValue("Role", role);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch
            {

            }
            finally
            {
                conn.Close();
            }
        }
        public static void ModifyProduct(int id, string Nome, string Brand, string Descrizione, string CoverImg, string Img1, string Img2, bool Disp, double Prezzo)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "update Prodotto SET Nome=@Nome, Brand=@Brand, Descrizione=@Descrizione, CoverImg=@CoverImg, Img1=@Img1, Img2=@Img2, Disp=@Disp, Prezzo=@Prezzo where IdProdotto=@id";
            cmd.Parameters.AddWithValue("Nome", Nome);
            cmd.Parameters.AddWithValue("Brand", Brand);
            cmd.Parameters.AddWithValue("Descrizione", Descrizione);
            cmd.Parameters.AddWithValue("CoverImg", CoverImg);
            cmd.Parameters.AddWithValue("Img1", Img1);
            cmd.Parameters.AddWithValue("Img2", Img2);
            cmd.Parameters.AddWithValue("Disp", Disp);
            cmd.Parameters.AddWithValue("Prezzo", Prezzo);
            cmd.Parameters.AddWithValue("id", id);
            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public static void InsertProduct(string Nome, string Brand, string Descrizione, string CoverImg, string Img1, string Img2, bool Disp, double Prezzo)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Insert INTO Prodotto VALUES(@Nome, @Brand, @Descrizione, @CoverImg, @Img1, @Img2, @Disp, @Prezzo)";
            cmd.Parameters.AddWithValue("Nome", Nome);
            cmd.Parameters.AddWithValue("Brand", Brand);
            cmd.Parameters.AddWithValue("Descrizione", Descrizione);
            cmd.Parameters.AddWithValue("CoverImg", CoverImg);
            cmd.Parameters.AddWithValue("Img1", Img1);
            cmd.Parameters.AddWithValue("Img2", Img2);
            cmd.Parameters.AddWithValue("Disp", Disp);
            cmd.Parameters.AddWithValue("Prezzo", Prezzo);
            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public static void RemoveProduct(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM Prodotto where IdProdotto=@id";
            cmd.Parameters.AddWithValue("id", id);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}