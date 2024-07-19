using Assignment.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Assignment.Models
{
    public class UniqueNameAttribute  : ValidationAttribute
    {
        public string EntityName {  get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return null;
            string newName = value.ToString();
            ErrorMessage = $"There Is Already ${EntityName ?? "Field"} With The Name \"{value}\"";
            AppDbContext context = new AppDbContext();
            var dept = context.Departments.FirstOrDefault(e => e.Name == newName);


            if (dept != null && dept.Id != ((Department)validationContext.ObjectInstance).Id) return new ValidationResult(ErrorMessage);
               

            return ValidationResult.Success;

        }
        //public override bool IsValid(object value)
        //{
         
        //}
    }
}
