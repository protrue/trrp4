using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Client.Resources
{
    public class Member
    {
        public string Id { get;}
        public string Name { get; set; }
        public string Address { get; set; }
        public int Characteristic { get; set; }
        public Bitmap Photo { get; set; }
        //Возможно нужны еще поля

        Member(Bitmap _photo, string _name, string _address, int _characteristic)
        {
            Photo = _photo;
            Name = _name;
            Address = _address;
            Characteristic = _characteristic;
        }
    }
}
