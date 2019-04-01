using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure.Annotations;

namespace Trrp4.Objects
{
    [Serializable]
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public int Sender { get; set; }

        public int Addressee { get; set; }

        public string Text { get; set; }

        public bool IsDelivered { get; set; }
    }
}
