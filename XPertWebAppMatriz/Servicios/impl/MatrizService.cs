using System;
using System.Collections.Generic;
using XPertWebAppMatriz.validador; 

namespace XPertWebAppMatriz.Servicios.impl
{
    public class MatrizService : IMatrizService
    {
        private ValidMatrixData validador = new ValidMatrixData(); 
        private List<string> resultados = new List<string>();
        private int[,,] matriz = new int[101,101,101];


        public void llenarMatriz()
        {
            int size = 100; 

            for (int ejeX = 0; ejeX < size; ejeX++)
            {
                for (int ejeY = 0; ejeY < size; ejeY++)
                {
                    for (int ejeZ = 0; ejeZ < size; ejeZ++)
                    {                        
                        matriz[ejeX,ejeY,ejeZ] = 0;
                    }
                }
            }

        }
        public void procesarDatosEnLaMatriz(List<string> matriz, int N)
        {
            string[] datosObtenidos;
            int n = 0; 
            int x, y, z, x0, y0, z0, val;
           

            int resultado; 

   
            n = N; 

            llenarMatriz(); 

  
                foreach (var items in matriz)
                {
                    datosObtenidos = items.Split(' ');

                    switch (datosObtenidos[0].ToUpper())
                    {
   

                        case "QUERY":

                            x0 = Int32.Parse(datosObtenidos[1]);
                            y0 = Int32.Parse(datosObtenidos[2]);
                            z0 = Int32.Parse(datosObtenidos[3]);
                            x = Int32.Parse(datosObtenidos[4]);
                            y = Int32.Parse(datosObtenidos[5]);
                            z = Int32.Parse(datosObtenidos[6]);

               				if (!validador.validarMatrixAxis(x0, x, n)) {
					            throw new ControlErrores(114);
				            }
                            if (!validador.validarMatrixAxis(y0, y, n))
                            {
					            throw new ControlErrores(114);
				            }
                            if (!validador.validarMatrixAxis(z0, z, n))
                            {
					            throw new ControlErrores(114);
				            }

                            resultado = calcularResultado(x0, y0, z0, x, y, z);

                            resultados.Add(resultado.ToString() + Environment.NewLine); 

                            break;

                       case "UPDATE":

                            x = Int32.Parse(datosObtenidos[1]);
                            y = Int32.Parse(datosObtenidos[2]);
                            z = Int32.Parse(datosObtenidos[3]);
                            val = Int32.Parse(datosObtenidos[4]);
                            x0 = x;
                            y0 = y;
                            z0 = z;

               				if (!validador.validRangeMatrix(x, n)) {
					            throw new ControlErrores(115);
				            }
               				if (!validador.validRangeMatrix(y, n)) {
					            throw new ControlErrores(115);
				            }
               				if (!validador.validRangeMatrix(z, n)) {
					            throw new ControlErrores(115);
				            }
                            if(!validador.validValueMatrix(val)){
                                throw new ControlErrores(116);
                            }

                            resultado = calcularResultado(x0, y0, z0, x, y, z); 

                            actualizarValoresEnLaMatriz(n, x, y, z, val - resultado); 

                            break;
                    }
 
                    

                }

        }

        public int calcularResultadosEnLaMatriz(int x, int y, int z)
        {
            int xP, yP, resultado = 0;

            while (z > 0)
            {
                xP = x;
                while (xP > 0)
                {
                    yP = y;
                    while (yP > 0)
                    {
                        resultado += matriz[xP,yP,z];
                        yP -= (yP & -yP); 
                    }
                    xP -= (xP & -xP); 
                }
                z -= (z & -z); 
            }
            return resultado; 
        }

        public void actualizarValoresEnLaMatriz(int size, int x, int y, int z, int valor)
        {
            int xP, yP; 

            while(z <= size){
                xP = x; 
                while(xP <= size){
                    yP = y; 
                    while(yP <= size){
                        matriz[xP,yP,z] += valor;
                        yP += (yP & -yP); 
                    }
                    xP += (xP & -xP);  
                }
                z += (z & -z); 
            }
            
        }


        public int calcularResultado(int x0, int y0, int z0, int x, int y, int z)
        {
            int value1, value2; 

            value1 = calcularResultadosEnLaMatriz(x, y, z) - calcularResultadosEnLaMatriz(x0 - 1, y, z)
             - calcularResultadosEnLaMatriz(x, y0 - 1, z) + calcularResultadosEnLaMatriz(x0 - 1, y0 - 1, z);

            value2 = calcularResultadosEnLaMatriz(x, y, z0 - 1) - calcularResultadosEnLaMatriz(x0 - 1, y, z0 - 1)
                    - calcularResultadosEnLaMatriz(x, y0 - 1, z0 - 1) + calcularResultadosEnLaMatriz(x0 - 1, y0 - 1, z0 - 1);

            return value1 - value2; 

        }




        public List<string> imprimirResultados()
        {
            return resultados; 
        }


        public void llenarDatosMatriz(List<string> matriz, int T)
        {
            List<string> cargarDatos = new List<string>();
            string[] datosObtenidos;
            int n = 0, m = 0;


            if (!validador.validarCasosDePrueba(T))
            {
                throw new ControlErrores(111);
            }


            while (T > 0)
            {
                foreach (var items in matriz) { 

                    datosObtenidos = items.Split(' ');

                    if (datosObtenidos[0].ToUpper() == "NM") { 

                        n = Int32.Parse(datosObtenidos[1]);
                        m = Int32.Parse(datosObtenidos[2]);

                        if (!validador.ValidMatrixSize(n))
                        {
                            throw new ControlErrores(112);
                        }
                        if (!validador.validMatrixOperation(m))
                        {
                            throw new ControlErrores(113);
                        }
                    }
                    else
                    {
                        if (m > 0)
                        {
                            cargarDatos.Add(items); 
                            m--;
                        }
                        if (m == 0 && T > 0)
                        {
                            procesarDatosEnLaMatriz(cargarDatos, n);
                            cargarDatos.Clear();
                            T--;
                        }
                    }

                }

                
            }


        }
    }
}