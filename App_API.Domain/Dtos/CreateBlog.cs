using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_API.Domain.Models;

namespace App_API.Domain.Dtos
{
    public class CreateBlog
    {
       
        public string Name { get; set; }   
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }

    }
}
