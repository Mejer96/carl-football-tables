using System;
using System.ComponentModel.DataAnnotations;


public class Validator<T> 
{
    public static bool ValidateAsStatement(T obj) 
    {
        if (obj is not null) 
        {
            var result = new List<ValidationResult>();
            var context = new ValidationContext(obj);
            return Validator.TryValidateObject(obj, context, result, true);
        } else 
        {
            return false;
        }
    }
    
    public static bool ValidateAsExpression(T obj, List<ValidationResult> result) =>
    (obj is not null) ? Validator.TryValidateObject(obj, new ValidationContext(obj), result, true) : false; 
}