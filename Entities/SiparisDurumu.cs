using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entities
{
    public enum SiparisDurumu
    {
        [Display(Name = "Onay Bekleniyor")]
        Bekliyor,
        [Display(Name = "Siparişiniz Onaylandı")]
        Onaylandi,
        [Display(Name = "Kargoya Verildi")]
        KargoyaVerildi,
        [Display(Name = "Tamamlandı")]
        Tamamlandi
    }
}