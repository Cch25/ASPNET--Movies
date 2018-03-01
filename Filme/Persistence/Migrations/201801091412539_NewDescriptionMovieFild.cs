using System.Data.Entity.Migrations;

namespace Filme.Persistence.Migrations
{
    public partial class NewDescriptionMovieFild : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Description");
        }
    }
}
