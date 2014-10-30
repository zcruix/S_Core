namespace iPayment.Core.AppEntry.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationForms",
                c => new
                    {
                        ApplicationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ApplicationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ApplicationForms");
        }
    }
}
