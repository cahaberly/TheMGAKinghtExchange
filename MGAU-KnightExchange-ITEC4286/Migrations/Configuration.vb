Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq

Namespace Migrations

    Friend NotInheritable Class Configuration 
        Inherits DbMigrationsConfiguration(Of ApplicationDbContext)

        Public Sub New()
            AutomaticMigrationsEnabled = True
        End Sub

        Protected Overrides Sub Seed(context As ApplicationDbContext)
            '  This method will be called after migrating to the latest version.

            '  You can use the DbSet(Of T).AddOrUpdate() helper extension method 
            '  to avoid creating duplicate seed data. E.g.
            '
            '    context.People.AddOrUpdate(
            '       Function(c) c.FullName,
            '       New Customer() With {.FullName = "Andrew Peters"},
            '       New Customer() With {.FullName = "Brice Lambson"},
            '       New Customer() With {.FullName = "Rowan Miller"})
            context.Books.AddOrUpdate(
               Function(c) c.book_id,
               New books() With {.book_id = 1, .user_id = 1, .bookinfo_id = 1})

            context.Book_Info.AddOrUpdate(
                Function(c) c.bookinfo_id,
                New book_info() With {.bookinfo_id = 1, .book_title = "Antlers in the Tree Tops",
                    .book_edition = "1", .book_isbn = "abc123", .book_author = "WhoGoozzedDaMoose"})

            context.Products.AddOrUpdate(
                Function(c) c.product_id,
                New products() With {.product_id = 1, .user_id = 1, .productinfo_id = 1})

            context.Product_Info.AddOrUpdate(
                Function(c) c.productinfo_id,
                New product_info() With {.productinfo_id = 1, .product_name = "pencil",
                .product_description = "A device once used to write information on paper"})

            context.MyUsers.AddOrUpdate(
                Function(c) c.user_id,
                New myUsers() With {.user_id = 1, .user_lname = "Haberly",
                .user_fname = "Clay", .user_email = "clayton.haberly@mga.edu", .user_permission = 1})
        End Sub

    End Class

End Namespace
