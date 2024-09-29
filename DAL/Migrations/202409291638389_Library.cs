namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Library : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.LibrarySystemIntegrations", newName: "Libraries");
            DropColumn("dbo.Libraries", "EndpointURL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Libraries", "EndpointURL", c => c.String(nullable: false));
            RenameTable(name: "dbo.Libraries", newName: "LibrarySystemIntegrations");
        }
    }
}
