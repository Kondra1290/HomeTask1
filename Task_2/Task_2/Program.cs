namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            bool flag;
            Boolean.TryParse(rnd.Next(2).ToString(), out flag);

            string light = flag ? "включен" : "выключен";
            Console.WriteLine($"В комнате сейчас {light} свет");
            Console.WriteLine("Хотите это изменить?");
            string answer = Console.ReadLine();
            if (answer.Equals("нет"))
                Console.WriteLine("Вы решили ничего не трогать. И правильно.");
            else if (answer.Equals("да"))
            {
                flag = !flag;
                light = flag ? "включен" : "вылючен";
                Console.WriteLine($"Теперь свет {light}");
            }
        }
    }
}