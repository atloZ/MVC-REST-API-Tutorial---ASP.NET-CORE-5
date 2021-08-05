using PlatformDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformDemo.ModelValidations
{
    public class Ticket_EnsureDueDateInFuture: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ticket = validationContext.ObjectInstance as Ticket;

            if (ticket != null && ticket.TicketId == null)
            {
                if (ticket.DueDate.HasValue && ticket.DueDate.Value < DateTime.Now)
                {
                    return new ValidationResult("Due date has to be in the future.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
