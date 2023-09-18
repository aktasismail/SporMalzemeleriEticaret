namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcomment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Yorumlar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Yorum = c.String(),
                        Tarih = c.DateTime(nullable: false),
                        KullaniciAdi = c.String(),
                        UrunId = c.Int(nullable: false),
                        Kullanici_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kullanici", t => t.Kullanici_Id)
                .ForeignKey("dbo.Urun", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.UrunId)
                .Index(t => t.Kullanici_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Yorumlar", "UrunId", "dbo.Urun");
            DropForeignKey("dbo.Yorumlar", "Kullanici_Id", "dbo.Kullanici");
            DropIndex("dbo.Yorumlar", new[] { "Kullanici_Id" });
            DropIndex("dbo.Yorumlar", new[] { "UrunId" });
            DropTable("dbo.Yorumlar");
        }
    }
}
