using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    public class Film
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string FullInfo { get => $"{Title} {Director} {Writer} {Genre} {Year}"; }
        public override string ToString() => FullInfo;
    }
}
