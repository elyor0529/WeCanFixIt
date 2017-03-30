Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports WeCanFixIt.Models

Namespace Controllers
    Public Class WorkerController
        Inherits Controller

        Private ReadOnly _db As New ApplicationDbContext

        ' GET: Worker
        Async Function Index() As Task(Of ActionResult)
            Return View(Await _db.Workers.ToListAsync())
        End Function

        ' GET: Worker/Details/5
        Async Function Details(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim worker As Worker = Await _db.Workers.FindAsync(id)
            If IsNothing(worker) Then
                Return HttpNotFound()
            End If
            Return View(worker)
        End Function

        ' GET: Worker/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Worker/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Create(<Bind(Include:="Id,Name,Skills,HoursWorked,Rate")> ByVal worker As Worker) As Task(Of ActionResult)
            If ModelState.IsValid Then
                _db.Workers.Add(worker)
                Await _db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            Return View(worker)
        End Function

        ' GET: Worker/Edit/5
        Async Function Edit(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim worker As Worker = Await _db.Workers.FindAsync(id)
            If IsNothing(worker) Then
                Return HttpNotFound()
            End If
            Return View(worker)
        End Function

        ' POST: Worker/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Edit(<Bind(Include:="Id,Name,Skills,HoursWorked,Rate")> ByVal worker As Worker) As Task(Of ActionResult)
            If ModelState.IsValid Then
                _db.Entry(worker).State = EntityState.Modified
                Await _db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            Return View(worker)
        End Function

        ' GET: Worker/Delete/5
        Async Function Delete(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim worker As Worker = Await _db.Workers.FindAsync(id)
            If IsNothing(worker) Then
                Return HttpNotFound()
            End If
            Return View(worker)
        End Function

        ' POST: Worker/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As Integer) As Task(Of ActionResult)
            Dim worker As Worker = Await _db.Workers.FindAsync(id)
            _db.Workers.Remove(worker)
            Await _db.SaveChangesAsync()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                _db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
