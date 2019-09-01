using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.models
{
    class Token
    {
        private int idToken;
        private String valor;
        private int fila;
        private int columna;
        private TIPO tipo;

        public Token(int idToken, string valor, int fila, int columna, TIPO tipo)
        {
            this.idToken = idToken;
            this.valor = valor;
            this.fila = fila;
            this.columna = columna;
            this.tipo = tipo;
        }

        public int IdToken { get => idToken; set => idToken = value; }
        public string Valor { get => valor; set => valor = value; }
        public int Fila { get => fila; set => fila = value; }
        public int Columna { get => columna; set => columna = value; }

       

        public enum TIPO {
            DOS_PUNTOS,
            PALABRA_RESERVADA_PAIS,
            PALABRA_RESERVADA_SATURACION,
            PALABRA_RESERVADA_NOMBRE,
            PALABRA_RESERVADA_POBLACION,
            PALABRA_RESERVADA_BANDERA,
            PALABRA_RESERVADA_GRAFICA,
            PALABRA_RESERVADA_CONTINENTE,
            LLAVE_DERECHA,
            LLAVE_IZQUIERDA,
            CADENA,
            COMILLAS,
            PUNTO_Y_COMA,
            NUMERO,
            PORCENTAJE
        }

        

     

        public String getTipoToken() {
            switch (tipo) {
                case TIPO.PUNTO_Y_COMA:
                    return "PUNTO Y COMA";
                case TIPO.LLAVE_DERECHA:
                    return "LLAVE DERECHA";
                case TIPO.LLAVE_IZQUIERDA:
                    return "LLAVE IZQUIERDA";
                case TIPO.COMILLAS:
                    return "COMILLAS";
                case TIPO.CADENA:
                    return "CADENA";
                case TIPO.DOS_PUNTOS:
                    return "DOS PUNTOS";
                case TIPO.PALABRA_RESERVADA_BANDERA:
                    return "PALABRA RESERVADA BANDERA";
                case TIPO.PALABRA_RESERVADA_NOMBRE:
                    return "PALABRA RESERVADA NOMBRE";
                case TIPO.PALABRA_RESERVADA_PAIS:
                    return "PALABRA RESERVADA PAIS";
                case TIPO.PALABRA_RESERVADA_POBLACION:
                    return "PALABRA RESERVADA POBLACION";
                case TIPO.PALABRA_RESERVADA_SATURACION:
                    return "PALABRA RESERVADA SATURACION";
                case TIPO.PALABRA_RESERVADA_GRAFICA:
                    return "PALABRA RESERVADA GRAFICA";
                case TIPO.PALABRA_RESERVADA_CONTINENTE:
                    return "PALABRA RESERVADA CONTINENTE";
                case TIPO.NUMERO:
                    return "NUMERO";
                case TIPO.PORCENTAJE:
                    return "PORCENTAJE";
                default:
                    return "PALABRA DESCONOCIDA";

            }
        }



    }
}
