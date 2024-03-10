namespace GYAK_05_20240311_Teachers.Verem
{
    public interface IIngredientStack
    {
        bool Empty();
        FoodIngredient Pop();
        void Push(FoodIngredient item);
        FoodIngredient Top();
    }
}