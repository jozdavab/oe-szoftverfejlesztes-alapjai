namespace GYAK_06_20240318_Teachers.Deliverables
{
    // Hozza létre az IDeliverable interfészt.
    // Egy kézbesítendő küldemény esetén ismert annak grammban adott
    // tömege(Weight, egész érték) és a kézbesítési címe(Address, karakterlánc),
    // valamint az objektum rendelkezik áll egy
    // double CalculatePrice(bool fromLocker) szignatúrájú metódussal,
    // amely a csomagszállítási díjat számolja ki.
    public interface IDeliverable
    {
        int Weight { get; set; }
        string Address { get; set; }
        double CalculatePrice(bool fromLocker);
    }
}