Imports System.ComponentModel.DataAnnotations
Imports System
Imports System.Collections.Generic

Public Class product_info
        <Key>
        <Display(Name:="ID")>
        Public Property productinfo_id As Integer

        <Required>
        <StringLength(50, ErrorMessage:="Must be less than 50 characters")>
        <Display(Name:="Product")>
        Public Property product_name As String

        <Required>
        <StringLength(500, ErrorMessage:="Must be less than 500 characters")>
        <Display(Name:="Description")>
        Public Property product_description As String

        Public Overridable Property products As ICollection(Of products) = New HashSet(Of products)
    End Class

