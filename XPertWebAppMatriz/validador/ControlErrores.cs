using System;

namespace XPertWebAppMatriz.validador
{
    public class ControlErrores : Exception
    {

        private int codigoError;


        public ControlErrores(int codigo)
        {
            this.codigoError = codigo; 
        }

        public String getMessage()
        {
            String mensaje = "";

            switch (codigoError)
            {
                case 111:
                    mensaje = "Los casos de prueba deberan estar entre 1 a 50";
                    break;
                case 112:
                    mensaje = "La dimension de la matriz esta entre 1 a 100";
                    break;
                case 113:
                    mensaje = "La numero de operaciones esta entre 1 a 1000";
                    break;
                case 114:
                    mensaje = "El rango de los ejes será 1 <= x1 <= x2 <= N ";
                    break;
                case 115:
                    mensaje = "El rango de los ejes será 1 <= x,y,z <= N  ";
                    break;
                case 116:
                    mensaje = "El rango del peso debera ser  -10e9 <= W <= 10e9  ";
                    break;
            }



            return mensaje;
        }


    }
}