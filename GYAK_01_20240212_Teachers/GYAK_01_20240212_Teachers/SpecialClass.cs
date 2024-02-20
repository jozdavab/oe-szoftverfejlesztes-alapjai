namespace GYAK_01_20240212_Teachers
{
    //Ez az osztály nem példányosítható, csak leszármaztatni lehet belőle. abstract kulcsszó.
    public abstract class SpecialClass
    {

        //Az absztrakt osztályok tulajdonságokkal is rendelkezhetnek.
        public int SomeProperty { get; set; }

        //Az absztrakt metódusokat nem lehet implementálni, csak a szignatúrájukat lehet megadni.
        //Az absztrakt metódusokat a leszármazott osztályoknak kötelező megvalósítaniuk!
        public abstract void AbstractMethod();

        //Az absztrakt osztályok konkrét metódusokkal is rendelkezhetnek.
        public void ConcreteMethod()
        {
            Console.WriteLine("Concrete method from abstract class");
        }

        //Az absztrakt osztály rendelkezhet konstruktorral is, például a mezők/tulajdonságok inicializálásához.
        protected SpecialClass()
        {
            SomeProperty = 3;
        }
    }
}