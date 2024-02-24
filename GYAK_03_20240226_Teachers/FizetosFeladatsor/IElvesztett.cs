namespace FizetosFeladatsor
{
    //Az interfészek az osztályokhoz hasonlóan öröklődhetnek.
    public interface IElvesztett : ITulajdon
    {
        //Az interfészben tulajdonságokat is deklarálhatunk.
        public DateTime EltunesIdeje { get; set; }
    }
}