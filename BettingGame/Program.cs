namespace BettingGame
{
    internal class Program
    {
        static void Main()
        {

            const double odds = 0.75;

            Player Player = new(){ Cash = 1000, Name = "Player" };
            Console.WriteLine($"Welbome to the casino. The odds are {odds}");
            Player.WriteMyInfo();
        }
    }
}