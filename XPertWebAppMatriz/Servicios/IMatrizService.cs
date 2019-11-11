using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPertWebAppMatriz.Servicios
{
    interface IMatrizService
    {
         void procesarDatosEnLaMatriz(List<String> matriz, int N);
         int calcularResultadosEnLaMatriz(int x, int y, int z);
         int calcularResultado(int x0, int y0, int z0, int x, int y, int z);
         void actualizarValoresEnLaMatriz(int size, int x, int y, int z, int valor);

         List<string> imprimirResultados();

         void llenarDatosMatriz(List<String> matriz, int T);
            
    }
}
