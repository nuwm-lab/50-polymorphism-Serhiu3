using System;


// Даний проект є шаблоном для виконання лабораторних робіт
// з курсу "Об'єктно-орієнтоване програмування та патерни проектування"
// Необхідно змінювати і дописувати код лише в цьому проекті
// Відео-інструкції щодо роботи з github можна переглянути 
// за посиланням https://www.youtube.com/@ViktorZhukovskyy/videos 


namespace LabWork.Geometry
{
    class Ellipse
    {
        protected double a;
        protected double b;

        public virtual void SetCoefficients(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public virtual void PrintCoefficients()
        {
            Console.WriteLine($"Ellipse coefficients: a = {a}, b = {b}");
        }

        public virtual bool IsPointOnCurve(double x, double y)
        {
            
            return Math.Abs((x * x) / (a * a) + (y * y) / (b * b) - 1) < 1e-6;
        }
    }

    class SecondOrderCurve : Ellipse
    {
        private double a11;
        private double a12;
        private double a22;
        private double b1;
        private double b2;
        private double c;

        public void SetCoefficients(double a11, double a12, double a22, double b1, double b2, double c)
        {
            this.a11 = a11;
            this.a12 = a12;
            this.a22 = a22;
            this.b1 = b1;
            this.b2 = b2;
            this.c = c;
        }

        public override void PrintCoefficients()
        {
            Console.WriteLine($"Second order curve coefficients: a11 = {a11}, a12 = {a12}, a22 = {a22}, b1 = {b1}, b2 = {b2}, c = {c}");
        }

        public override bool IsPointOnCurve(double x, double y)
        {
            return Math.Abs(a11 * x * x + 2 * a12 * x * y + a22 * y * y + b1 * x + b2 * y + c) < 1e-6;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Ellipse curve;

            Console.WriteLine("Choose the type of curve (1 for Ellipse, 2 for Second Order Curve):");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                curve = new Ellipse();
                Console.WriteLine("Enter the coefficients for the ellipse (a, b):");
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                curve.SetCoefficients(a, b);
            }
            else
            {
                curve = new SecondOrderCurve();
                Console.WriteLine("Enter the coefficients for the second order curve (a11, a12, a22, b1, b2, c):");
                double a11 = double.Parse(Console.ReadLine());
                double a12 = double.Parse(Console.ReadLine());
                double a22 = double.Parse(Console.ReadLine());
                double b1 = double.Parse(Console.ReadLine());
                double b2 = double.Parse(Console.ReadLine());
                double c = double.Parse(Console.ReadLine());
                ((SecondOrderCurve)curve).SetCoefficients(a11, a12, a22, b1, b2, c);
            }

            curve.PrintCoefficients();

            Console.WriteLine("Enter the point (x, y) to check if it lies on the curve:");
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            if (curve.IsPointOnCurve(x, y))
            {
                Console.WriteLine("The point lies on the curve.");
            }
            else
            {
                Console.WriteLine("The point does not lie on the curve.");
            }
        }
    }
}

