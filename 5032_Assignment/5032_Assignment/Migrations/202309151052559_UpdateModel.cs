namespace _5032_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorID = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Specialization = c.String(nullable: false, maxLength: 100),
                        Location = c.String(maxLength: 100),
                        HospitalID = c.Int(),
                    })
                .PrimaryKey(t => t.DoctorID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Doctors");
        }
    }
}
