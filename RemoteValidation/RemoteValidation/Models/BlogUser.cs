using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Models
{
    public class BlogUser
    {
        //  Remote Attribute adds a client-side validation component
        //  Async call will be made to {param1}...on {param2} controller
        [Remote("IsUserName_Available", "Home")]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}