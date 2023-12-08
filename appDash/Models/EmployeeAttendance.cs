using System;

namespace appDash.Models
{
    public class EmployeeAttendance
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; } // Identificador del empleado
        public DateTime EntryTime { get; set; } // Fecha y hora de entrada
        public DateTime? ExitTime { get; set; }  // Fecha y hora de salida (puede ser nulo si el empleado aún no ha salido)

        // Otras propiedades relacionadas con los registros de entrada y salida

        // Relación con el empleado
        public Employee Employee { get; set; }
    }
}
