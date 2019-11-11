using System;
using System.Collections.Generic;
using XPertWebAppMatriz.validador;
using XPertWebAppMatriz.Servicios.impl; 

namespace XPertWebAppMatriz
{
    public partial class index : System.Web.UI.Page
    {

        private List<string> listaDatos = new List<string>(); 
        private ValidMatrixData validador = new ValidMatrixData();
        private MatrizService matrizService = new MatrizService(); 
        private int T;

        protected void Page_Load(object sender, EventArgs e)
        {

            
        }

        protected void cmdCalcular_Click(object sender, EventArgs e)
        {
            T = Int32.Parse(txtT.Text);
            char[] delimiter = { '\r', '\n' };
            string[] lista = txtIngreso.Text.Split(delimiter);

            foreach (var dato in lista) {
                if (dato.Length > 0)
                { 
                listaDatos.Add(dato);
                }
            }


            matrizService.llenarDatosMatriz(listaDatos, T); 

            foreach(var dato in matrizService.imprimirResultados()){
               
                txtResultado.Text += dato;
                
            }
            
        }

        protected void cmdReg_Click(object sender, EventArgs e)
        {            
            //listaDatos.Add(txtDato.Text);
            txtIngreso.Text += txtDato.Text + Environment.NewLine;
            txtDato.Text = ""; 
        }


    }
}