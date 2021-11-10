//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Employee_tb
    {
        public int Id { get; set; }
        [RegularExpression(@"^[\w ]+$",ErrorMessage ="Only String Allowed")]
        public string Name { get; set; }
        public System.DateTime HireDate { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
    
        public virtual Department_tb Department_tb { get; set; }
    }
}
