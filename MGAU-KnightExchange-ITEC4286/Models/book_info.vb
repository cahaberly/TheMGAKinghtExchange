Imports System.ComponentModel.DataAnnotations
Imports System
Imports System.Collections.Generic

Public Class book_info
        <Key>
        <Display(Name:="ID")>
        Public Property bookinfo_id As Integer

        <Required>
        <StringLength(50, ErrorMessage:="Must be less than 50 characters")>
        <Display(Name:="Title")>
        Public Property book_title As String

        <Required>
        <StringLength(50, ErrorMessage:="Must be less than 50 characters")>
        <Display(Name:="Edition")>
        Public Property book_edition As String

        <Required>
        <StringLength(50, ErrorMessage:="Must be less than 50 characters")>
        <Display(Name:="ISBN")>
        Public Property book_isbn As String

        <Required>
        <StringLength(50, ErrorMessage:="Must be less than 50 characters")>
        <Display(Name:="Author")>
        Public Property book_author As String

        Public Overridable Property books As ICollection(Of books) = New HashSet(Of books)
    End Class
