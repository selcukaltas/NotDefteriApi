using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NotDefteriApi.Models
{
    [Table("Notlar")]
    public class Not
    {
        public int Id { get; set; }
        [ForeignKey("Kullanici")]
        public string ApplicationUserId { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public DateTime? NotZamani { get; set; }
        public ApplicationUser Kullanici { get; set; }

    }
}