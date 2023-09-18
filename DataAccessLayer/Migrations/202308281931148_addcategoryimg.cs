namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcategoryimg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kategori", "Gorsel", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kategori", "Gorsel");
        }
    }
}
