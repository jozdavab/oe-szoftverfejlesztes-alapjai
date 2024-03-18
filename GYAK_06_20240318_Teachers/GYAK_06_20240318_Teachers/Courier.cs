using GYAK_06_20240318_Teachers.Deliverables;
using GYAK_06_20240318_Teachers.Exceptions;

namespace GYAK_06_20240318_Teachers
{
    // Egy futárt a Courier nevű osztály egy példánya reprezentálja. Hozza létre az osztályt az alábbiak szerint.
    public class Courier
    {
        // A kézbesítendő küldeményeket(a fentiek bármelyike) tárolja egy tömbben,
        public IDeliverable[] deliverables { get; }

        // azok aktuális össztömegét pedig egy mezőben, amely publikus tulajdonságon keresztül lekérdezhető
        private int sumWeight;

        // Note: Ennek inkább on the fly propertynek kéne lennie...
        public int SumWeight { get { return sumWeight; } }

        // A tömb elemszámát a konstruktorból lehessen beállítani
        public Courier(int size)
        {
            deliverables = new IDeliverable[size];
        }

        // Rendelkezzen egy void PickUpItem(IDeliverable item) szignatúrájú publikus metódussal,
        // amely a paraméterként kapott küleményt elhelyezi a kézbesítendő elemeket tartalmazó tömbben.
        // Ha már nincsen több szabad hely, jelezze egy DeliveryException kivétel eldobásával.
        public void PickUpItem(IDeliverable item)
        {
            for (int i = 0; i < deliverables.Length; i++)
            {
                if (deliverables[i] == null)
                {
                    deliverables[i] = item;
                    sumWeight += item.Weight;
                    return;
                }
            }
            throw new DeliveryException(item, "Courier can't take more parcels.");
        }

        // Rendelkezzen egy IDeliverable[] FragilesSorted() nevű metódussal, amely egy kimeneti tömbbe
        // válogatja a FragileParcel típusú küldeményeket.A metódus a kiválogatott elemeket növekvően rendezett sorrendben adja vissza.
        public IDeliverable[] FragilesSorted()
        {
            int fragileCount = 0;
            // Megszámlálás
            foreach (IDeliverable item in deliverables)
            {
                if (item is FragileParcel) fragileCount++;
            }
            IDeliverable[] fragiles = new IDeliverable[fragileCount];
            // Leválogatás
            foreach (IDeliverable item in deliverables)
            {
                if (item is FragileParcel) fragiles[--fragileCount] = item;
            }
            // Rendezés
            Array.Sort(fragiles);

            return fragiles;
        }
    }
}