﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace waAgenda
{
    public partial class MasterPagePrincipal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["login"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
        }


        protected void Menu1_MenuItemClick1(object sender, MenuEventArgs e)
        {
            if (e.Item.Value == "Sair")
            {
                // Cria um novo cookie chamado "login" com valor vazio e data de expiração no passado
                HttpCookie loginCookie = new HttpCookie("login", string.Empty);
                loginCookie.Expires = DateTime.Now.AddYears(-1);

                // Adiciona o cookie à resposta
                Response.Cookies.Add(loginCookie);

                // Redireciona para a página de login
                Response.Redirect("~/Login.aspx");
            }

        }
    }
}
