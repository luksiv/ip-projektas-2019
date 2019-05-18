using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp1.DataFormating
{
    class Glass
    {
        public int id { get; set; }
        public double refractive_index { get; set; }
        public double sodium { get; set; }
        public double magnesium { get; set; }
        public double aluminum { get; set; }
        public double silicon { get; set; }
        public double potassium { get; set; }
        public double calcium { get; set; }
        public double barium { get; set; }
        public double iron { get; set; }
        public int group_type { get; set; }

        public Glass(int gl_id, double gl_refractive, double gl_sodium, double gl_magnesium, double gl_aluminum, double gl_silicon, double gl_potassium, double gl_calcium, double gl_barium, double gl_iron, int type)
        {
            id = gl_id;
            refractive_index = gl_refractive;
            sodium = gl_sodium;
            magnesium = gl_magnesium;
            aluminum = gl_aluminum;
            silicon = gl_silicon;
            potassium = gl_potassium;
            calcium = gl_calcium;
            barium = gl_barium;
            iron = gl_iron;
            group_type = type;
        }
        public Glass() { }

        public List<double> GetMainValues()
        {
            List<double> values = new List<double>();
            values.Add(refractive_index);
            values.Add(sodium);
            values.Add(magnesium);
            values.Add(aluminum);
            values.Add(silicon);
            values.Add(potassium);
            values.Add(calcium);
            values.Add(barium);
            values.Add(iron);
            return values;
        }

        public void SetMainValues(int index, double value)
        {
            switch (index)
            {
                case 0:
                    refractive_index = value;
                    break;
                case 1:
                    sodium = value;
                    break;
                case 2:
                    magnesium = value;
                    break;
                case 3:
                    aluminum = value;
                    break;
                case 4:
                    silicon = value;
                    break;
                case 5:
                    potassium = value;
                    break;
                case 6:
                    calcium = value;
                    break;
                case 7:
                    barium = value;
                    break;
                case 8:
                    iron = value;
                    break;
            }
        }
    }
}
