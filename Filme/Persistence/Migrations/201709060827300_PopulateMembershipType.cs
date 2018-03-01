using System.Data.Entity.Migrations;

namespace Filme.Persistence.Migrations
{
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("insert into membershiptypes (id, signupfee,discountrate,durationinmonths) values(1,0,0,0)");
            Sql("insert into membershiptypes (id, signupfee,discountrate,durationinmonths) values(2,30,10,1)");
            Sql("insert into membershiptypes (id, signupfee,discountrate,durationinmonths) values(3,90,15,3)");
            Sql("insert into membershiptypes (id, signupfee,discountrate,durationinmonths) values(4,300,20,12)");
        }
        
        public override void Down()
        {
        }
    }
}
