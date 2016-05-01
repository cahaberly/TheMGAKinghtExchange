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
    Public Class booksController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: books
        Function Index() As ActionResult
            Dim books = db.Books.Include(Function(b) b.book_info).Include(Function(b) b.myUsers)
            Return View(books.ToList())
        End Function

        ' GET: books/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim books As books = db.Books.Find(id)
            If IsNothing(books) Then
                Return HttpNotFound()
            End If
            Return View(books)
        End Function

        ' GET: books/Create
        Function Create() As ActionResult
            ViewBag.bookinfo_id = New SelectList(db.Book_Info, "bookinfo_id", "book_title")
            ViewBag.user_id = New SelectList(db.MyUsers, "user_id", "user_lname")
            Return View()
        End Function

        ' POST: books/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="book_id,user_id,bookinfo_id")> ByVal books As books) As ActionResult
            If ModelState.IsValid Then
                db.Books.Add(books)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.bookinfo_id = New SelectList(db.Book_Info, "bookinfo_id", "book_title", books.bookinfo_id)
            ViewBag.user_id = New SelectList(db.MyUsers, "user_id", "user_lname", books.user_id)
            Return View(books)
        End Function

        ' GET: books/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim books As books = db.Books.Find(id)
            If IsNothing(books) Then
                Return HttpNotFound()
            End If
            ViewBag.bookinfo_id = New SelectList(db.Book_Info, "bookinfo_id", "book_title", books.bookinfo_id)
            ViewBag.user_id = New SelectList(db.MyUsers, "user_id", "user_lname", books.user_id)
            Return View(books)
        End Function

        ' POST: books/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="book_id,user_id,bookinfo_id")> ByVal books As books) As ActionResult
            If ModelState.IsValid Then
                db.Entry(books).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.bookinfo_id = New SelectList(db.Book_Info, "bookinfo_id", "book_title", books.bookinfo_id)
            ViewBag.user_id = New SelectList(db.MyUsers, "user_id", "user_lname", books.user_id)
            Return View(books)
        End Function

        ' GET: books/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim books As books = db.Books.Find(id)
            If IsNothing(books) Then
                Return HttpNotFound()
            End If
            Return View(books)
        End Function

        ' POST: books/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim books As books = db.Books.Find(id)
            db.Books.Remove(books)
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
