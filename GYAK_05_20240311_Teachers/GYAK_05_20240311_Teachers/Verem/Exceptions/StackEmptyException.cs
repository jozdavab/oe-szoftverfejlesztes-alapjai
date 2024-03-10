namespace GYAK_05_20240311_Teachers.Verem.Exceptions
{
    public class StackEmptyException : StackException
    {
        public StackEmptyException(IngredientStack ingredientStack) : base(ingredientStack)
        {
        }
    }
}