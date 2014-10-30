namespace iPayment.Core.AppEntry.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGeneralInformationDataModel_v5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationForms", "GeneralInformation_GeneralInformationKey", "dbo.GeneralInformations");
            DropIndex("dbo.ApplicationForms", new[] { "GeneralInformation_GeneralInformationKey" });
            DropColumn("dbo.ApplicationForms", "GeneralInformation_GeneralInformationKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationForms", "GeneralInformation_GeneralInformationKey", c => c.Int());
            CreateIndex("dbo.ApplicationForms", "GeneralInformation_GeneralInformationKey");
            AddForeignKey("dbo.ApplicationForms", "GeneralInformation_GeneralInformationKey", "dbo.GeneralInformations", "GeneralInformationKey");
        }
    }
}
