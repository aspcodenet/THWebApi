using System;
using System.ComponentModel.DataAnnotations;

namespace THWebApi
{
    public class Player
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public string Born { get; set; }

        [Range(0,100)]
        public int Age { get; set; }
        public int Jersey { get; set; }
    }
}
