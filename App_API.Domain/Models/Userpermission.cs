using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_API.Domain.Models
{

    public class Userpermission
    {
        public int UserId { get; set; }
        public Permission PermissionId { get; set; }
    }
}
