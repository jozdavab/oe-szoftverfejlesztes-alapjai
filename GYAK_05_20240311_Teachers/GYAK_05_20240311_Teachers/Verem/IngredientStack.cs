using GYAK_05_20240311_Teachers.Verem.Exceptions;

namespace GYAK_05_20240311_Teachers.Verem
{
    public class IngredientStack : IIngredientStack
    {
        private readonly FoodIngredient[] foodIngredients;
        private int stackPointer;
        public IngredientStack(int size)
        {
            foodIngredients = new FoodIngredient[size];
            stackPointer = 0;
        }

        public bool Empty()
        {
            return stackPointer < 1;
        }

        public void Push(FoodIngredient item)
        {
            if (stackPointer == foodIngredients.Length)
            {
                throw new StackFullException(this, item);
            }
            foodIngredients[stackPointer++] = item;
        }

        public FoodIngredient Pop()
        {
            if (Empty())
            {
                throw new StackEmptyException(this);
            }
            FoodIngredient result = foodIngredients[--stackPointer];
            foodIngredients[stackPointer] = null;
            return result;
        }

        public FoodIngredient Top()
        {
            if (Empty())
            {
                return null;
            }
            return foodIngredients[stackPointer - 1];
        }
    }
}