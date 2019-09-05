using Project1.models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1.helper
{
    class Analizador
    {


        private List<Token> listaTokens;
        public static Boolean lexicError;
        public static Boolean sintError;
        public static List<Error> listaErrores;
        private int estado;
        String auxLex;
        List<Char> signos = new List<Char> {'{', '}', ';', '"', ':', '%' };

        private void addToken(Token.TIPO tipo, int fila, int columna)
        {
            Token token = new Token(listaTokens.Count+1, auxLex,fila,columna, tipo);
            listaTokens.Add(token);
            auxLex = "";
        }

        private void addError(String lexema, int columna, int fila, String descripcion)
        {
            listaErrores.Add(new Error(listaErrores.Count + 1, lexema, columna, fila, descripcion));
            auxLex = "";
            lexicError = true;
        }


        private Boolean errorLexico(Char e)
        {
            Boolean error = false;

            foreach (Char c in signos)
            {
                if (c == e)
                {
                    error = true;
                }
            }
            return error;
        }

        public List<Token> analizar(String entrance, RichTextBox richText)
        {
            int columna = 0, fila = 1;
            listaTokens = new List<Token>();
            listaErrores = new List<Error>();
            estado = 0;
            int started=0;
            auxLex = "";
            Char c;
            for (int i = 0; i < entrance.Length; i++)
            {
                c = entrance.ElementAt(i);
                if (c != '\n')
                {

                    columna += 1;
                }
                else
                {
                    columna = 0;
                    fila += 1;
                }
                switch (estado)
                {
                    case 0:
                        if (Char.IsLetter(c))
                        {
                            if (auxLex.Length==0) {
                                started = i;
                            }
                            auxLex += c;
                        }

                        else if (c.Equals(':'))
                        {
                            richText.SelectionLength = auxLex.Length;
                            switch (auxLex.ToLower())
                            {
                                case "grafica":
                                    addToken(Token.TIPO.PALABRA_RESERVADA_GRAFICA, fila, columna-1);
                                    break;
                                case "nombre":
                                    addToken(Token.TIPO.PALABRA_RESERVADA_NOMBRE, fila, columna-1);
                                    break;
                                case "continente":
                                    addToken(Token.TIPO.PALABRA_RESERVADA_CONTINENTE, fila, columna-1);
                                    break;
                                case "pais":
                                    addToken(Token.TIPO.PALABRA_RESERVADA_PAIS, fila, columna-1);
                                    break;
                                case "poblacion":
                                    addToken(Token.TIPO.PALABRA_RESERVADA_POBLACION, fila, columna-1);
                                    break;
                                case "saturacion":
                                    addToken(Token.TIPO.PALABRA_RESERVADA_SATURACION, fila, columna-1);
                                    break;
                                case "bandera":
                                    addToken(Token.TIPO.PALABRA_RESERVADA_BANDERA, fila, columna-1);
                                    break;
                                default:
                                    addError(auxLex, columna, fila, "PALABRA O CARACTER DESCONOCIDO");
                                    break;
                            }
                            if (!lexicError)
                            {
                                richText.SelectionStart = started;
                                richText.SelectionColor = Color.Blue;
                                estado = 1;
                                auxLex += c;
                            }
                            addToken(Token.TIPO.DOS_PUNTOS,fila,columna);

                        }
                        else if (c.Equals('}'))
                        {
                            auxLex += c;
                            richText.SelectionStart = i;
                            richText.SelectionLength = auxLex.Length;
                            richText.SelectionColor = Color.Red;
                            addToken(Token.TIPO.LLAVE_DERECHA, fila, columna);
                        }
                        else
                        {
                            if (!Char.IsWhiteSpace(c))
                            {
                                if (!errorLexico(c))
                                {
                                    addError(Char.ToString(c), columna, fila, "CARACTER DESCONOCIDO");
                                }
                                else
                                {
                                    sintError = true;
                                }

                            }

                        }
                        break;
                    case 1:
                        if (c.Equals('{'))
                        {
                            auxLex += c;
                            richText.SelectionStart = i;
                            richText.SelectionLength = auxLex.Length;
                            richText.SelectionColor = Color.Red;
                            addToken(Token.TIPO.LLAVE_IZQUIERDA,fila,columna);
                            estado = 0;

                        }
                        else if (c.Equals('"'))
                        {
                            if (auxLex.Length == 0)
                            {
                                started = i;
                            }
                            estado = 2;
                            auxLex += c;
                            richText.SelectionStart = i;
                            richText.SelectionLength = auxLex.Length;
                            richText.SelectionColor = Color.Yellow;
                            addToken(Token.TIPO.COMILLAS,fila,columna);


                        }
                        else if (Char.IsDigit(c))
                        {
                            if (auxLex.Length == 0)
                            {
                                started = i;
                            }
                            estado = 3;
                            auxLex += c;
                        }
                        else
                        {
                            if (!Char.IsWhiteSpace(c))
                            {

                                if (!errorLexico(c))
                                {
                                    
                                    addError(Char.ToString(c), columna, fila, "CARACTER DESCONOCIDO");
                                }
                                else
                                {
                                    sintError = true;
                                }

                            }

                        }
                        break;
                    case 2:

                        if (c.Equals('"'))
                        {
                            richText.SelectionStart = started;
                            richText.SelectionLength = auxLex.Length+1;
                            richText.SelectionColor = Color.DarkGoldenrod;
                            addToken(Token.TIPO.CADENA,fila,columna-1);
                            auxLex += c;
                            richText.SelectionStart = i;
                            richText.SelectionLength = auxLex.Length;
                            richText.SelectionColor = Color.DarkGoldenrod;
                            addToken(Token.TIPO.COMILLAS,fila,columna);
                            estado = 4;
                        }
                        else {
                            auxLex += c;
                        }

                        break;
                    case 3:
                        if (Char.IsDigit(c))
                        {
                            auxLex += c;
                        } else if (c.Equals('%')) {
                            richText.SelectionStart = started;
                            richText.SelectionLength = auxLex.Length;
                            richText.SelectionColor = Color.Green;
                            addToken(Token.TIPO.NUMERO,fila,columna-1);
                            auxLex += c;
                            addToken(Token.TIPO.PORCENTAJE,fila,columna);
                            estado = 4;
                        }
                        else if (c.Equals(';')) {
                            richText.SelectionStart = started;
                            richText.SelectionLength = auxLex.Length;
                            richText.SelectionColor = Color.Green;
                            addToken(Token.TIPO.NUMERO,fila,columna);
                            auxLex += c;
                            richText.SelectionStart = i;
                            richText.SelectionLength = auxLex.Length;
                            richText.SelectionColor = Color.Orange;
                            addToken(Token.TIPO.PUNTO_Y_COMA,fila,columna);
                            estado = 0;
                        }
                        else
                        {
                            if (!Char.IsWhiteSpace(c))
                            {
                                if (!errorLexico(c))
                                {
                                    estado = 0;
                                    addError(Char.ToString(c), columna, fila, "CARACTER DESCONOCIDO");
                                }
                                else
                                {
                                    sintError = true;
                                }

                            }

                        }
                        break;

                    case 4:
                        if (c.Equals(';'))
                        {
                            auxLex += c;
                            richText.SelectionStart = i;
                            richText.SelectionLength = auxLex.Length;
                            richText.SelectionColor = Color.Orange;
                            addToken(Token.TIPO.PUNTO_Y_COMA,fila,columna);
                            estado = 0;
                        }
                        else
                        {
                            if (!Char.IsWhiteSpace(c))
                            {
                                if (!errorLexico(c))
                                {
                                    addError(Char.ToString(c), columna, fila, "CARACTER DESCONOCIDO");
                                }
                                else
                                {
                                    sintError = true;
                                }

                            }

                        }
                        break;

                    
                }


            }
            return listaTokens;
        }

        public void imprimirTokens()
        {
            foreach (Token mt in listaTokens)
            {
                Console.WriteLine(mt.IdToken + " | " + mt.Valor +
                   " | " + mt.getTipoToken());
            }


        }
    }
}
