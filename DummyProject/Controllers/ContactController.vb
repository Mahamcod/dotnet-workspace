Imports System.Net
Imports System.Web.Http
Imports System.Web.Mvc.Controller

Public Class ContactController
    Inherits System.Web.Mvc.Controller

    ' GET api/<controller>
    Function Index() As ActionResult
        Return View()
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class
