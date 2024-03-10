namespace GYAK_05_20240311_Teachers.Verem
{
    public enum Unit
    {
        Liter, Kilogramm, darab, csomag
    }

    public class FoodIngredient
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public Unit? Unit { get; set; } // ? miatt lehet null is

        public override string ToString()
        {
            string s = Name == null ? "unknown ingredient" : Name;
            s += Amount < 0 ? "invalid amount" : Amount;
            s += Unit == null ? "unknown unit" : Unit;
            return s;
        }
    }
}