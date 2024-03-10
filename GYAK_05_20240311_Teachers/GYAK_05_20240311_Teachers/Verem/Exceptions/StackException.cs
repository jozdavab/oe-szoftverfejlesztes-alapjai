namespace GYAK_05_20240311_Teachers.Verem.Exceptions
{
    // Saját kivételt is dobhatunk ha az leszármazik az Exception őstől.
    public class StackException : Exception
    {
        // Eltároljuk a hibát okozó IngredientStack-et csak olvasható módon.
        public IngredientStack IngredientStack { get; }

        // Mivel nincs más konstruktor, kivétel eldobásakor kötelező megadni a kivételt okozó példányt.
        public StackException(IngredientStack ingredientStack)
        {
            IngredientStack = ingredientStack;
        }
    }
}