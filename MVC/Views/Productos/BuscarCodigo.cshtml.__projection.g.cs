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

public class _Page_Views_Productos_BuscarCodigo_cshtml : System.Web.WebPages.WebPage {
private static object @__o;
#line hidden
public _Page_Views_Productos_BuscarCodigo_cshtml() {
}
protected System.Web.HttpApplication ApplicationInstance {
get {
return ((System.Web.HttpApplication)(Context.ApplicationInstance));
}
}
public override void Execute() {

#line 1 "C:\Users\JMP\AppData\Local\Temp\B7433C29BA00A6DA12FD93255137B6D8E567\9\Proyecto-Grupo6\MVC\Views\Productos\BuscarCodigo.cshtml"
  
    ViewBag.Title = "Buscar Codigo";


#line default
#line hidden

#line 2 "C:\Users\JMP\AppData\Local\Temp\B7433C29BA00A6DA12FD93255137B6D8E567\9\Proyecto-Grupo6\MVC\Views\Productos\BuscarCodigo.cshtml"
using (Html.BeginForm("BuscarCodigo", "Productos", FormMethod.Post))
{
    

#line default
#line hidden

#line 3 "C:\Users\JMP\AppData\Local\Temp\B7433C29BA00A6DA12FD93255137B6D8E567\9\Proyecto-Grupo6\MVC\Views\Productos\BuscarCodigo.cshtml"
__o = Html.AntiForgeryToken();


#line default
#line hidden

#line 4 "C:\Users\JMP\AppData\Local\Temp\B7433C29BA00A6DA12FD93255137B6D8E567\9\Proyecto-Grupo6\MVC\Views\Productos\BuscarCodigo.cshtml"
                            

    

#line default
#line hidden

#line 5 "C:\Users\JMP\AppData\Local\Temp\B7433C29BA00A6DA12FD93255137B6D8E567\9\Proyecto-Grupo6\MVC\Views\Productos\BuscarCodigo.cshtml"
          

    

#line default
#line hidden

#line 6 "C:\Users\JMP\AppData\Local\Temp\B7433C29BA00A6DA12FD93255137B6D8E567\9\Proyecto-Grupo6\MVC\Views\Productos\BuscarCodigo.cshtml"
                                                                 
}

#line default
#line hidden

#line 7 "C:\Users\JMP\AppData\Local\Temp\B7433C29BA00A6DA12FD93255137B6D8E567\9\Proyecto-Grupo6\MVC\Views\Productos\BuscarCodigo.cshtml"
__o = Html.ActionLink("Regresar a la Lista", "Index", "Productos");


#line default
#line hidden
DefineSection("Scripts", () => {


#line 8 "C:\Users\JMP\AppData\Local\Temp\B7433C29BA00A6DA12FD93255137B6D8E567\9\Proyecto-Grupo6\MVC\Views\Productos\BuscarCodigo.cshtml"
__o = Scripts.Render("~/bundles/jqueryval");


#line default
#line hidden
});

}
}
}