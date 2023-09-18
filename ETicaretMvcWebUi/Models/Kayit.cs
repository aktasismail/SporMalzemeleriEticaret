using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETicaretMvcWebUi.Models
{
    public class Kayit
    {

        [Required]
        [DisplayName("Adınız")]
        public string Ad { get; set; }
        [Required]
        [DisplayName("Soyadınız")]
        public string Soyad { get; set; }
        [Required]
        [DisplayName("Kullanıcı adı")]
        public string KullaniciAdi { get; set; }
        [Required]
        [DisplayName("E Posta")]
        [EmailAddress(ErrorMessage ="Geçerli bir Eposta giriniz")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Şifre")]
        public string Sifre { get; set; }
        [Required]
        [DisplayName("Şifre Tekrar")]
        [Compare("Sifre",ErrorMessage ="Şifreler aynı değil")]
        public string SifreTekrar { get; set; }
    }
}