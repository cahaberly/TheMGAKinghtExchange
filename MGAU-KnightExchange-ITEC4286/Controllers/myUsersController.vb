Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports MGAU_KnightExchange_ITEC4286
Imports MGAU_KnightExchange_ITEC4286.Models

Namespace Controllers
    Public Class myUsersController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext
        ' GET: myUsers
        Function Index(searchString As String) As ActionResult
            Dim users = From u In db.MyUsers Select u
            If Not String.IsNullOrEmpty(searchString) Then
                users = users.Where(Function(u) u.user_lname.ToUpper().Contains(searchString.ToUpper()) _
                    Or u.user_fname.ToUpper().Contains(searchString.ToUpper()))
            End If
            Return View(users.ToList())

        End Function
        ' GET: myUsers
        'Function Index() As ActionResult
        '    Return View(db.MyUsers.ToList())
        'End Function

        ' GET: myUsers/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim myUsers As myUsers = db.MyUsers.Find(id)
            If IsNothing(myUsers) Then
                Return HttpNotFound()
            End If
            Return View(myUsers)
        End Function

        ' GET: myUsers/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: myUsers/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="user_id,user_lname,user_fname,user_email,user_permission")> ByVal myUsers As myUsers) As ActionResult
            If ModelState.IsValid Then
                db.MyUsers.Add(myUsers)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(myUsers)
        End Function

        ' GET: myUsers/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim myUsers As myUsers = db.MyUsers.Find(id)
            If IsNothing(myUsers) Then
                Return HttpNotFound()
            End If
            Return View(myUsers)
        End Function

        ' POST: myUsers/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="user_id,user_lname,user_fname,user_email,user_permission")> ByVal myUsers As myUsers) As ActionResult
            If ModelState.IsValid Then
                db.Entry(myUsers).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(myUsers)
        End Function

        ' GET: myUsers/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim myUsers As myUsers = db.MyUsers.Find(id)
            If IsNothing(myUsers) Then
                Return HttpNotFound()
            End If
            Return View(myUsers)
        End Function

        ' POST: myUsers/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim myUsers As myUsers = db.MyUsers.Find(id)
            db.MyUsers.Remove(myUsers)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
