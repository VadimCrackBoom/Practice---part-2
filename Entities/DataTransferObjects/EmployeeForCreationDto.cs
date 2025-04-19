using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Entities.DataTransferObjects;

public class EmployeeForCreationDto: EmployeeForManipulationDto
{
    [Required(ErrorMessage = "Employee Name is a required field.")]
    [MaxLength(30, ErrorMessage = "Maximum lenght for the Name is 30 characters.")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Age is a required field.")]
    public int Age { get; set; }
    
    [Required(ErrorMessage = "Position is a required field.")]
    [MaxLength(20, ErrorMessage = "Maximum lenght for the Position is 20 characters.")]
    [Range(18, int.MaxValue, ErrorMessage = "Age is required and it can't be lower than 18.")]
    public string Position { get; set; }
}