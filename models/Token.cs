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
        private TIPO tipo;
        private COLOR color;

        public enum COLOR {
            AZUL,
            VERDE,
            AMARILLO,
            ROJO,
            ANARANJADO,
            NEGRO
        }


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

        public Token(int idToken, string valor, TIPO tipo)
        {
            this.idToken = idToken;
            this.valor = valor;
            this.tipo = tipo;
        }

        public int IdToken { get => idToken; set => idToken = value; }
        public string Valor { get => valor; set => valor = value; }

        public String getTipoToken() {
            switch (tipo) {
                case TIPO.PUNTO_Y_COMA:
                    color = COLOR.ROJO;
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
                    color = COLOR.AZUL;
                    return "PALABRA RESERVADA BANDERA";
                case TIPO.PALABRA_RESERVADA_NOMBRE:
                    color = COLOR.AZUL;
                    return "PALABRA RESERVADA NOMBRE";
                case TIPO.PALABRA_RESERVADA_PAIS:
                    color = COLOR.AZUL;
                    return "PALABRA RESERVADA PAIS";
                case TIPO.PALABRA_RESERVADA_POBLACION:
                    color = COLOR.AZUL;
                    return "PALABRA RESERVADA POBLACION";
                case TIPO.PALABRA_RESERVADA_SATURACION:
                    color = COLOR.AZUL;
                    return "PALABRA RESERVADA SATURACION";
                case TIPO.PALABRA_RESERVADA_GRAFICA:
                    color = COLOR.AZUL;
                    return "PALABRA RESERVADA GRAFICA";
                case TIPO.PALABRA_RESERVADA_CONTINENTE:
                    color = COLOR.AZUL;
                    return "PALABRA RESERVADA CONTINENTE";
                case TIPO.NUMERO:
                    color = COLOR.VERDE;
                    return "NUMERO";
                case TIPO.PORCENTAJE:
                    color = COLOR.NEGRO;
                    return "PORCENTAJE";
                default:
                    return "PALABRA DESCONOCIDA";

            }
        }



    }
}
