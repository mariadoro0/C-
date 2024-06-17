namespace Interfaccia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Uso di Interface");
            /* Gestione di più eccezioni*/
            try
            {
                Class1 class1 = new Class1();
                class1.Metodo4();

            }
            catch (NotImplementedException e)
            {
                Console.WriteLine($"{e.Message}");
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine($"{e.Message}");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"{e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.ToString()}");
            }
            
        }
    }
}
