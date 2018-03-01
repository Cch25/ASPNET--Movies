using System.Data.Entity.Migrations;

namespace Filme.Persistence.Migrations
{
    public partial class CustomerAddressAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Address");
        }
    }
}
