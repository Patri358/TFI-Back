using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.ReasonConsultation
{
    public class ReasonConsultationDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
