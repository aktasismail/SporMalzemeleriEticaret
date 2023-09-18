namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addorder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SiparisNo = c.String(),
                        Toplam = c.Double(nullable: false),
                        Tarih = c.DateTime(nullable: false),
                        SiparisDurumu = c.Int(nullable: false),
                        KullaniciAdi = c.String(),
                        Baslik = c.String(),
                        Adres = c.String(),
                        Sehir = c.String(),
                        PostaKodu = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Siparisler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SiparisId = c.Int(nullable: false),
                        Miktar = c.Int(nullable: false),
                        Fiyat = c.Double(nullable: false),
                        UrunId = c.Int(nullable: false),
                        Orders_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.Orders_Id)
                .ForeignKey("dbo.Urun", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.UrunId)
                .Index(t => t.Orders_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Siparisler", "UrunId", "dbo.Urun");
            DropForeignKey("dbo.Siparisler", "Orders_Id", "dbo.Order");
            DropIndex("dbo.Siparisler", new[] { "Orders_Id" });
            DropIndex("dbo.Siparisler", new[] { "UrunId" });
            DropTable("dbo.Siparisler");
            DropTable("dbo.Order");
        }
    }
}
