using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_03
{
    public partial class Enrolle
    {
        private static int counter = 0;

        public string name { get; set; }
        private readonly int age;
        private int ctPoints;

        public int Age
        {
            get { return age; }
        }

        public int CTPoints
        {
            get { return ctPoints; }
            set { ctPoints = value; }
        }


        public Enrolle()
        {
            name = "unknown";
            age = -1;
            ctPoints = -1;
            counter++;
        }

        public Enrolle(string name, int age, int ctPoints)
        {
            this.name = name;
            this.age = age;
            this.ctPoints = ctPoints;
            counter++;
        }

        public Enrolle(Enrolle existingEnrolle)
        {
            this.name = existingEnrolle.name;
            this.age = existingEnrolle.age;
            this.ctPoints = existingEnrolle.ctPoints;
            counter++;
        }

        static Enrolle()
        {
            Console.WriteLine("Created first Enrolle!");
        }

        ~Enrolle()
        {
            Console.Beep();
        }


        public static void DisplayCounter()
        {
            Console.WriteLine($"Created {counter} Enrolle object(-s)");
        }

        partial void refTest(ref int x)
        {
            x = this.age;
        }

        public void outTest(out int x, int y)
        {
            x = this.ctPoints + y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Enrolle enrolle = obj as Enrolle;
            if (enrolle == null)
                return false;

            return enrolle.name == this.name && enrolle.age == this.age && enrolle.ctPoints == this.ctPoints;
        }

        public override int GetHashCode()
        {
            return this.age.GetHashCode() + this.ctPoints.GetHashCode();
        }

        public override string ToString()
        {
            return $"Name: {name}, Age: {age}, CTpoints: {ctPoints}";
        }
    }
}
