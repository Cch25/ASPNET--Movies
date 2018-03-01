using System.Data.Entity.Migrations;

namespace Filme.Persistence.Migrations
{
    public partial class PopulateCustomerBirthdates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false));
            Sql("update customers set birthdate = 1/1/1990 where id = 1");
            Sql("update customers set birthdate = 21/11/1991 where id = 2");
            Sql("update customers set birthdate = 15/12/1992 where id = 3");
            Sql("update customers set birthdate = 12/7/1993 where id = 4");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String());
        }
    }
}
