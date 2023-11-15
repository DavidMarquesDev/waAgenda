using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace waAgenda
{
    public partial class usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SqlDataSourceUsuarios_Inserted(object sender, SqlDataSourceStatusEventArgs e)
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

        protected void SqlDataSourceUsuarios_Updated(object sender, SqlDataSourceStatusEventArgs e)
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
    }
}