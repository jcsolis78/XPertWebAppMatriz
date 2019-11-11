using System;

namespace XPertWebAppMatriz
{
    public class ValidMatrixData
    {
        public bool validarCasosDePrueba(int T)
        {
            return (T > 0 && T <= 50) ;  
        }

        public bool ValidMatrixSize(int n)
        {
            return (n > 0 && n <= 100) ; 
        }

        public bool validMatrixOperation(int m)
        {
            return (m > 0 && m <= 100) ; 
        }

        public bool validarMatrixAxis(int axisx, int axisy, int n)
        {
            return ((axisx > 0 && axisx <= n) && (axisy > 0 && axisy <= n) && (axisx <= axisy)); 
        }

        public bool validRangeMatrix(int axisx, int n)
        {
            return (axisx > 0 && axisx <= n); 
        }

        public bool validValueMatrix(int W)
        {
            return (W >= -Math.Pow(10, 9) && W <= Math.Pow(10, 9));
        }
    }
}
