Imports System.ComponentModel.DataAnnotations
Imports System
Imports System.Collections.Generic

Public Class products
        <Key>
        <Display(Name:="ID")>
        Public Property product_id As Integer

        <Required>
        <Display(Name:="User ID")>
        Public Property user_id As Integer

        <Required>
        <Display(Name:="Product ID")>
        Public Property productinfo_id As Integer

        Public Overridable Property product_info As product_info
        Public Overridable Property myUsers As myUsers

    End Class
