using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace HenryRTS {
    public class Elements {

        static Element[] elements;
        public static Element GetElement(int atomicNumber) {
            if (atomicNumber > 0 && atomicNumber <= elements.Count() || elements[atomicNumber - 1] == null)
                return elements[atomicNumber - 1];
            else
                throw new Exception("Invalid atomic number.");
        }
        public static Element GetElement(string fullName) {
            foreach (Element e in elements) 
                if (e.Name == fullName)
                    return e;
            throw new Exception("Element '" + fullName + "' not found!");
        }

        static Elements() {
            elements = new Element[88];
            //add all t3h elements that i will be using
            elements[0] = new Element("Hydrogen", "H", new Color(0, 150, 0));
            elements[1] = new Element("Helium", "He", new Color(161, 179, 255));
            elements[2] = new Element("Lithium", "Li", new Color(255, 193, 120));
            elements[3] = new Element("Beryllium", "Be", new Color(255, 253, 185));
            elements[4] = new Element("Boron", "B", new Color(141, 210, 195));
            elements[5] = new Element("Carbon", "C", new Color(125, 255, 125));
            elements[6] = new Element("Nitrogen", "N", new Color(100, 255, 100));
            elements[7] = new Element("Oxygen", "O", new Color(75, 255, 75));
            elements[8] = new Element("Fluorine", "F", new Color(200, 250, 255));
            elements[9] = new Element("Neon", "Ne", new Color(137, 159, 255));
            elements[10] = new Element("Sodium", "Na", new Color(255, 180, 91));
            elements[11] = new Element("Magnesium", "Mg", new Color(255, 251, 154));
            elements[12] = new Element("Aluminium", "Al", new Color(165, 189, 166));
            elements[13] = new Element("Silicon", "Si", new Color(104, 208, 185));
            elements[14] = new Element("Phosphorus", "P", new Color(50, 255, 50));
            elements[15] = new Element("Sulfur", "S", new Color(25, 255, 25));
            elements[16] = new Element("Chlorine", "Cl", new Color(150, 250, 255));
            elements[17] = new Element("Argon", "Ar", new Color(107, 135, 255));
            elements[18] = new Element("Potassium", "K", new Color(255, 171, 73));
            elements[19] = new Element("Calcium", "Ca", new Color(255, 250, 120));
            elements[20] = new Element("Scandium", "Sc", new Color(255, 225, 255));
            elements[21] = new Element("Titanium", "Ti", new Color(255, 225 - 8, 255 - 8));
            elements[22] = new Element("Vanadium", "V", new Color(255, 225 - 2 * 8, 255 - 2 * 8));
            elements[23] = new Element("Chromium", "Cr", new Color(255, 225 - 3 * 8, 255 - 3 * 8));
            elements[24] = new Element("Manganese", "Mn", new Color(255, 225 - 4 * 8, 255 - 4 * 8));
            elements[25] = new Element("Iron", "Fe", new Color(255, 225 - 5 * 8, 255 - 5 * 8));
            elements[26] = new Element("Cobalt", "Co", new Color(255, 225 - 6 * 8, 255 - 6 * 8));
            elements[27] = new Element("Nickel", "Ni", new Color(255, 225 - 7 * 8, 255 - 7 * 8));
            elements[28] = new Element("Copper", "Cu", new Color(255, 225 - 8 * 8, 255 - 8 * 8));
            elements[29] = new Element("Zinc", "Zn", new Color(255, 225 - 9 * 8, 255 - 9 * 8));
            elements[30] = new Element("Gallium", "Ga", new Color(133, 159, 135));
            elements[31] = new Element("Germanium", "Ge", new Color(86, 208, 181));
            elements[32] = new Element("Arsenic", "As", new Color(69, 208, 177));
            elements[33] = new Element("Selenium", "Se", new Color(0, 255, 0));
            elements[34] = new Element("Bromine", "Br", new Color(100, 250, 255));
            elements[35] = new Element("Krypton", "Kr", new Color(69, 104, 255));
            elements[36] = new Element("Rubidium", "Rb", new Color(255, 159, 45));
            elements[37] = new Element("Strontium", "Sr", new Color(255, 249, 83));
            elements[38] = new Element("Yttrium", "Y", new Color(255, 225 - 10 * 8, 255 - 10 * 8));
            elements[39] = new Element("Zirconium", "Zr", new Color(255, 225 - 11 * 8, 255 - 11 * 8));
            elements[40] = new Element("Niobium", "Nb", new Color(255, 225 - 12 * 8, 255 - 12 * 8));
            elements[41] = new Element("Molybdenum", "Mo", new Color(255, 225 - 13 * 8, 255 - 13 * 8));
            elements[42] = new Element("Technetium", "Tc", new Color(255, 225 - 14 * 8, 255 - 14 * 8));
            elements[43] = new Element("Ruthenium", "Ru", new Color(255, 225 - 15 * 8, 255 - 15 * 8));
            elements[44] = new Element("Rhodium", "Rh", new Color(255, 225 - 16 * 8, 255 - 16 * 8));
            elements[45] = new Element("Palladium", "Pd", new Color(255, 225 - 17 * 8, 255 - 17 * 8));
            elements[46] = new Element("Silver", "Ag", new Color(255, 225 - 18 * 8, 255 - 18 * 8));
            elements[47] = new Element("Cadmium", "Cd", new Color(255, 225 - 19 * 8, 255 - 19 * 8));
            elements[48] = new Element("Indium", "In", new Color(155, 140, 116));
            elements[49] = new Element("Tin", "Sn", new Color(100, 121, 100));
            elements[50] = new Element("Antimony", "Sb", new Color(48, 208, 172));
            elements[51] = new Element("Tellurium", "Te", new Color(28, 208, 168));
            elements[52] = new Element("Iodine", "I", new Color(50, 250, 255));
            elements[53] = new Element("Xenon", "Xe", new Color(34, 76, 255));
            elements[54] = new Element("Caesium", "Cs", new Color(255, 148, 22));
            elements[55] = new Element("Barium", "Ba", new Color(255, 247, 39));
            //[unused metals in this range 56-70]
            elements[71] = new Element("Hafnium", "Hf", new Color(255, 225 - 20 * 8, 255 - 20 * 8));
            elements[72] = new Element("Tantalum", "Ta", new Color(255, 225 - 21 * 8, 255 - 21 * 8));
            elements[73] = new Element("Tungsten", "W", new Color(255, 225 - 22 * 8, 255 - 22 * 8));
            elements[74] = new Element("Rhenium", "Re", new Color(255, 225 - 23 * 8, 255 - 23 * 8));
            elements[75] = new Element("Osmium", "Os", new Color(255, 225 - 24 * 8, 255 - 24 * 8));
            elements[76] = new Element("Iridium", "Ir", new Color(255, 225 - 25 * 8, 255 - 25 * 8));
            elements[77] = new Element("Platinum", "Pt", new Color(255, 225 - 26 * 8, 255 - 26 * 8));
            elements[78] = new Element("Gold", "Au", new Color(255, 225 - 27 * 8, 255 - 27 * 8));
            elements[79] = new Element("Mercury", "Hg", new Color(255, 225 - 28 * 8, 255 - 28 * 8));
            elements[80] = new Element("Thallium", "Tl", new Color(90, 109, 90));
            elements[81] = new Element("Lead", "Pb", new Color(75, 95, 76));
            elements[82] = new Element("Bismuth", "Bi", new Color(60, 85, 61));
            elements[83] = new Element("Polonium", "Po", new Color(1, 210, 163));
            elements[84] = new Element("Astatine", "At", new Color(0, 250, 255));
            elements[85] = new Element("Radon", "Rn", new Color(0, 48, 255));
            elements[86] = new Element("Francium", "Fr", new Color(255, 138, 0));
            elements[87] = new Element("Radium", "Ra", new Color(255, 246, 0));
        }







    }

    public class Element {
        public string Name;
        public string Symbol;
        public Color Color;

        public Element(string name, string symbol, Color color) {
            Name = name;
            Symbol = symbol;
            Color = color;
        }
    }
}
