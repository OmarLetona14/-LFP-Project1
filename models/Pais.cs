using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.models
{
    class Pais
    {
        private int idPais;
        private String nombre;
        private String poblacion;
        private int saturacion;
        private String urlBandera;
        private String color;
        private Continente continente;

        public Pais(int idPais, string nombre, string poblacion, int saturacion, string urlBandera, string color, Continente continente)
        {
            this.IdPais = idPais;
            this.Nombre = nombre;
            this.Poblacion = poblacion;
            this.Saturacion = saturacion;
            this.UrlBandera = urlBandera;
            this.Color = color;
            this.Continente = continente;
        }

        public Pais() { }

        public int IdPais { get => idPais; set => idPais = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Poblacion { get => poblacion; set => poblacion = value; }
        public int Saturacion { get => saturacion; set => saturacion = value; }
        public string UrlBandera { get => urlBandera; set => urlBandera = value; }
        public string Color { get => color; set => color = value; }
        internal Continente Continente { get => continente; set => continente = value; }
    }
}
