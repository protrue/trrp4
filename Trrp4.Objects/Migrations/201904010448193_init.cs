namespace Trrp4.Objects.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sender = c.Int(nullable: false),
                        Addressee = c.Int(nullable: false),
                        Text = c.String(),
                        IsDelivered = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(maxLength: 50),
                        Hash = c.String(maxLength: 64),
                        Salt = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Login, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Login" });
            DropTable("dbo.Users");
            DropTable("dbo.Messages");
        }
    }
}
