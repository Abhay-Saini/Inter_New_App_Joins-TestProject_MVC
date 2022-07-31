using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inter_New_App_Joins.Models
{
    public class StudentsModel
    {
        public int Stu_Id { get; set; }
       
        public string Name { get; set; }

        public string Email { get; set; }

        public string Standard { get; set; }

        public string Address { get; set; }

        public static implicit operator List<object>(StudentsModel v)
        {
            throw new NotImplementedException();
        }
    }
}