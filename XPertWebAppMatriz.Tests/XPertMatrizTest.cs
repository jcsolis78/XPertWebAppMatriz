using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XPertWebAppMatriz;
using System.Collections.Generic;
using XPertWebAppMatriz.Servicios.impl; 

namespace XPertWebAppMatriz.Tests
{
    [TestClass]
    public class XPertMatrizTest
    {

        ValidMatrixData validMatrix = new ValidMatrixData();
        MatrizService matrizService = new MatrizService(); 
        
        int T, n, m;
        int axisx, axisy, axisz, W;
        List<String> cargarDatos = new List<string>(); 
        List<string> respuesta = new List<string>();
            

        [TestInitialize]
        public void setUp()
        {
            T = 2;
            n = 4;
            m = 5;
            axisx = 1;
            axisy = 1;
            axisz = 1; 
            W = 2;
            //cargarDatos[0] = "T 2";
            cargarDatos.Add("NM 4 5" + Environment.NewLine);
            cargarDatos.Add( "UPDATE 2 2 2 4" + Environment.NewLine);
            cargarDatos.Add("QUERY 1 1 1 3 3 3" + Environment.NewLine);
            cargarDatos.Add("UPDATE 1 1 1 23" + Environment.NewLine);
            cargarDatos.Add("QUERY 2 2 2 4 4 4" + Environment.NewLine);
            cargarDatos.Add("QUERY 1 1 1 3 3 3" + Environment.NewLine);
            cargarDatos.Add("NM 2 4" + Environment.NewLine);
            cargarDatos.Add("UPDATE 2 2 2 1" + Environment.NewLine);
            cargarDatos.Add("QUERY 1 1 1 1 1 1" + Environment.NewLine);
            cargarDatos.Add("QUERY 1 1 1 2 2 2" + Environment.NewLine);
            cargarDatos.Add("QUERY 2 2 2 2 2 2" + Environment.NewLine);


            respuesta.Add("4" + Environment.NewLine);
            respuesta.Add("4" + Environment.NewLine);
            respuesta.Add("27" + Environment.NewLine);
            respuesta.Add("0" + Environment.NewLine);
            respuesta.Add("1" + Environment.NewLine);
            respuesta.Add("1" + Environment.NewLine); 
        }

        [TestMethod]
        public void validTestCase()
        {

            
                        
            Boolean TestCase = validMatrix.validarCasosDePrueba(T);

            Assert.AreEqual(true, TestCase); 
        }

        [TestMethod]
        public void validMatrixsize()
        {
            

            Boolean matrixSize = validMatrix.ValidMatrixSize(n);

            Assert.AreEqual(true, matrixSize); 
             
        }

        [TestMethod]
        public void validMatrixOperations()
        {
            

            Boolean matrixOperations = validMatrix.validMatrixOperation(m);

            Assert.AreEqual(true, matrixOperations); 
                 
        }

        [TestMethod]
        public void validAxis(){
            Boolean matrixAxisX = validMatrix.validarMatrixAxis(axisx, axisy, n);

            Assert.AreEqual(true, matrixAxisX); 
        }

        [TestMethod]
        public void validRange()
        {
            Boolean range = validMatrix.validRangeMatrix(axisx, n);
            Assert.AreEqual(true, range); 
        }

        [TestMethod]
        public void validValue()
        {
            Boolean value = validMatrix.validValueMatrix(W);
            Assert.AreEqual(true, value);
        }

        [TestMethod]
        public void procesarDatosMatriz()
        {
    

            List<string> esperado = new List<string>(); 

            matrizService.llenarDatosMatriz(cargarDatos, T);
            esperado = matrizService.imprimirResultados();


            Assert.AreEqual(esperado[0].ToString(), respuesta[0].ToString());
            Assert.AreEqual(esperado[3].ToString(), respuesta[3].ToString()); 

        }
    }
}