using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class QuoteTagsViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }

        public IList<Tag> Tags { get; set; }

    }
}
