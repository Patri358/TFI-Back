using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.ReasonCancellation
{
    public class CreateReasonCancellationDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}