namespace iPayment.Core.AppEntry.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationFormDataModelDotApplicationFormKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ApplicationForms");
            AddColumn("dbo.ApplicationForms", "ApplicationFormKey", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ApplicationForms", "ApplicationFormKey");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ApplicationForms");
            DropColumn("dbo.ApplicationForms", "ApplicationFormKey");
            AddPrimaryKey("dbo.ApplicationForms", "ApplicationId");
        }
    }
}
