namespace GYAK_04_202403.Mock
{
    public class PalindromeTool
    {
        private IIOHelper iOHelper; // Interface-t használunk, hogy a tesztelésnél könnyebben tudjuk mockolni.

        public PalindromeTool(IIOHelper iOHelper) // Dependency Injection! Kívülről kapjuk meg a függőségeink.
        {
            this.iOHelper = iOHelper;
        }

        //public PalindromeTool()
        //{
        //    iOHelper = new IOHelperImpl(); // Ezt nem szeretnénk, mert így hardcode-oljuk a függőséget.
        //}

        public bool IsPalindrome()
        {
            // A példa érdekében használjuk az iOhelpert-t, egyébként függvényparaméterként jobb lenne bekérni a text-et.
            string text = iOHelper.GetUserInput().ToLower().Replace(" ", "");
            for (int leftIndex = 0; leftIndex < text.Length / 2; leftIndex++)
            {
                int rightIndex = text.Length - 1 - leftIndex;
                if (text[leftIndex] != text[rightIndex])
                {
                    return false;
                }
            }
            return true;
        }
    }
}