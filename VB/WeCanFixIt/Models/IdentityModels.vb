Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity
Imports System.Security.Claims
Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin

Namespace Models

    ' You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    Public Class ApplicationUser
        Inherits IdentityUser
        Public Async Function GenerateUserIdentityAsync(manager As UserManager(Of ApplicationUser)) As Task(Of ClaimsIdentity)
            ' Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            Dim userIdentity = Await manager.CreateIdentityAsync(Me, DefaultAuthenticationTypes.ApplicationCookie)
            ' Add custom user claims here
            Return userIdentity
        End Function
    End Class

    <Table("wo_worker")>
    Public Class Worker

        <Key>
        <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
        <Column("wo_id")>
        Public Property Id As Int32

        <Required>
        <StringLength(50)>
        <Column("wo_name")>
        Public Property Name As String

        <Required>
        <StringLength(250)>
        <Column("wo_skills")>
        Public Property Skills As String

        <Required>
        <Column("wo_hours_worked")>
        <Range(1, 8)>
        Public Property HoursWorked As Nullable(Of Decimal)

        <Required>
        <Column("wo_rate")>
        <Range(1, 50)>
        Public Property Rate As Nullable(Of Int32)
    End Class


    Public Class ApplicationDbContext
        Inherits IdentityDbContext(Of ApplicationUser)
        Public Sub New()
            MyBase.New("DefaultConnection", throwIfV1Schema:=False)
        End Sub

        Public Property Workers As DbSet(Of Worker)

        'Public Property Purpose As String
        Public Shared Function Create() As ApplicationDbContext
            Return New ApplicationDbContext()
        End Function
    End Class
End Namespace