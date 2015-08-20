namespace MovieDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColToRating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ratings", "CookieIdentifier", c => c.Guid());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ratings", "CookieIdentifier");
        }
    }
}
