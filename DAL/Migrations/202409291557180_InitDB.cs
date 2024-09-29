namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Author = c.String(nullable: false, maxLength: 150),
                        ISBN = c.String(maxLength: 20),
                        PublishDate = c.DateTime(nullable: false),
                        AvailableCopies = c.Int(nullable: false),
                        Borrowing_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Borrowings", t => t.Borrowing_ID)
                .Index(t => t.Borrowing_ID);
            
            CreateTable(
                "dbo.Borrowings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                        BorrowDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(),
                        DueDate = c.DateTime(nullable: false),
                        IsReturned = c.Boolean(nullable: false),
                        Reminder = c.Boolean(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Books", t => t.BookID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.BookID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Reminders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BorrowingID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        ReminderDate = c.DateTime(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Borrowings", t => t.BorrowingID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.BorrowingID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false, maxLength: 8),
                        Email = c.String(nullable: false),
                        FullName = c.String(),
                        RegistrationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LibrarySystemIntegrations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SystemName = c.String(nullable: false, maxLength: 100),
                        APIKey = c.String(nullable: false),
                        EndpointURL = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Borrowings", "UserID", "dbo.Users");
            DropForeignKey("dbo.Reminders", "UserID", "dbo.Users");
            DropForeignKey("dbo.Borrowings", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Reminders", "BorrowingID", "dbo.Borrowings");
            DropForeignKey("dbo.Books", "Borrowing_ID", "dbo.Borrowings");
            DropForeignKey("dbo.Borrowings", "BookID", "dbo.Books");
            DropIndex("dbo.Reminders", new[] { "UserID" });
            DropIndex("dbo.Reminders", new[] { "BorrowingID" });
            DropIndex("dbo.Borrowings", new[] { "User_ID" });
            DropIndex("dbo.Borrowings", new[] { "BookID" });
            DropIndex("dbo.Borrowings", new[] { "UserID" });
            DropIndex("dbo.Books", new[] { "Borrowing_ID" });
            DropTable("dbo.LibrarySystemIntegrations");
            DropTable("dbo.Users");
            DropTable("dbo.Reminders");
            DropTable("dbo.Borrowings");
            DropTable("dbo.Books");
        }
    }
}
