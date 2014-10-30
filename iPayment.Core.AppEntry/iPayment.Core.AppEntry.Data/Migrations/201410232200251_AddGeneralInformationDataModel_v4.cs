namespace iPayment.Core.AppEntry.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGeneralInformationDataModel_v4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationForms", "ApplicationFormKey", "dbo.GeneralInformations");
            DropIndex("dbo.ApplicationForms", new[] { "ApplicationFormKey" });
            AddColumn("dbo.ApplicationForms", "GeneralInformation_GeneralInformationKey", c => c.Int());
            AddColumn("dbo.GeneralInformations", "DoingBusinessAsName", c => c.String());
            AddColumn("dbo.GeneralInformations", "LegalBusinessAsName", c => c.String());
            CreateIndex("dbo.ApplicationForms", "GeneralInformation_GeneralInformationKey");
            AddForeignKey("dbo.ApplicationForms", "GeneralInformation_GeneralInformationKey", "dbo.GeneralInformations", "GeneralInformationKey");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationForms", "GeneralInformation_GeneralInformationKey", "dbo.GeneralInformations");
            DropIndex("dbo.ApplicationForms", new[] { "GeneralInformation_GeneralInformationKey" });
            DropColumn("dbo.GeneralInformations", "LegalBusinessAsName");
            DropColumn("dbo.GeneralInformations", "DoingBusinessAsName");
            DropColumn("dbo.ApplicationForms", "GeneralInformation_GeneralInformationKey");
            CreateIndex("dbo.ApplicationForms", "ApplicationFormKey");
            AddForeignKey("dbo.ApplicationForms", "ApplicationFormKey", "dbo.GeneralInformations", "GeneralInformationKey");
        }
    }
}
