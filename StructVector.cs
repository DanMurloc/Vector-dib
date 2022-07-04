using System;

namespace RobMath
{

    struct Vector
    {
        private double x;
        private double y;
        private double z;

        private double[] vector;

        /// <summary>
        /// Инициализация точек конца вектора
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        public Vector(double X, double Y, double Z)
        {
            x = X;
            y = Y;
            z = Z;
            vector = new double[] { x, y, z };
        }

        /// <summary>
        /// Сложение двух векторов
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator +(Vector a, Vector b)
        {

            Vector d = new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
            return d;
        }
        /// <summary>
        /// Вычитание двух векторов
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator -(Vector a, Vector b)
        {

            Vector d = new Vector(a.x - b.x, a.y - b.y, a.z - b.z);
            return d;
        }
        /// <summary>
        ///Умножение двух векторов
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator *(Vector a, Vector b)
        {

            Vector d = new Vector((a.y * b.z - a.z * b.y), (-(a.x * b.z - a.z * b.x)), (a.x * b.y - a.y * b.x));
            return d;
        }
        /// <summary>
        /// Деление двух векторов (Не стоит) 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator /(Vector a, Vector b)
        {

            Vector d = new Vector((a.y / b.z - a.z / b.y), (-(a.x / b.z - a.z / b.x)), (a.x / b.y - a.y / b.x));
            return d;
        }

        /// <summary>
        /// Смещение
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public Vector Offset(double a, double b, double c)
        {
            Vector d = new Vector(x + a, y + b, z + c);
            double[] temp = new double[] { 0, 0, 0 };
            temp = d.vector;
            vector = temp;
            d.vector = vector;
            return d;
        }
        public double angleZ()
        {
            double fi;
            //длинна вектора
            double len = Math.Sqrt(vector[0] * vector[0] + vector[1] * vector[1] + vector[2] * vector[2]);
            //косинус фи
            fi = vector[2] / len;
            //  Console.WriteLine(len);
            fi = Math.Acos(fi);
            // Console.WriteLine(fi);
            return fi;
        }
        /// <summary>
        /// Вращение
        /// </summary>
        /// <param name="rotation"></param>
        /// <returns></returns>
        public Vector RotationZ()
        {
            double fi = -angleZ();

            Vector d = new Vector(Math.Cos(fi) * x + Math.Sin(fi) * y, -Math.Sin(fi) * x + y * Math.Cos(fi), z);
            double[] temp = new double[] { 0, 0, 0 };
            temp = d.vector;
            vector = temp;
            d.vector = vector;
            return d;
        }

        public Vector transform4(double a, double b, double c, double fi = 0)
        {
            double[] temp = new double[] { 0, 0, 0 };
            Vector d = new Vector(x, y, z);
            PrintPoint();
            d.Offset(a, b, c);
            temp = d.vector;
            vector = temp;
            d.vector = vector;
            d.PrintPoint();

            d.RotationZ();
            d.PrintPoint();

            return d;
        }
        
        public void PrintPoint()
        {
            double[] vec = new double[vector.Length];
            vec = vector;
            for (int i = 0; i < vec.Length; i++)
            {
                Console.Write(vec[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
