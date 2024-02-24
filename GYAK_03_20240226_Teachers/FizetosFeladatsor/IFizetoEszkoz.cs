namespace FizetosFeladatsor
{
    //C#-ban az interfészeket I betűvel kezdjük.
    //Az interfészben "megköveteljük" hogy az interfészt implementáló osztályok mivel rendelkezzenek.
    public interface IFizetoEszkoz
    {
        //Az interfészben csak a deklarációk vannak, az implementációt majd az osztályokban kell megvalósítani.
        public bool Fizet(decimal fizetendo);
    }
}