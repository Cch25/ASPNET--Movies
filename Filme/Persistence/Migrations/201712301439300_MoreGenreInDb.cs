using System.Data.Entity.Migrations;

namespace Filme.Persistence.Migrations
{
    public partial class MoreGenreInDb : DbMigration
    {
        public override void Up()
        {
            Sql("insert into genres (id,name) values(5,'Sci-fi')");
            Sql("insert into genres (id,name) values(6,'Horror')");
            Sql("insert into genres (id,name) values(7,'Romance')");
            Sql("insert into genres (id,name) values(8,'Mystery/Crime')");
            Sql("insert into genres (id,name) values(9,'Adventure')");
        }
        
        public override void Down()
        {
        }
    }
}
