using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Serialization;

namespace Trrp4.Objects
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(50)]
        public string Login { get; set; }

        [StringLength(maximumLength:64)]
        public string Hash { get; set; }

        [StringLength(maximumLength: 10)]
        public string Salt { get; set; }
    }
}
