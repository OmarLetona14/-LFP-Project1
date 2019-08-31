using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.models
{
    class Error
    {
        private int noError;
        private String caracter;
        private int columna;
        private int fila;
        private String descripcion;

        public Error(int noError, string caracter, int columna, int fila, string descripcion)
        {
            this.NoError = noError;
            this.Caracter = caracter;
            this.Columna = columna;
            this.Fila = fila;
            this.Descripcion = descripcion;
        }

        public int NoError { get => noError; set => noError = value; }
        public string Caracter { get => caracter; set => caracter = value; }
        public int Columna { get => columna; set => columna = value; }
        public int Fila { get => fila; set => fila = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
