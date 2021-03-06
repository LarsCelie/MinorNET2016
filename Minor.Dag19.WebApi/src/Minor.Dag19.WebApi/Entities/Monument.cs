﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Minor.Dag19.WebApi.Entities
{
    public class Monument
    {

        public int Id { get; set; }

        [Required]
        public int Hoogte { get; set; }

        [Required]
        public string Naam { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Monument)) {
                return false;
            }
            Monument mon = (Monument)obj;

            return mon.Id == Id && mon.Naam == Naam && mon.Hoogte == mon.Hoogte;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ Hoogte.GetHashCode() ^ Naam.GetHashCode();
        }
    }

}