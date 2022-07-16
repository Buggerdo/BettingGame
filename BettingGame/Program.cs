namespace BettingGame
{
    internal class Program
    {

        static void Main()
        {
            PlayGame();
        }

        private static void PlayGame()
        {
            const double odds = 0.75;
            Random random = new();
            int count = 0;

            Console.WriteLine($"Welcome to the casino. The odds are {odds}");
            int cash = GetCash();
            Players Player = new() { Cash = cash, Name = "Player" };
            Player.WriteMyInfo();

            while(Player.Cash > 0)
            {
                count++;
                Console.WriteLine("How much would you like to bet?");
                string howMuch = Console.ReadLine();
                if(howMuch == "")
                {
                    return;
                }
                else if(int.TryParse(howMuch, out int amount))
                {
                    int pot = Player.GiveCash(amount) * 2;

                    if(pot > 0)
                    {
                        if(random.NextDouble() > odds)
                        {
                            Console.WriteLine($"You win {pot}");
                            Player.ReceiveCash(pot);
                            Player.WriteMyInfo();
                        }
                        else
                        {
                            Console.WriteLine("Bad luck, you lose.");
                            Player.WriteMyInfo();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("That is not a valid number");
                }
            }
            Console.WriteLine("The house always wins. " + count);
        }

        private static int GetCash()
        {
            do
            {
                Console.WriteLine("How much cash do you have?");
                string howMuchCash = Console.ReadLine();
                Console.Clear();
                if(howMuchCash == "")
                {
                    Console.WriteLine("Please enter how much cash you have");
                }
                else if(int.TryParse(howMuchCash, out int cash))
                {
                    return cash;
                }
                else
                {
                    Console.WriteLine("That is not a valid number");
                }
            } while(true);
        }
    }
}