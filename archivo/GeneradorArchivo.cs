using Project1.models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1.archivo
{
    class GeneradorArchivo
    {
        StreamWriter sw;
        String dotfilename;

        public void generateHTMLTokensFile(List<Token> tokens, String filename)
        {
            String init;
            try
            {
                sw = new StreamWriter(filename);
                init = "<html>" +
                    "<head>" +
                     "<link rel=\"stylesheet\" type=\"text/css\" href=\"css/bootstrap.min.css\" >"
                    + "<script type=\"text/javascript\" src=\"js/bootstrap.min.js\"></script>"
                    + "<script type=\"text/javascript\" src=\"js/jquery-3.4.1.min.js\"></script>"
                    + "<style type=\"text/css\">"
                    + "table th{ text-align: center;} td{text-align: center;}"
                    + "</style>"
                    + "</head>" +
                    "<body>" +
                        "<table class=\"table table-dark\">" +
                        "<tr>" +
                            "<th scope=\"col\"> Numero </th>" +
                            "<th scope=\"col\"> Lexema </th>" +
                            "<th scope=\"col\"> Tipo </th>" +
                            "<th scope=\"col\"> Fila </th>" +
                            "<th scope=\"col\"> Columna </th>" +
                          "</tr>";
                foreach (Token token in tokens)
                {
                    init += "<tr>"
                        + "<td >" + token.IdToken+ "</td>"
                        + "<td>" + token.Valor + "</td>"
                        + "<td>" + token.getTipoToken() + "</td>"
                        + "<td>" + token.Fila + "</td>"
                        + "<td>" + token.Columna + "</td>"
                    + "</tr>";
                }
                init += "</body>" +
                    "</html> ";
                sw.Write(init);
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            sw.Close();
        }


        public void generateErrorsHTMLFile(List<Error> errores, String filename)
        {

            String init;
            try
            {
                sw = new StreamWriter(filename);
                init = "<html>" +
                    "<head>"
                    + "<link rel=\"stylesheet\" type=\"text/css\" href=\"css/bootstrap.min.css\" >"
                    + "<script type=\"text/javascript\" src=\"js/bootstrap.min.js\"></script>"
                    + "<script type=\"text/javascript\" src=\"js/jquery-3.4.1.min.js\"></script>"
                    + "</head>" +
                    "<body>" +
                        "<table class=\"table table-dark\" style= \"text - align:center;\" >" +
                        "<tr>" +
                            "<th> Numero de error </th>" +
                            "<th> Error </th>" +
                            "<th> Descripcion </th>" +
                            "<th> Fila </th>" +
                            "<th> Columna </th>" +
                          "</tr>";
                foreach (Error error in errores)
                {

                    init += "<tr>"
                            + "<td>" + error.NoError + "</td>"
                            + "<td>" + error.Caracter + "</td>"
                            + "<td>" + error.Descripcion + "</td>"
                            + "<td>" + error.Fila + "</td>"
                            + "<td>" + error.Columna + "</td>"                          
                        + "</tr>";
                }
                init += "</body>" +
                    "</html> ";
                sw.Write(init);
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            sw.Close();


        }


        public void generateProcess(String graphname, String tipoDocumento)
        {
            Process proc = new Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "cmd";
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.CreateNoWindow = false;
            proc.StartInfo.UseShellExecute = false;
            proc.Start();
            proc.StandardInput.WriteLine("dot"+" -T"+tipoDocumento +" " + dotfilename + " -o " + graphname);
            proc.StandardInput.Flush();
            proc.StandardInput.Close();
            proc.Close();
            System.Threading.Thread.Sleep(3000);
            
        }

        public void generateDOTArchive(Grafico grafico, String filename)
        {
            String init = "";
            try
            {
                dotfilename = filename;
                sw = new StreamWriter(filename);
                init = "digraph G {" + "\n";
                init += "start[shape=Mdiamond label=" + "\"" + grafico.Nombre + "\"" + "];" + "\n";
                foreach (Continente continente in grafico.Continentes)
                {
                    init += "start->" + continente.Nombre +";"+ "\n";
                    init += continente.Nombre + "[shape=record label=" + "\"{" 
                        + continente.Nombre + "|" +continente.Saturacion+ "}\""
                        +" style=filled fillcolor="+continente.Color+ "];" + "\n";
                    foreach (Pais p in continente.Paises) {
                        init += continente.Nombre + "->" + p.Nombre+";"+ "\n";
                        init+= p.Nombre+ "[shape=record label=" + "\"{"
                        + p.Nombre + "|" + p.Saturacion + "}\""
                        + " style=filled fillcolor=" + p.Color + "];" + "\n";
                    }                   
                }
                init += "}";
                sw.Write(init);
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            sw.Close();

        }

    }
}
