namespace GYAK_01_20240212_Teachers
{
    public class ChildOfSpecialClass : SpecialClass
    {
        //Az absztrakt metódusokat a leszármazott osztályoknak kötelező megvalósítaniuk, különben fordítási hiba keletkezik.
        public override void AbstractMethod()
        {
            //Az absztrakt metódus implementációja ide kerülne.
        }
    }
}