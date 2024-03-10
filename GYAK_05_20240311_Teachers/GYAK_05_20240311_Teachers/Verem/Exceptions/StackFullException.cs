namespace GYAK_05_20240311_Teachers.Verem.Exceptions
{
    public class StackFullException : StackException
    {
        public FoodIngredient FoodIngredient { get; }
        public StackFullException(IngredientStack i, FoodIngredient f) : base(i)
        {
            FoodIngredient = f;
        }
    }
}