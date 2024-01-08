using System.Diagnostics.CodeAnalysis;
using System.Text;


class Program
{
    static void Main(string[] args)
    {
        //Run emojis
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("Welcome to Blackjack! 🃏");
        Console.WriteLine("---------------------------------");
        bool isAlive = false;

        List<int> dealtCards = new List<int>();
        int sum = 0;
        bool hasBlackJack = false;

        int firstCard = drawCard();
        int secondCard = drawCard();

        dealtCards.Add(firstCard);
        dealtCards.Add(secondCard);

        sum = firstCard + secondCard;

        blackJackGame(dealtCards, sum, hasBlackJack, isAlive);

        //dealerHand();


    }

    static void blackJackGame(List<int>dealtCards, int sum, bool hasBlackJack, bool isAlive)
    {
        string showCards = "";

        for(int i = 0; i < dealtCards.Count; i++)
        {
            showCards += dealtCards[i] + " "; 
        }

        if (sum <= 20)
        {
            Console.WriteLine(showCards);

            Console.WriteLine("Would you like to draw another card?");
            string input = Console.ReadLine();
            newCard(input, dealtCards, sum);          
        }
        else if (sum == 21)
        {
            Console.WriteLine(showCards);
            Console.WriteLine("You got 21/Blackjack! You won! 😁");
            hasBlackJack = true;
        }
        else
        {
            Console.WriteLine(showCards);
            Console.WriteLine("You busted! Game over 😭");
            isAlive = false;
        }
    }

    public static int drawCard()
    {
        Random drawACard = new Random();
        int newCard = drawACard.Next(1, 13);
        
        if (newCard > 10)
        {
            return 10;
        }
        else if (newCard == 1)
        {
            return 11;
        }
        else
        {
            return newCard;
        }
    }

    static void newCard(string input, List<int> dealtCards, int sum)
    {
        bool hasBlackJack = false;
        bool isAlive = true;
        if (input == "y")
        {
            int card = drawCard();
            sum += card;
            dealtCards.Add(card);
            blackJackGame(dealtCards, sum, hasBlackJack, isAlive);
        }
        else
        {
            isAlive = false;
            Console.WriteLine("You stand with: " + dealtCards);
            
        }
    }


    //Dealer's turn of drawing cards
    //public static void dealerHand()
    //{
    //    Random randomCard = new Random();
    //    int dealerFirstCard = randomCard.Next(1, 12);
    //    int dealerSecondCard = randomCard.Next(1, 12);
    //    int dealerSum = dealerFirstCard + dealerSecondCard;

    //    Console.WriteLine(dealerFirstCard + " " + dealerSecondCard);
        
    //}
}

