using Project1.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.helper
{
    class GenerarGrafica
    {
        private Grafico grafico;
        private Continente continente;
        private Pais pais;
        private List<Continente> continentes;
        private List<Pais> paises;

        public Grafico generar(List<Token> salida) {
            for (int x = 0; x<salida.Count;x++) {

                if (salida[x].getTipoToken().Equals("PALABRA RESERVADA GRAFICA"))
                {
                    grafico = new Grafico();
                    grafico.Nombre = salida[x + 6].Valor;
                    continentes = new List<Continente>();
                    grafico.Continentes = continentes;

                } else if (salida[x].getTipoToken().Equals("PALABRA RESERVADA CONTINENTE")) {
                    continente = new Continente();
                    continente.IdContinente = continentes.Count + 1;
                    continente.Nombre = salida[x + 6].Valor;
                    paises = new List<Pais>();
                    continente.Paises = paises;
                    continentes.Add(continente);

                } else if (salida[x].getTipoToken().Equals("PALABRA RESERVADA PAIS")) {
                    pais = new Pais();
                    pais.IdPais = paises.Count + 1;
                    pais.Continente = continente;
                    int y = x;
                    while (!(salida[y+1].getTipoToken().Equals("PALABRA RESERVADA PAIS")) &&
                        !(salida[y + 1].getTipoToken().Equals("PALABRA RESERVADA CONTINENTE"))) {
                        if (salida[y].getTipoToken().Equals("PALABRA RESERVADA NOMBRE"))
                        {
                            pais.Nombre = salida[y + 3].Valor;
                        }
                        else if (salida[y].getTipoToken().Equals("PALABRA RESERVADA POBLACION"))
                        {
                            pais.Poblacion = salida[y + 2].Valor;
                        }
                        else if (salida[y].getTipoToken().Equals("PALABRA RESERVADA SATURACION"))
                        {
                            pais.Saturacion = Convert.ToInt32(salida[y + 2].Valor);
                            if (0 < pais.Saturacion && pais.Saturacion <= 15)
                            {
                                pais.Color = "white";
                            }
                            else if (16 <= pais.Saturacion && pais.Saturacion <= 30)
                            {
                                pais.Color = "blue";
                            }
                            else if (31 <= pais.Saturacion && pais.Saturacion <= 45)
                            {
                                pais.Color = "green";
                            }
                            else if (46 <= pais.Saturacion && pais.Saturacion <= 60)
                            {
                                pais.Color = "yellow";
                            }
                            else if (61 <= pais.Saturacion && pais.Saturacion <= 75)
                            {
                                pais.Color = "orange";
                            }
                            else if (76 <= pais.Saturacion && pais.Saturacion <= 100)
                            {
                                pais.Color = "red";
                            }

                        }
                        else if (salida[y].getTipoToken().Equals("PALABRA RESERVADA BANDERA"))
                        {
                            pais.UrlBandera = salida[y + 3].Valor;
                        }
                        if (y + 2 == salida.Count)
                        {
                            break;
                        }
                        else {
                            y++;
                        }
                        
                    }
                    paises.Add(pais);
                }
            }

            return calcularSaturacionContinente(grafico);
        }

        private Grafico calcularSaturacionContinente(Grafico grafico)
        {
            foreach (Continente c in grafico.Continentes) {
                int saturaciones= 0;
                foreach (Pais p in c.Paises) {
                    saturaciones += p.Saturacion;
                }
                c.Saturacion = (saturaciones) / (c.Paises.Count);
                if (0 < c.Saturacion && c.Saturacion <= 15)
                {
                    c.Color = "white";
                }
                else if (16 <= c.Saturacion && c.Saturacion <= 30)
                {
                    c.Color = "blue";
                }
                else if (31 <= c.Saturacion && c.Saturacion <= 45)
                {
                    c.Color = "green";
                }
                else if (46 <= c.Saturacion && c.Saturacion <= 60)
                {
                    c.Color = "yellow";
                }
                else if (61 <= c.Saturacion && c.Saturacion <= 75)
                {
                    c.Color = "orange";
                }
                else if (76 <= c.Saturacion && c.Saturacion <= 100)
                {
                    c.Color = "red";
                }
            }
            return grafico;
        }


        private Boolean verificarPais(Pais pais, List<Pais> paises)
        {
            Boolean exists=false;
            foreach (Pais p in paises) {
                if (p==pais) {
                    exists = true;
                }
            }
            return exists;
        }

        private Boolean verificarContinente(Continente continente, List<Continente> continentes) {
            Boolean exists = false;
            foreach (Continente con in continentes) {
                if (con == continente) {
                    exists = true;
                }
            }
            return exists;
        }
    }
}
