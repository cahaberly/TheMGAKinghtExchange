Imports System.ComponentModel.DataAnnotations
Imports System
Imports System.Collections.Generic

Public Class myUsers
        <Key>
        <Display(Name:="ID")>
        Public Property user_id As Integer

        <Required>
        <StringLength(50, ErrorMessage:="Must be less than 50 characters")>
        <Display(Name:="Last Name")>
        Public Property user_lname As String

        <Required>
        <StringLength(50, ErrorMessage:="Must be less than 50 characters")>
        <Display(Name:="First Name")>
        Public Property user_fname As String

        <Required>
        <StringLength(255, ErrorMessage:="Must be less than 50 characters")>
        <Display(Name:="Email")>
        Public Property user_email As String

        <Required>
    <Display(Name:="Permission Level")>
    Public Property user_permission As String

    Public Property theUser As ApplicationUser

    Public Overridable Property books As ICollection(Of books) = New HashSet(Of books)
        Public Overridable Property products As ICollection(Of products) = New HashSet(Of products)
    End Class

