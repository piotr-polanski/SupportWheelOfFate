using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain.Repository
{
    [Table("SupportEngineers")]
    public class SupportEngineerDto
    {
        public SupportEngineerDto()
        {
            
        }
        public SupportEngineerDto(string name, ICollection<Shift> shiftLog)
        {
            Name = name;
            ShiftLog = shiftLog;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Shift> ShiftLog { get; set; }
    }
}