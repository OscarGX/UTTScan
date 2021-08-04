using System;
using System.Collections.Generic;
using System.Text;

namespace UTTScan.ViewModels
{
    public class ControlAcceso
    {
        public DateTime Fecha { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
        public int Hora { get; set; }
        public int Mintos { get; set; }
        public int FkAlumno { get; set; }

    }
}
