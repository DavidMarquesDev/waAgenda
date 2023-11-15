using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace waAgenda
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String email = TxtEmail.Text;
            String senha = TxtSenha.Text;

            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
                {
                    Lmsg.Text = "Por favor, preencha todos os campos.";
                }
                else
                {
                    string connString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                    using (SqlConnection con = new SqlConnection(connString))
                    {
                        con.Open();

                        using (SqlCommand cmd = new SqlCommand("SELECT * FROM usuario WHERE email = @email AND senha = @senha", con))
                        {
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.Parameters.AddWithValue("@senha", senha);

                            using (SqlDataReader registro = cmd.ExecuteReader())
                            {
                                if (registro.HasRows)
                                {
                                    HttpCookie login = new HttpCookie("login", TxtEmail.Text);
                                    Response.Cookies.Add(login);
                                    Response.Redirect("~/index.aspx");
                                }
                                else
                                {
                                    Lmsg.Text = "Email ou senha incorretos!!!";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Lmsg.Text = "Ocorreu um erro: " + ex.Message;
            }
        }
    }
}