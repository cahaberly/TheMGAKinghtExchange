Imports System.ComponentModel.DataAnnotations
Imports System
Imports System.Collections.Generic

Public Class books
        <Key>
        <Display(Name:="ID")>
        Public Property book_id As Integer

        <Required>
        <Display(Name:="User ID")>
        Public Property user_id As Integer

        <Required>
        <Display(Name:="Book ID")>
        Public Property bookinfo_id As Integer

        Public Overridable Property book_info As book_info
        Public Overridable Property myUsers As myUsers
    End Class

