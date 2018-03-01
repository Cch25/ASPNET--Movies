using System.Data.Entity.Migrations;

namespace Filme.Persistence.Migrations
{
    public partial class AddAvailableInStockForMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "AvailableInStock", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "AvailableInStock");
        }
    }
}
