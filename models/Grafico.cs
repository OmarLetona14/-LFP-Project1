using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.models
{
    class Grafico
    {
        private String nombre;
        private List<Continente> continentes;

        public Grafico(string nombre, List<Continente> continentes)
        {
            this.nombre = nombre;
            this.continentes = continentes;
        }

        public Grafico() { }

        public string Nombre { get => nombre; set => nombre = value; }
        internal List<Continente> Continentes { get => continentes; set => continentes = value; }
    }
}
