using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Trrp4.Client.Resources
{
    public class Member
    {
        public int Id { get;}
        public string Name { get; set; }

        public Member(int id, string name)
        {
            Id = id;
            Name = name;    
        }
    }
}
