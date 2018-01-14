using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISVLM2017.Domain.Entities
{
    public partial class NavMenu
    {
        public int Id { get; set; }             //Iterator
        //public int Parent { get; set; }         //TopMenuItem parent id
        //public bool Group { get; set; }         //If this have another item below
        public string Description { get; set; }   //Text to show
        public string Action { get; set; }      //Action to Go
        public string Controller { get; set; } 
    }
}
