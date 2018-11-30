using System;
namespace PalcoNet.Utils {
    public static class Fechas {

        public static DateTime[] getRango(int trimestre, int año) {
            if (trimestre < 1 || trimestre > 4) {
                throw new ArgumentOutOfRangeException("El trimestre debe ser uno de: 1,2,3 o 4");
            }
            var desde = new DateTime(año,(trimestre-1)*3+1,1);
            var hasta = new DateTime(año, (trimestre - 1) * 3 + 3, 1);
            return new DateTime[]{desde,hasta};
        }
    }
}