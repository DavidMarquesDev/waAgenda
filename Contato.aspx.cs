using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace waAgenda
{
    public partial class Contato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SqlDataSourceContato_Inserted(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                //Lmsg.Text = "Ocorreu um erro durante a inserção: " + e.Exception.Message;
                Lmsg.Text = "Ocorreu um erro durante a inserção: O Registro nao pode ser duplicado ou campos chaves nao podem estar vazios!";
                e.ExceptionHandled = true; // Marca a exceção como tratada para evitar que seja propagada
            }
            else
            {
                Lmsg.Text = "Inserção bem-sucedida!";
            }
        }

        protected void SqlDataSourceContato_Updated(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                //Lmsg.Text = "Ocorreu um erro durante a inserção: " + e.Exception.Message;
                Lmsg.Text = "Ocorreu um erro durante a alteração: O Registro não pode ser duplicado ou campos chaves nao podem estar vazios!";
                e.ExceptionHandled = true; // Marca a exceção como tratada para evitar que seja propagada
            }
            else
            {
                Lmsg.Text = "Alteração bem-sucedida!";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtNome.Text) || string.IsNullOrEmpty(TxtEmail.Text) || string.IsNullOrEmpty(TxtTelefone.Text))
                {
                    string script = "<script>alert('Por favor, preencha todos os campos!!!');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", script);
                    //Lmsg.Text = "Por favor, preencha todos os campos.";
                    return; // Retorna para evitar a execução do restante do código
                }

                // Captura a string de conexão do arquivo de configuração
                string connString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                // Cria uma conexão usando 'using' para garantir que os recursos sejam liberados corretamente
                using (SqlConnection con = new SqlConnection(connString))
                {
                    // Define o comando SQL
                    string sqlQuery = "Insert into contato (nome,email,telefone) values (@nome,@email,@telefone)";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                    {
                        // Adiciona os parâmetros
                        cmd.Parameters.AddWithValue("@nome", TxtNome.Text);
                        cmd.Parameters.AddWithValue("@email", TxtEmail.Text);
                        cmd.Parameters.AddWithValue("@telefone", TxtTelefone.Text);

                        // Abre a conexão
                        con.Open();

                        // Executa a query
                        cmd.ExecuteNonQuery();

                        // Fecha a conexão automaticamente ao sair do bloco 'using'
                    }
                }

                // Atualiza o GridView
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                // Trata a exceção (pode exibir uma mensagem de erro, fazer log, etc.)
                Lmsg.Text = "Ocorreu um erro durante a inserção: " + ex.Message;
            }
        }



    }
}