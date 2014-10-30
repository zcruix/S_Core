namespace iPayment.Core.AppEntry.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGeneralInformationDataModel_v6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GeneralInformations", "LegalBusinessName", c => c.String());
            DropColumn("dbo.GeneralInformations", "LegalBusinessAsName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GeneralInformations", "LegalBusinessAsName", c => c.String());
            DropColumn("dbo.GeneralInformations", "LegalBusinessName");
        }
    }
}
