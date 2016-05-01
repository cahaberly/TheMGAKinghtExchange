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
    Public Class productsController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: products
        Function Index() As ActionResult
            Dim products = db.Products.Include(Function(p) p.myUsers).Include(Function(p) p.product_info)
            Return View(products.ToList())
        End Function

        ' GET: products/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim products As products = db.Products.Find(id)
            If IsNothing(products) Then
                Return HttpNotFound()
            End If
            Return View(products)
        End Function

        ' GET: products/Create
        Function Create() As ActionResult
            ViewBag.user_id = New SelectList(db.MyUsers, "user_id", "user_lname")
            ViewBag.productinfo_id = New SelectList(db.Product_Info, "productinfo_id", "product_name")
            Return View()
        End Function

        ' POST: products/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="product_id,user_id,productinfo_id")> ByVal products As products) As ActionResult
            If ModelState.IsValid Then
                db.Products.Add(products)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.user_id = New SelectList(db.MyUsers, "user_id", "user_lname", products.user_id)
            ViewBag.productinfo_id = New SelectList(db.Product_Info, "productinfo_id", "product_name", products.productinfo_id)
            Return View(products)
        End Function

        ' GET: products/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim products As products = db.Products.Find(id)
            If IsNothing(products) Then
                Return HttpNotFound()
            End If
            ViewBag.user_id = New SelectList(db.MyUsers, "user_id", "user_lname", products.user_id)
            ViewBag.productinfo_id = New SelectList(db.Product_Info, "productinfo_id", "product_name", products.productinfo_id)
            Return View(products)
        End Function

        ' POST: products/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="product_id,user_id,productinfo_id")> ByVal products As products) As ActionResult
            If ModelState.IsValid Then
                db.Entry(products).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.user_id = New SelectList(db.MyUsers, "user_id", "user_lname", products.user_id)
            ViewBag.productinfo_id = New SelectList(db.Product_Info, "productinfo_id", "product_name", products.productinfo_id)
            Return View(products)
        End Function

        ' GET: products/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim products As products = db.Products.Find(id)
            If IsNothing(products) Then
                Return HttpNotFound()
            End If
            Return View(products)
        End Function

        ' POST: products/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim products As products = db.Products.Find(id)
            db.Products.Remove(products)
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
