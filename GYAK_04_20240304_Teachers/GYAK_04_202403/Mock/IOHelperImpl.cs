namespace GYAK_04_202403.Mock
{
    public class IOHelperImpl : IIOHelper
    {
        public string GetUserInput()
        {
            // Kényszerítjük a felhasználót, hogy válasszon input típust.
            string input;
            do
            {
                Console.WriteLine("Choose an input type. [0]-Console [1]-File");
                input = Console.ReadLine();
            } while (input != "1" || input != "2");

            if (input == "0")
            {
                Console.WriteLine("Type your text then press enter.");
                return Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Type the filename then press enter.");
                return File.ReadAllText(Console.ReadLine());
            }
        }
    }
}