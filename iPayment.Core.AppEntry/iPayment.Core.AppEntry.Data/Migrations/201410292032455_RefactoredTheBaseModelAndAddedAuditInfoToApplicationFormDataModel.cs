namespace iPayment.Core.AppEntry.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactoredTheBaseModelAndAddedAuditInfoToApplicationFormDataModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationForms", "CreatedBy", c => c.String());
            AddColumn("dbo.ApplicationForms", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.ApplicationForms", "ModifiedBy", c => c.String());
            AddColumn("dbo.ApplicationForms", "ModifiedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationForms", "ModifiedDate");
            DropColumn("dbo.ApplicationForms", "ModifiedBy");
            DropColumn("dbo.ApplicationForms", "CreatedDate");
            DropColumn("dbo.ApplicationForms", "CreatedBy");
        }
    }
}
