//------------------------------------------------------------------------------
// <auto-generated>
//     Este c�digo fue generado por una herramienta.
//     Versi�n de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podr�an causar un comportamiento incorrecto y se perder�n si
//     se vuelve a generar el c�digo.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP {
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;
using System.Web.UI;
using System.Web.WebPages;
using System.Web.WebPages.Html;

public class _Page_Index_cshtml : System.Web.WebPages.WebPage {
private static object @__o;
#line hidden
public _Page_Index_cshtml() {
}
protected System.Web.HttpApplication ApplicationInstance {
get {
return ((System.Web.HttpApplication)(Context.ApplicationInstance));
}
}
public override void Execute() {

#line 1 "C:\Users\JMP\AppData\Local\Temp\B7433C29BA00A6DA12FD93255137B6D8E567\7\Proyecto-Grupo6\MVC\Views\Account\Index.cshtml"
__o = model;


#line default
#line hidden

#line 2 "C:\Users\JMP\AppData\Local\Temp\B7433C29BA00A6DA12FD93255137B6D8E567\7\Proyecto-Grupo6\MVC\Views\Account\Index.cshtml"
  
    ViewBag.Title = "Login";


#line default
#line hidden

#line 3 "C:\Users\JMP\AppData\Local\Temp\B7433C29BA00A6DA12FD93255137B6D8E567\7\Proyecto-Grupo6\MVC\Views\Account\Index.cshtml"
using (Html.BeginForm())
{
    

#line default
#line hidden

#line 4 "C:\Users\JMP\AppData\Local\Temp\B7433C29BA00A6DA12FD93255137B6D8E567\7\Proyecto-Grupo6\MVC\Views\Account\Index.cshtml"
__o = Html.AntiForgeryToken();


#line default
#line hidden

#line 5 "C:\Users\JMP\AppData\Local\Temp\B7433C29BA00A6DA12FD93255137B6D8E567\7\Proyecto-Grupo6\MVC\Views\Account\Index.cshtml"
                            
    

#line default
#line hidden

#line 6 "C:\Users\JMP\AppData\Local\Temp\B7433C29BA00A6DA12FD93255137B6D8E567\7\Proyecto-Grupo6\MVC\Views\Account\Index.cshtml"
   __o = Html.ValidationSummary(true, "", new { @class = "text-danger" });


#line default
#line hidden

#line 7 "C:\Users\JMP\AppData\Local\Temp\B7433C29BA00A6DA12FD93255137B6D8E567\7\Proyecto-Grupo6\MVC\Views\Account\Index.cshtml"
       __o = Html.LabelFor(model => model.Email, htmlAttributes: new
            {
                @class =
            "control-label col-md-2"
            });


#line default
#line hidden

#line 8 "C:\Users\JMP\AppData\Local\Temp\B7433C29BA00A6DA12FD93255137B6D8E567\7\Proyecto-Grupo6\MVC\Views\Account\Index.cshtml"
           __o = Html.EditorFor(model => model.Email, new
                {
                    htmlAttributes = new
                    {
                @class = "form-control"
                    }
                });


#line default
#line hidden

#line 9 "C:\Users\JMP\AppData\Local\Temp\B7433C29BA00A6DA12FD93255137B6D8E567\7\Proyecto-Grupo6\MVC\Views\Account\Index.cshtml"
           __o = Html.ValidationMessageFor(model => model.Email, "", new
                {
                    @class =
                "text-danger"
                });


#line default
#line hidden

#line 10 "C:\Users\JMP\AppData\Local\Temp\B7433C29BA00A6DA12FD93255137B6D8E567\7\Proyecto-Grupo6\MVC\Views\Account\Index.cshtml"
       __o = Html.LabelFor(model => model.Contrasena, "Password",
            htmlAttributes: new { @class = "control-label col-md-2" });


#line default
#line hidden

#line 11 "C:\Users\JMP\AppData\Local\Temp\B7433C29BA00A6DA12FD93255137B6D8E567\7\Proyecto-Grupo6\MVC\Views\Account\Index.cshtml"
           __o = Html.EditorFor(model => model.Contrasena, new
                {
                    htmlAttributes
                = new { @class = "form-control", @type = "password" }
                });


#line default
#line hidden

#line 12 "C:\Users\JMP\AppData\Local\Temp\B7433C29BA00A6DA12FD93255137B6D8E567\7\Proyecto-Grupo6\MVC\Views\Account\Index.cshtml"
           __o = Html.ValidationMessageFor(model => model.Contrasena, "", new
                { @class = "text-danger" });


#line default
#line hidden

#line 13 "C:\Users\JMP\AppData\Local\Temp\B7433C29BA00A6DA12FD93255137B6D8E567\7\Proyecto-Grupo6\MVC\Views\Account\Index.cshtml"
          

}

#line default
#line hidden

#line 14 "C:\Users\JMP\AppData\Local\Temp\B7433C29BA00A6DA12FD93255137B6D8E567\7\Proyecto-Grupo6\MVC\Views\Account\Index.cshtml"
__o = Html.ActionLink("Regresar a la Lista","Index","Productos");


#line default
#line hidden
DefineSection("Scripts", () => {


#line 15 "C:\Users\JMP\AppData\Local\Temp\B7433C29BA00A6DA12FD93255137B6D8E567\7\Proyecto-Grupo6\MVC\Views\Account\Index.cshtml"
__o = Scripts.Render("~/bundles/jqueryval");


#line default
#line hidden
});

}
}
}
