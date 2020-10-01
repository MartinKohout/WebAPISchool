using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Quote
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }

        public ICollection<QuoteTag> QuoteTags { get; set; }
    }
}
