using System.Data.Entity.Migrations;

namespace Filme.Persistence.Migrations
{
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("insert into genres (id,name) values(1,'Action')");
            Sql("insert into genres (id,name) values(2,'Comedy')");
            Sql("insert into genres (id,name) values(3,'Thriller')");
            Sql("insert into genres (id,name) values(4,'Animation')");
  
        }
        
        public override void Down()
        {
        }
    }
}
