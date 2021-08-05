using Core.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Models
{
    public class Ticket
    {
        public int? TicketId { get; set; }

        [Required]
        public int ProjektId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        [StringLength(50)]
        public string Owner { get; set; }

        [Ticket_EnsureDuedateAfterReportDate]
        [Ticket_EnsureFutureDueDateOnCreation]
        [Ticket_EnsureDueDatePresent]
        public DateTime? ReportDate { get; set; }
        public DateTime? DueDate { get; set; }

        public Project Project { get; set; }

        /// <summary>
        /// When creating a ticket, if due date is entered, it has to be in the future.
        /// </summary>
        public bool ValidateFutureDueDate()
        {
            if (TicketId.HasValue) return true;
            if (!DueDate.HasValue) return true;

            return (DueDate.Value > DateTime.Now);
        }

        /// <summary>
        /// When owen is assigned the report ha to be present
        /// </summary>
        public bool ValidateReportDatePresence()
        {
            if (string.IsNullOrWhiteSpace(Owner)) return true;

            return ReportDate.HasValue;
        }

        /// <summary>
        /// When owen is assigned the due ha to be present
        /// </summary>
        public bool ValidateDueDatePresence()
        {
            if (string.IsNullOrWhiteSpace(Owner)) return true;

            return DueDate.HasValue;
        }

        /// <summary>
        /// When due and report date are present, due date has to be late or equal to report
        /// </summary>
        public bool ValidateDueDateAfterReportDate()
        {
            if (!DueDate.HasValue || !ReportDate.HasValue) return true;

            return DueDate.Value.Date >= ReportDate.Value.Date;
        }
    }
}
