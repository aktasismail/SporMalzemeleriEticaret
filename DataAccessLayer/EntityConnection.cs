using System;
using System.Data.Entity;
using System.Linq;
using Entities;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace DataAccessLayer
{
    public class EntityConnection : DbContext
    {

        public EntityConnection()
            : base("name=EntityConnection")
        {
            Database.SetInitializer(new DatabaseInitiAlizer());
        }


        public DbSet<Kategori> Kategoriler { get; set; }
        public  DbSet<Kullanici> Kullanicilar { get; set; }
        public  DbSet<Marka> Markalar { get; set; }
        public  DbSet<Urun> Urunler { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Siparisler> Siparislers { get; set; }
        public DbSet<Slider> Sliders { get; set; } 
        public DbSet<Iletisim> Iletisims { get; set; } 
        public DbSet<Yorumlar> Yorumlar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
        public class DatabaseInitiAlizer : CreateDatabaseIfNotExists<EntityConnection>
        {
            protected override void Seed(EntityConnection context)
            {
                
                if (!context.Kullanicilar.Any())
                {
                    context.Kullanicilar.Add(
                        new Kullanici()
                        {
                            Aktifmi = true,
                            Ad = "Admin",
                            Sifre = "123456"
                        }
                        );

                }
                base.Seed(context);
                
            }
        }
    }

}   