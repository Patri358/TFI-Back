using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.Dog
{
    public class BreedDTO
    {
        public string Name { get; init; } = string.Empty; 
        public List<string> SubBreeds { get; init; } = [];
    }
}
