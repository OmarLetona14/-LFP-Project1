using Project1.archivo;
using Project1.helper;
using Project1.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Project1
{
    public partial class PantallaPrincipal : Form
    {
        private String tab_name, Sa_filename, Op_filename, currentFile, html_tokensFile, generateImg;
        private int page_count, contador = 1;
        RichTextBox codeTxt;
        LeerArchivo reader;
        SaveFileDialog saveFile;
        OpenFileDialog openFile;
        Analizador analizar;
        Grafico grafico;
        List<Token> salidaTokens;
        GenerarGrafica gGraphic;
        GeneradorArchivo generador;
        Pais paisEncontrado;
        public PantallaPrincipal()
        {
            InitializeComponent();
        }

        private void AcerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void NuevaPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            crearPestania();
        }

        private void crearPestania()
        {
            if (!btnAnalizar.Enabled)
            {
                btnAnalizar.Enabled = true;
            }
            tab_name = "Tab" + page_count;
            TabPage tab = new TabPage()
            {
                Text = "Pestaña " + page_count,
                Name = tab_name
            };
            codeTxt = new RichTextBox()
            {
                Dock = DockStyle.Fill,
                AcceptsTab = true,
            };
            codeTxt.Name = "CodeTxt";
            tab.Controls.Add(codeTxt);
            tabControl.Controls.Add(tab);
            page_count += 1;
            tabControl.SelectedTab = tab;
        }

        private void GuardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl != null && tabControl.SelectedTab != null)
            {
                if (tabControl.SelectedTab.Text == "")
                {

                    guardarComo();
                }
                else
                {
                    if (File.Exists(tabControl.SelectedTab.Text))
                    {
                        guardar(tabControl.SelectedTab.Text);
                    }
                    else
                    {
                        guardarComo();
                    }
                }
            }
            else
            {
                guardarComo();
            }
        }

        private void guardar(String route)
        {
            reader = new LeerArchivo();
            reader.SaveFile(route, getTextBox(null));
        }

        public void guardarComo()
        {
            reader = new LeerArchivo();
            saveFile = new SaveFileDialog();
            saveFile.Filter = "Archivos de entrada(*.org)|*.org";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Sa_filename = saveFile.FileName;
                reader.SaveFile(Sa_filename, getTextBox(null));
                tabControl.SelectedTab.Text = Sa_filename;
            }

            saveFile.Dispose();
        }

        private void AbrirArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl.TabCount == 0)
            {
                abrirArchivo(true);
            }
            else
            {
                if (getTextBox(null).Text == "")
                {
                    abrirArchivo(false);
                }
                else
                {
                    abrirArchivo(true);
                }
            }
        }

        private void GuardarCómoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guardarComo();
        }

        private void BtnAnalizar_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab != null) {

                if (!getTextBox(null).Text.Equals(""))
                {
                    limpiarCampos();
                    generador = new GeneradorArchivo();
                    analizar = new Analizador();
                    salidaTokens = new List<Token>();
                    salidaTokens = analizar.analizar(getTextBox(null).Text, getTextBox(null));
                    if (!Analizador.lexicError)
                    {

                        html_tokensFile = "tokens.html";
                        generateImg = "graphic" + contador + ".png";

                        analizar.imprimirTokens();
                        generador.generateHTMLTokensFile(salidaTokens, html_tokensFile);
                        Process.Start(html_tokensFile);
                        gGraphic = new GenerarGrafica();
                        grafico = new Grafico();
                        grafico = gGraphic.generar(salidaTokens);
                        generador.generateDOTArchive(grafico, "Grafico.dot");
                        btnGenerarPDF.Enabled = true;
                        generador.generateProcess(generateImg, "png");
                        paisEncontrado = new Pais();
                        paisEncontrado = encontrar(grafico);
                        generarDescripcion(generateImg, paisEncontrado);
                        contador += 1;
                    }
                    else
                    {
                        getTextBox(null).SelectionStart = 0;
                        getTextBox(null).SelectionLength = getTextBox(null).Text.Length;
                        getTextBox(null).SelectionColor = Color.Black;
                        detailsContainer.Panel1.Controls.Clear();
                        limpiarCampos();
                        html_tokensFile = "erroes.html";
                        generador.generateErrorsHTMLFile(Analizador.listaErrores, html_tokensFile);
                        MessageBox.Show("Ocurrió un error al leer el código", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Analizador.lexicError = false;
                        Process.Start(html_tokensFile);
                    }
                }


            }


        }

        public System.Drawing.Image resize(int newWidth, int newHeight, System.Drawing.Image srcImage)
        {
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics gr = Graphics.FromImage(newImage))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(srcImage, new System.Drawing.Rectangle(0, 0, newWidth, newHeight));
            }
            return newImage;
        }

        private void generarDescripcion(String urlImagen, Pais pElegido) {
            if (File.Exists(urlImagen))
            {
                detailsContainer.Panel1.Controls.Clear();
                Label imgLabel = new Label()
                {
                    Dock = DockStyle.Fill,
                    Image = resize(detailsContainer.Panel1.Width, detailsContainer.Panel1.Height, System.Drawing.Image.FromFile(urlImagen))
                };
                detailsContainer.Panel1.Controls.Add(imgLabel);

                Panel Bpanel = (Panel)detailsContainer.Panel2.Controls.Find("banderaPanel", true).First();
                Bpanel.Controls.Clear();
                if (File.Exists(pElegido.UrlBandera)) {
                    Label imgBandera = new Label()
                    {
                        Dock = DockStyle.Fill,
                        Image = resize(Bpanel.Width, Bpanel.Height, System.Drawing.Image.FromFile(pElegido.UrlBandera))
                    };
                    Bpanel.Controls.Add(imgBandera);
                }

                Label nombre = (Label)detailsContainer.Panel2.Controls.Find("nombrePaisLbl", true).First();
                Label poblacion = (Label)detailsContainer.Panel2.Controls.Find("poblacionPaisLbl", true).First();
                nombre.Text = "";
                poblacion.Text = "";
                nombre.Text += "Nombre: " + pElegido.Nombre;
                poblacion.Text += "Poblacion: " + pElegido.Poblacion;

            }
            else {
                MessageBox.Show("No se ha creado el archivo");
            }
        }

        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void BtnCerrarPestania_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab != null)
            {
                limpiarCampos();
                tabControl.SelectedTab.Dispose();
                page_count -= 1;
            }

        }

        private void PantallaPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void ManualDeLaAplicaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String manual_path = "Manual de usuario.pdf";
            if (File.Exists(manual_path))
            {
                Process.Start(manual_path);
            }
            else {
                MessageBox.Show("El manual de usuario no se encontró");
            }
            
        }

        private void BtnGenerarPDF_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab!=null) {
                if (!getTextBox(null).Text.Equals("")) {
                    String pdf = "reporte"+contador+".pdf";
                    generador.generarReportePDF(pdf, generateImg, paisEncontrado);
                    Process.Start(pdf);
                }
                else
                {

                    MessageBox.Show("No ha introducido ningun archivo valido para generar el reporte");
                    
                }

            }
            else
            {

                MessageBox.Show("No ha introducido ningun archivo valido para generar el reporte");
            }
            
        }

        Pais encontrar(Grafico graph) {
            Pais p = new Pais();
            if (graph !=null) {
                int min = 0;

                List<Pais> minPaises = new List<Pais>();
                List<Pais> finish = new List<Pais>();
                foreach (Continente c in graph.Continentes)
                {

                    min = c.Paises.Min(y => y.Saturacion);
                    IEnumerable<Pais> query = c.Paises.Where(x => x.Saturacion == min);
                    foreach (Pais pM in query.ToList())
                    {
                        minPaises.Add(pM);
                    }
                }
                min = minPaises.Min(y => y.Saturacion);
                IEnumerable<Pais> q = minPaises.Where(x => x.Saturacion == min);
                finish = q.ToList();
                if (finish.Count == 1)
                {
                    p = finish.First();
                }
                else
                {
                    int minCon = finish.Min(z => z.Continente.Saturacion);
                    IEnumerable<Pais> qu = finish.Where(x => x.Continente.Saturacion == minCon);
                    p = finish.First();
                }
            }
            return p;
        }

        private void limpiarCampos() {
            detailsContainer.Panel1.Controls.Clear();
            Panel p = (Panel)detailsContainer.Panel2.Controls.Find("banderaPanel", true).First();
            p.Controls.Clear();
            Label nPais = (Label)detailsContainer.Panel2.Controls.Find("nombrePaisLbl", true).First();
            Label pPais = (Label)detailsContainer.Panel2.Controls.Find("poblacionPaisLbl", true).First();
            pPais.Text = "";
            nPais.Text = "";

        }

        private void abrirArchivo(Boolean nuevo)
        {
            openFile = new OpenFileDialog();
            openFile.Filter = "Archivos de entrada(*.org)|*.org";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                if (nuevo)
                {
                    crearPestania();
                }
                currentFile = "";
                reader = new LeerArchivo();
                Op_filename = openFile.FileName;
                currentFile = Op_filename;
                if (nuevo)
                {
                    reader.ReadArchive(Op_filename, getTextBox(tab_name));
                   
                }
                else
                {
                    reader.ReadArchive(Op_filename, getTextBox(null));
         
                }

            }
            if (Op_filename != null)
            {
                foreach (TabPage tab in tabControl.TabPages)
                {
                    if (tab.Name == tab_name)
                    {
                        tab.Text = Op_filename;
                    }
                }
                if (!btnAnalizar.Enabled)
                {
                    btnAnalizar.Enabled = true;
                }
            }
            openFile.Dispose();

        }

        private void AcercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Universidad de San Carlos de Guatemala \n" +
                "Programador: Erick Omar Letona Figueroa \n" +
                "Carnet: 201700377 \n" +
                "Lenguajes formales y de programacion", "Información", MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
        }

        public RichTextBox getTextBox(String tab_name)
        {
            if (tab_name == null)
            {
                RichTextBox txtBox = null;
                if (tabControl.TabCount != 0)
                {
                    foreach (Control control in tabControl.SelectedTab.Controls)
                    {
                        if (control.Name == "CodeTxt")
                        {
                            txtBox = new RichTextBox();
                            txtBox = (RichTextBox)control;
                        }
                    }
                }
                return txtBox;
            }
            else
            {
                RichTextBox txtBox = null;
                if (tabControl.TabCount != 0)
                {
                    foreach (TabPage tab in tabControl.TabPages)
                    {
                        if (tab.Name == tab_name)
                        {
                            foreach (Control control in tab.Controls)
                            {
                                txtBox = new RichTextBox();
                                txtBox = (RichTextBox)control;
                            }
                        }
                    }
                }
                return txtBox;
            }

        }
    }
}
