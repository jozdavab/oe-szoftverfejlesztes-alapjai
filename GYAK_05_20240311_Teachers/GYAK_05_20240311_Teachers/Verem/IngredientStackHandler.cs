using GYAK_05_20240311_Teachers.Verem.Exceptions;

namespace GYAK_05_20240311_Teachers.Verem
{
    public class IngredientStackHandler
    {
        private IIngredientStack ingredientStack; // Interface reference!

        public IngredientStackHandler(IIngredientStack ingredientStack)
        {
            this.ingredientStack = ingredientStack; // Dependency Injection!
        }

        public FoodIngredient[] Additems(FoodIngredient[] foodIngredients)
        {
            int pointer = 0;
            try
            {
                while (pointer < foodIngredients.Length)
                {
                    ingredientStack.Push(foodIngredients[pointer]);
                    pointer++;
                }
            }
            catch (StackFullException ex)
            {
                FoodIngredient[] remaining = new FoodIngredient[foodIngredients.Length - pointer];
                for (int i = 0; i < remaining.Length; i++)
                {
                    remaining[i] = foodIngredients[pointer + i];
                }

                return remaining;
            }

            return null;
        }
    }
}