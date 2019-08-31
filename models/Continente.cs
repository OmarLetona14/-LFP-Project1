using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.models
{
    class Continente
    {
        private int idContinente;
        private String nombre;
        private List<Pais> paises;
        private int saturacion;
        private String color;

        public Continente(int idContinente, string nombre, List<Pais> paises, int saturacion, string color)
        {
            this.idContinente = idContinente;
            this.nombre = nombre;
            this.paises = paises;
            this.saturacion = saturacion;
            this.color = color;
        }

        public Continente() { }

        public int IdContinente { get => idContinente; set => idContinente = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Saturacion { get => saturacion; set => saturacion = value; }
        public string Color { get => color; set => color = value; }
        internal List<Pais> Paises { get => paises; set => paises = value; }
    }
}
