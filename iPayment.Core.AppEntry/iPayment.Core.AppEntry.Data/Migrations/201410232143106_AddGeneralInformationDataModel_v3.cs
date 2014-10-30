namespace iPayment.Core.AppEntry.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGeneralInformationDataModel_v3 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ApplicationForms");
            CreateTable(
                "dbo.ApplicationForms",
                c => new
                {
                    ApplicationId = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.ApplicationId);

            DropPrimaryKey("dbo.ApplicationForms");
            AddColumn("dbo.ApplicationForms", "ApplicationFormKey", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ApplicationForms", "ApplicationFormKey");

            CreateTable(
                "dbo.GeneralInformations",
                c => new
                    {
                        GeneralInformationKey = c.Int(nullable: false, identity: true),
                        ApplicationFormKey = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GeneralInformationKey);
            
            CreateIndex("dbo.ApplicationForms", "ApplicationFormKey");
            AddForeignKey("dbo.ApplicationForms", "ApplicationFormKey", "dbo.GeneralInformations", "GeneralInformationKey");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ApplicationForms");
            DropColumn("dbo.ApplicationForms", "ApplicationFormKey");
            AddPrimaryKey("dbo.ApplicationForms", "ApplicationId");

            DropForeignKey("dbo.ApplicationForms", "ApplicationFormKey", "dbo.GeneralInformations");
            DropIndex("dbo.ApplicationForms", new[] { "ApplicationFormKey" });
            DropTable("dbo.GeneralInformations");
            
        }
    }
}
