namespace iPayment.Core.AppEntry.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyRelationShip : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GeneralInformations", "CreatedBy", c => c.String());
            AddColumn("dbo.GeneralInformations", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.GeneralInformations", "ModifiedBy", c => c.String());
            AddColumn("dbo.GeneralInformations", "ModifiedDate", c => c.DateTime());
            CreateIndex("dbo.GeneralInformations", "ApplicationFormKey");
            AddForeignKey("dbo.GeneralInformations", "ApplicationFormKey", "dbo.ApplicationForms", "ApplicationFormKey", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GeneralInformations", "ApplicationFormKey", "dbo.ApplicationForms");
            DropIndex("dbo.GeneralInformations", new[] { "ApplicationFormKey" });
            DropColumn("dbo.GeneralInformations", "ModifiedDate");
            DropColumn("dbo.GeneralInformations", "ModifiedBy");
            DropColumn("dbo.GeneralInformations", "CreatedDate");
            DropColumn("dbo.GeneralInformations", "CreatedBy");
        }
    }
}
