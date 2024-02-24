namespace HazasFeladatsor
{
    public interface IRent
    {
        ///Függvény felett /// -> Dokumentációs komment generálása

        /// <summary>
        /// A getter visszaadja, hogy éppen foglalt-e az ingatlan.
        /// </summary>
        /// <returns></returns>
        public bool IsBooked { get; }

        /// <summary>
        /// A metódus megadja, hogy mennyibe kerül az ingatlan adott hónapnyi bérlése egy fő számára.
        /// </summary>
        /// <param name="months">Bérlendő hónapok száma.</param>
        /// <returns>1 főre eső össz bérleti költség.</returns>
        public int GetCost(int months);

        /// <summary>
        /// A metódus adott hónapra lefoglalja az ingatlant, ha még nincs lefoglalva.
        /// </summary>
        /// <param name="months">Bérlendő hónapok száma.</param>
        /// <returns>A foglalás sikeressége.</returns>
        public bool Book(int months);
    }
}