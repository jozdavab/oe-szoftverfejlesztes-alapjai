using GYAK_02_20240219_Teachers.Cars;

namespace GYAK_02_20240219_Teachers
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
             Az OOP megvalósítások általános jellemzői: egységbezárás, adatrejtés, öröklés, többalakúság, kód újrafelhasználás.

            Egységbezárás:  Az adatokat és hozzájuk tartozó eljárásokat egyetlen egységben kezeljük (objektum-osztály)
            (Encapsulation)     Az osztály mezői tárolják az információkat
                                A metódusok kommunikálnak a külvilággal
                                Az osztály változóit csak a metódusokon keresztül (tehát az osztály tudtával) változtathatjuk meg

            Adatrejtés:     Az objektum belső működését elrejtük a külvilág elől láthatósági szintekkel.
            (Data hiding)

            Öröklés:        Az öröklés olyan implementációs és modellezési eszköz, amelyik lehetővé teszi, hogy
            (Inheritance)       egy osztályból olyan újabb osztályokat származtassunk, amelyek rendelkeznek az eredeti osztályban                               
                                már definiált tulajdonságokkal, szerkezettel és viselkedéssel.

            Többalakúság:   Ugyanarra az üzenetre különböző objektumok különbözőképpen reagálhatnak (saját implementációval)
            (Polymorphism)

            Kód újrafelhasználás: Lásd előző féléves Problémamegoldás programozással jegyzet.
             */

            Auto torlendoAuto = new SportAuto();

            AutoKolcsonzo kolcsonzo = new AutoKolcsonzo();
            //Megjegyzés: Látványosabb lenne a tesztelés, ha felparaméterezett konstruktorokat használnák.
            kolcsonzo.AutoFelvetele(torlendoAuto);
            kolcsonzo.AutoFelvetele(new Szemelygepjarmu());
            kolcsonzo.AutoFelvetele(new Teherauto());
            kolcsonzo.AutoFelvetele(new LuxusAuto());
            kolcsonzo.AutoFelvetele(new Teherauto());
            kolcsonzo.AutoFelvetele(new ModellAuto());
            kolcsonzo.AutoFelvetele(new TaviranyitosAuto());
            kolcsonzo.AutoTorlese(torlendoAuto);

            kolcsonzo.AutoLista();

            kolcsonzo.OsszFogyasztas();

            kolcsonzo.Rakodas();

            kolcsonzo.Feltoltes();
        }
    }
}