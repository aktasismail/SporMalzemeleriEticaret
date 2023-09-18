using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Iletisim : IEntity
    {
        public int Id { get; set; }
        [StringLength (50)]
        public string Ad { get; set; }
        [StringLength (50)]
        public string Soyad { get; set; }
        [EmailAddress, StringLength(50)]
        public string Email { get; set; }
        public string Mesaj { get; set; }
    }
}
