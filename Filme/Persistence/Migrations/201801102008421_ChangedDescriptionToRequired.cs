using System.Data.Entity.Migrations;

namespace Filme.Persistence.Migrations
{
    public partial class ChangedDescriptionToRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Description", c => c.String());
        }
    }
}
