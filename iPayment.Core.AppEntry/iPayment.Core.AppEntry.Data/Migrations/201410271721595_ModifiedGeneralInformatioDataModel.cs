namespace iPayment.Core.AppEntry.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedGeneralInformationDataModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GeneralInformations", "ContactFirstName", c => c.String());
            AddColumn("dbo.GeneralInformations", "ContactLastName", c => c.String());
            AddColumn("dbo.GeneralInformations", "BusinessEmail", c => c.String());
            AddColumn("dbo.GeneralInformations", "BusinessWebsiteUrl", c => c.String());
            AddColumn("dbo.GeneralInformations", "BusinessOperatingHours", c => c.String());
            AddColumn("dbo.GeneralInformations", "NumberOfLocations", c => c.Int(nullable: false));
            AddColumn("dbo.GeneralInformations", "BusinessPhone_Number", c => c.String());
            AddColumn("dbo.GeneralInformations", "BusinessPhone_PhoneType", c => c.Int(nullable: false));
            AddColumn("dbo.GeneralInformations", "BusinessFax_Number", c => c.String());
            AddColumn("dbo.GeneralInformations", "BusinessFax_PhoneType", c => c.Int(nullable: false));
            AddColumn("dbo.GeneralInformations", "CustomerServicePhone_Number", c => c.String());
            AddColumn("dbo.GeneralInformations", "CustomerServicePhone_PhoneType", c => c.Int(nullable: false));
            AddColumn("dbo.GeneralInformations", "BusinessAddress_AddressLine1", c => c.String());
            AddColumn("dbo.GeneralInformations", "BusinessAddress_AddressLine2", c => c.String());
            AddColumn("dbo.GeneralInformations", "BusinessAddress_City", c => c.String());
            AddColumn("dbo.GeneralInformations", "BusinessAddress_State", c => c.String());
            AddColumn("dbo.GeneralInformations", "BusinessAddress_Zipcode", c => c.String());
            AddColumn("dbo.GeneralInformations", "BusinessAddress_County", c => c.String());
            AddColumn("dbo.GeneralInformations", "BusinessAddress_AddressType", c => c.Int(nullable: false));
            AddColumn("dbo.GeneralInformations", "MailingAddress_AddressLine1", c => c.String());
            AddColumn("dbo.GeneralInformations", "MailingAddress_AddressLine2", c => c.String());
            AddColumn("dbo.GeneralInformations", "MailingAddress_City", c => c.String());
            AddColumn("dbo.GeneralInformations", "MailingAddress_State", c => c.String());
            AddColumn("dbo.GeneralInformations", "MailingAddress_Zipcode", c => c.String());
            AddColumn("dbo.GeneralInformations", "MailingAddress_County", c => c.String());
            AddColumn("dbo.GeneralInformations", "MailingAddress_AddressType", c => c.Int(nullable: false));
            AddColumn("dbo.GeneralInformations", "ContinuousResidenceAtTheBusinessAddress_Years", c => c.Int(nullable: false));
            AddColumn("dbo.GeneralInformations", "ContinuousResidenceAtTheBusinessAddress_Months", c => c.Int(nullable: false));
            AddColumn("dbo.GeneralInformations", "FederalTaxID_Number", c => c.String());
            AddColumn("dbo.GeneralInformations", "FederalTaxID_TaxIdType", c => c.Int(nullable: false));
            AddColumn("dbo.GeneralInformations", "IsMailingAddressSameAsBusinessAddress", c => c.Boolean(nullable: false));
            AddColumn("dbo.GeneralInformations", "IsDoingBusinessAsNameSameAsLegalBusinessName", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GeneralInformations", "IsDoingBusinessAsNameSameAsLegalBusinessName");
            DropColumn("dbo.GeneralInformations", "IsMailingAddressSameAsBusinessAddress");
            DropColumn("dbo.GeneralInformations", "FederalTaxID_TaxIdType");
            DropColumn("dbo.GeneralInformations", "FederalTaxID_Number");
            DropColumn("dbo.GeneralInformations", "ContinuousResidenceAtTheBusinessAddress_Months");
            DropColumn("dbo.GeneralInformations", "ContinuousResidenceAtTheBusinessAddress_Years");
            DropColumn("dbo.GeneralInformations", "MailingAddress_AddressType");
            DropColumn("dbo.GeneralInformations", "MailingAddress_County");
            DropColumn("dbo.GeneralInformations", "MailingAddress_Zipcode");
            DropColumn("dbo.GeneralInformations", "MailingAddress_State");
            DropColumn("dbo.GeneralInformations", "MailingAddress_City");
            DropColumn("dbo.GeneralInformations", "MailingAddress_AddressLine2");
            DropColumn("dbo.GeneralInformations", "MailingAddress_AddressLine1");
            DropColumn("dbo.GeneralInformations", "BusinessAddress_AddressType");
            DropColumn("dbo.GeneralInformations", "BusinessAddress_County");
            DropColumn("dbo.GeneralInformations", "BusinessAddress_Zipcode");
            DropColumn("dbo.GeneralInformations", "BusinessAddress_State");
            DropColumn("dbo.GeneralInformations", "BusinessAddress_City");
            DropColumn("dbo.GeneralInformations", "BusinessAddress_AddressLine2");
            DropColumn("dbo.GeneralInformations", "BusinessAddress_AddressLine1");
            DropColumn("dbo.GeneralInformations", "CustomerServicePhone_PhoneType");
            DropColumn("dbo.GeneralInformations", "CustomerServicePhone_Number");
            DropColumn("dbo.GeneralInformations", "BusinessFax_PhoneType");
            DropColumn("dbo.GeneralInformations", "BusinessFax_Number");
            DropColumn("dbo.GeneralInformations", "BusinessPhone_PhoneType");
            DropColumn("dbo.GeneralInformations", "BusinessPhone_Number");
            DropColumn("dbo.GeneralInformations", "NumberOfLocations");
            DropColumn("dbo.GeneralInformations", "BusinessOperatingHours");
            DropColumn("dbo.GeneralInformations", "BusinessWebsiteUrl");
            DropColumn("dbo.GeneralInformations", "BusinessEmail");
            DropColumn("dbo.GeneralInformations", "ContactLastName");
            DropColumn("dbo.GeneralInformations", "ContactFirstName");
        }
    }
}
