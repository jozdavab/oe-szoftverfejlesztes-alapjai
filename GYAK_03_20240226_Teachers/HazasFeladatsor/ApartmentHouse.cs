using System.Globalization;

namespace HazasFeladatsor
{
    public class ApartmentHouse
    {
        public Flat[] Flats { get; private set; }
        public Garage[] Garages { get; private set; }

        public int maxFlatCount;
        public int CurrentFlatCount { get; private set; }

        public int maxGarageCount;
        public int CurrentGarageCount { get; private set; }

        public int InhibitantsCount
        {
            get
            {
                //On the fly property
                int count = 0;
                for (int i = 0; i < CurrentFlatCount; i++)
                {
                    count += Flats[i].InhabitantsCount;
                }
                return count;
            }
        }

        public ApartmentHouse(int maxFlatCount, int maxGarageCount)
        {
            this.maxFlatCount = maxFlatCount;
            this.CurrentFlatCount = 0;      // Alapértelmezetten is nulla lenne, elhagyható.
            this.Flats = new Flat[maxFlatCount];
            this.maxGarageCount = maxGarageCount;
            this.CurrentGarageCount = 0;    // Alapértelmezetten is nulla lenne, elhagyható.
            this.Garages = new Garage[maxGarageCount];
        }

        public bool AddNewEstate(IRealEstate realEstate)
        {
            if (realEstate is Flat && CurrentFlatCount < maxFlatCount)
            {
                Flats[CurrentFlatCount++] = (Flat)realEstate;
                return true;
            }
            else if (realEstate is Garage && CurrentGarageCount < maxGarageCount)
            {
                Garages[CurrentGarageCount++] = (Garage)realEstate;
                return true;
            }
            return false;
        }

        public int TotalValue()
        {
            int sum = 0;
            for (int i = 0; i < CurrentFlatCount; i++)
            {
                if (Flats[i].InhabitantsCount > 0)
                {
                    sum += Flats[i].TotalValue();
                }
            }

            for (int i = 0; i < CurrentGarageCount; i++)
            {
                if (Garages[i].IsBooked)
                {
                    sum += Garages[i].TotalValue();
                }
            }

            return sum;
        }

        public static ApartmentHouse LoadFromFile(string fileName)
        {
            string[] content = File.ReadAllLines(@"..\..\..\" + fileName);

            //Garázsok számának meghatározása.
            int garageCount = CountEstatesOfType(content, "Garazs");

            //ApartmentHouse példányosítása. Ismerni kell a lakások számát és a garázsok számát.
            ApartmentHouse apartmentHouse = new ApartmentHouse(content.Length - garageCount, garageCount);

            for (int i = 0; i < content.Length; i++)
            {
                //Minden sort feldolgozunk, majd hozzáadjuk az apartmentHouse-hoz.
                AddEstateFromLineToApartment(content[i], apartmentHouse);
            }

            return apartmentHouse;
        }

        //Segédfüggvény. Bizonyos nevű ingatlanokat számol meg a fájlban.
        private static int CountEstatesOfType(string[] estateLines, string estateType)
        {
            int estatesOfTypeCounter = 0;
            for (int i = 0; i < estateLines.Length; i++)
            {
                if (estateLines[i].Split(' ')[0] == estateType)
                {
                    estatesOfTypeCounter++;
                }
            }
            return estatesOfTypeCounter;
        }

        private static void AddEstateFromLineToApartment(string line, ApartmentHouse apartmentHouse)
        {
            string[] parts = line.Split(' ');
            //Később tanulunk szebb megoldást a sorok feldolgozásra.
            switch (parts[0])
            {
                case "Garazs":
                    apartmentHouse.AddNewEstate(new Garage(double.Parse(parts[1], CultureInfo.InvariantCulture), int.Parse(parts[2]), parts[3] == "futott"));
                    break;
                case "CsaladiApartman":
                    apartmentHouse.AddNewEstate(new FamilyApartment(double.Parse(parts[1], CultureInfo.InvariantCulture), int.Parse(parts[2]), int.Parse(parts[3])));
                    break;
                case "Alberlet":
                    apartmentHouse.AddNewEstate(new Lodgings(double.Parse(parts[1], CultureInfo.InvariantCulture), int.Parse(parts[2]), int.Parse(parts[3])));
                    break;
            }
        }
    }
}