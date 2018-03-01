using System.Data.Entity.Migrations;

namespace Filme.Persistence.Migrations
{
    public partial class PopulatingWithNewMembershipName : DbMigration
    {
        public override void Up()
        {
            Sql("update membershiptypes set name='Pay as you go' where id=1");
            Sql("update membershiptypes set name='Monthly' where id=2");
            Sql("update membershiptypes set name='Quarterly' where id=3");
            Sql("update membershiptypes set name='Yearly' where id=4");
        }
        
        public override void Down()
        {
        }
    }
}
