using System;
class ArraysAndMethods //THE CONCEPT OF ARRAYS AND METHODS
{
	public static void CreditLimit(int limit = 500)
	{
		Console.WriteLine("The credit limit is {0}", limit.ToString("C0"));
	}
	public static void Prices()
	{
		//SOME USEFUL VARIABLES
		double[] prices = new double[20];
		double sum = 0, average = 0;

		//PROMPT ARRAY ELEMENTS FROM THE USER AND SORT ARRAY
		for (int p = 0; p < 20; p++)
		{
			Console.Write("Enter a price: ");
			sum += prices[p] = Convert.ToDouble(Console.ReadLine());
		}

		Array.Sort(prices);

		Console.WriteLine("\nThe sum of the prices is {0}", sum.ToString("C2"));
		Console.WriteLine("\nList of prices lower than $5");

		//FIND PRICES LOWER THAN $5.00
		for (int b = 0; b < 20; b++)
			if (prices[b] < 5)
				Console.WriteLine(prices[b].ToString("C2"));

		average = sum / 20;

		Console.WriteLine("\nThe average is {0}", average.ToString("C2"));
		Console.WriteLine("List of prices greater than the average");

		//FIND PRICES GREATER THAN THE CALCULATED AVERAGE
		for (int l = 0; l < 20; l++)
			if (prices[l] > average)
				Console.WriteLine(prices[l].ToString("C2"));
	}
	public static void Scores()
	{
		//DISPLAY SCORES ARRAY IN DIFFERENT SETS OF ORDER
		int[] scores = new int[8] { 234, 657, 89, 90, 34, 67, 340, 345 };

		Console.WriteLine("Scores in original order\n------------------------");
		foreach (int score in scores)
			Console.Write("{0, 4}", score);

		Console.WriteLine("\nScores reverse order\n------------------------");
		Array.Reverse(scores);
		for (int c = 0; c < scores.Length; c++)
			Console.Write("{0, 4}", scores[c]);

		Console.WriteLine("\nScores ascending order\n------------------------");
		Array.Sort(scores);
		foreach (int score in scores)
			Console.Write("{0, 4}", score);

		Console.WriteLine("\nScores descending order\n------------------------");
		Array.Reverse(scores);
		for (int c = 0; c < 8; c++)
			Console.Write("{0, 4}", scores[c]);
		Array.Sort(scores);

		Console.WriteLine();

		//BINARY SEARCH AND FEEDBACK
		Console.Write("\nEnter a number: ");
		int position = Array.BinarySearch(scores, Convert.ToInt32(Console.ReadLine()));

		if (position < 0)
			Console.WriteLine("Not Found!");
		else
			Console.WriteLine("Found!");

		Console.WriteLine();
	}
	//THREE METHODS TO DEMONSTRATE OVERLOADING
	public static void Area(int a, int b)
	{
		Console.WriteLine("Using two int and int: {0}", a * b);
	}
	public static void Area(double a, double b)
	{
		Console.WriteLine("Using two double and double: {0}", a * b);
	}
	public static void Area(int a, double b)
	{
		Console.WriteLine("Using two int and double: {0}", a * b);
	}
	//REVERSE THE ORDER OF TWO NUMBERS USING PARAMETERS
	public static void ChangeNumbers(ref int a, ref int b)
	{
		int temp = a;
		a = b;
		b = temp;
	}
	//A GAME OF HANGMAN UTILIZING A STRING AS AN ARRAY OF CHARACTERS
	public static void GuessTheWord(string word)
	{
		char[] letters = new char[word.Length];
		bool stillAsterisksLeft = false;

		//DYNAMICALLY ASSIGN ASTERISK TO EVERY LETTER OF WORD
		for (int w = 0; w < word.Length; w++)
			letters[w] = '*';

		//LOOP THROUGH WORD TO FIND ANY ASTERISKS LEFT
		do
		{
			int starCount = 0;

			//MAKE A LIST OF LETTERS 
			Console.Write("Word: ");
			for (int g = 0; g < word.Length; g++)
				Console.Write(letters[g]);

			//PROMPT AND AWAIT LETTER FROM USER
			Console.Write("\nGuess one letter: ");
			char letter = Convert.ToChar(Console.ReadLine());

			//SEARCH FOR LETTER IN STRING WORD
			for (int t = 0; t < word.Length; t++)
				if (letter == word[t])
					letters[t] = letter;

			//CHECH IF THERE'S ANY ASTERISKS LEFT IN THE WORD
			for (int m = 0; m < word.Length; m++)
				if (letters[m] == '*')
					starCount++;

			if (starCount > 0)
				stillAsterisksLeft = true;
			else
				stillAsterisksLeft = false;
		}
		while (stillAsterisksLeft);

		Console.Write("The word is ");

		//DISPLAY THE WORD
		for (int g = 0; g < word.Length; g++)
			Console.Write(letters[g]);
	}
}
class ArithmeticFraction
{
	private int WholeNumber { get; set; }
	private int Numerator { get; set; }
	private int denominator;
	private int Denominator
	{
		set
		{
			if (value == 0)
				denominator = 1;
			else
				denominator = value;
		}
		get
		{
			return denominator;
		}
	}
	private static int commonDenominator;
	private static int CommonDenominator
	{
		set
		{
			if (value == 0)
				commonDenominator = 1;
			else
				commonDenominator = value;
		}
		get
		{
			return commonDenominator;
		}
	}
	//HAHAHAHA THREE CONSTRUCTORS IN ONE, BITCHES!!!
	//THIS IS AN EXAMPLE OF DEFAULT PARAMETERS INSTEAD OF NEEDLESSlY OVERLOADING THE CONSTRUCTOR
	public ArithmeticFraction(int whole = 0, int numer = 0, int demon = 1)
	{
		WholeNumber = whole;
		Numerator = numer;
		Denominator = demon;
	}
	/*
	IT IS WORTH NOTING AT THIS MOMENT THAT THE FRACTIONAL PART OF THE 
	MIXED NUMBER CAN BE REDUCED TO ITS LOWEST TERMS EVEN IF THE WHOLE NUMBER
	IS STILL A PART OF IT. MIXED NUMBERS CAN BE REDUCED TO THEIR LOWEST TERMS TOO.
	*/
	//METHOD TO REDUCE THE FRACTION TO ITS LOWEST TERMS
	private void Reduce()
	{
		//FIND INTEGER BY WHICH THE DENOMINATOR IS DIVISIBLE
		for (int d = 9; d > 1; d--)
			if (Numerator % d == 0 && Denominator % d == 0)
			{
				Numerator /= d;
				Denominator /= d;
				Reduce();
			}
	}
	//METHOD TO CONVERT IMPROPER FRACTION TO ITS MIXED NUMBER FORM
	private void ChangeToMixedNumber(ArithmeticFraction fraction)
	{
		Reduce();
		fraction.WholeNumber = fraction.Numerator / fraction.Denominator;
		fraction.Numerator %= fraction.Denominator;
	}
	//METHOD TO PRINT THE MIXED NUMBER
	public void DisplayMixedNumber(ArithmeticFraction fraction)
	{
		ChangeToMixedNumber(fraction);
		Console.WriteLine($"  {Numerator}");
		Console.WriteLine($"{WholeNumber}---");
		Console.WriteLine($"  {Denominator}");
	}
	//METHOD TO CONVERT MIXED NUMBER TO IMPROPER FRACTION
	private void MakeImproper()
	{
		Numerator += (Denominator * WholeNumber);
		WholeNumber = 0;
	}
	//METHOD TO DISPLAY THE IMPROPER VERSION
	public void DisplayImproperForm()
	{
		MakeImproper();
		Console.WriteLine("In Improper Form:");
		Console.WriteLine($" {Numerator}");
		Console.WriteLine($"---");
		Console.WriteLine($" {Denominator}");
	}

	//A COUPLE OF PRIVATE METHODS TO ABSTRACT THE PROCESS OF FINDING THE COMMON DENOMINATOR
	//METHOD TO DETERMINE IF BOTH DENOMINATORS ARE EQUAL
	private static void DenominatorsAreEqual(ArithmeticFraction first, ArithmeticFraction second)
	{
		if (first.Denominator == second.Denominator)
			CommonDenominator = first.Denominator;
	}
	//FIRST DENOMINATOR IS GREATER THAN SECOND AND DIVISIBLE
	private static void FirstIsGreaterAndDivisible(ArithmeticFraction first, ArithmeticFraction second)
	{
		if (first.Denominator > second.Denominator & first.Denominator % second.Denominator == 0)
			CommonDenominator = first.Denominator;
	}
	//FIST DENOMINATOR IS GREATER THAN SECOND AND NOT DIVISIBLE
	private static void FirstIsGreaterAndNotDivisible(ArithmeticFraction first, ArithmeticFraction second)
	{
		for (int m = 2; m <= first.Denominator * second.Denominator; m++)
			if ((first.Denominator * m) % second.Denominator == 0)
			{
				CommonDenominator = first.Denominator * m;
				break;
			}
	}
	//SECOND DENOMINATOR IS GREATER THAN FIRST AND DIVISIBLE
	private static void SecondIsGreaterAndDivisible(ArithmeticFraction first, ArithmeticFraction second)
	{
		if (second.Denominator > first.Denominator & second.Denominator % first.Denominator == 0)
			CommonDenominator = second.Denominator;
	}
	//SECOND DENOMINATOR IS GREATER THAN FIRST BUT NOT DIVISIBLE
	private static void SecondIsGreaterAndNotDivisible(ArithmeticFraction first, ArithmeticFraction second)
	{
		for (int m = 2; m <= first.Denominator * second.Denominator; m++)
			if ((second.Denominator * m) % first.Denominator == 0)
			{
				CommonDenominator = second.Denominator * m;
				break;
			}
	}

	//FIND THE COMMON DENOMINATOR
	public static void FindCommonDenominator(ArithmeticFraction first, ArithmeticFraction second)
	{
		//IF THEY ARE EQUAL, COMMON DENOMINATOR IS == BOTH
		DenominatorsAreEqual(first, second);

		//IF FIRST DENOMINATOR IS GREATER THAN SECOND
		FirstIsGreaterAndDivisible(first, second);

		//IF NOT DIVISIBLE, FIND COMMON DENOMINATOR
		FirstIsGreaterAndNotDivisible(first, second);

		//IF SECOND DENOMINATOR IS BIGGER THAN FIRST
		SecondIsGreaterAndDivisible(first, second);

		//IF NOT DIVISIBLE FIND COMMON DENOMINATOR
		SecondIsGreaterAndNotDivisible(first, second);

		//PRINT OUT THE COMMON DENOMINATOR
		Console.WriteLine($"The Common Denominator is: {CommonDenominator}");
	}

	//METHOD TO ADD TWO FRACTIONS
	public static ArithmeticFraction operator +(ArithmeticFraction first, ArithmeticFraction second)
	{
		//REDUCE AND FIND THE COMMON DENOMINATOR
		first.DisplayImproperForm();
		second.DisplayImproperForm();
		first.Reduce();
		second.Reduce();
		FindCommonDenominator(first, second);

		//BASE BOTH NUMERATORS ON THE COMMON DENOMINATOR
		first.Numerator *= (CommonDenominator / first.Denominator);
		second.Numerator *= (CommonDenominator / second.Denominator);

		ArithmeticFraction Sum = new ArithmeticFraction(0, first.Numerator + second.Numerator, CommonDenominator);
		Sum.Reduce();
		Sum.DisplayImproperForm();
		Sum.DisplayMixedNumber(Sum);
		return Sum;
	}
	public static ArithmeticFraction operator *(ArithmeticFraction first, ArithmeticFraction second)
	{
		//REDUCE AND DISPLAY IMPROPER FORM
		first.Reduce();
		second.Reduce();
		first.DisplayImproperForm();
		second.DisplayImproperForm();

		//FIND PRODUCT OF THE TWO FRACTIONS
		ArithmeticFraction Product = new ArithmeticFraction(0, first.Numerator * second.Numerator, first.Denominator * second.Denominator);

		//DISPLAY AND RETURN THE RESULT
		Product.Reduce();
		Product.DisplayImproperForm();
		return Product;
	}

}
class BankAccount
{
	public int AccountNumber { get; set; }
	private double balance;
	public double Balance
	{
		get
        {
			return balance;
        }
		set
        {
			if (value < 0)
				throw new NegativeBalanceException();
			else
				balance = value;
        }
    }
    public BankAccount(int accNum, double bal)
    {
        AccountNumber = accNum;
        Balance = bal;

        Console.WriteLine($"Bank Account created!");
        Console.WriteLine($"Account Number: {AccountNumber}");
        Console.WriteLine($"Account Balance: {Balance}");
    }
}

class Book
{
	public double Price { get; set; }
	public string Title { get; set; }
	public int NumberOfPages { get; set; }

	public Book(double price, string title, int numberOfPages)
	{
		Price = price;
		Title = title;
		NumberOfPages = numberOfPages;
	}
	public static void Display(Book choice)
	{
		Console.WriteLine($"The Title of the book is {choice.Title}");
		Console.WriteLine($"The Price of the book is {choice.Price}");
		Console.WriteLine($"The  Number Of Pages  is {choice.NumberOfPages}");

	}
	public static Book operator +(Book first, Book second)
	{
		double newPrice;
		const int EXTRA = 10;
		string bothTitles = first.Title + " and " + second.Title;
		int sumOfPages = first.NumberOfPages + second.NumberOfPages;

		if (first.Price > second.Price)
			newPrice = first.Price + EXTRA;
		else
			newPrice = second.Price;

		return new Book(newPrice, bothTitles, sumOfPages);
	}
}
class Box //THIS IS ACTUALLY MY ARITHMETIC CLASS
{
	public int Length { get; set; }
	public int Height { get; set; }
	public int Width { get; set; }
	private int Side { get; set; }
	private int Area { get; set; }

	//DEFAULT CONSTRUCTOR
	public Box()
	{
	}
	//CONSTRUCTOR ALLOCATES SIDE OF SQUARE
	public Box(int side)
	{
		Side = side;
		CalculateSquareArea(Side);
	}
	//METHOD CALCULATES AREA OF SQUARE
	private void CalculateSquareArea(int side)
	{
		Area = side * side;
		Console.WriteLine($"The area is: {Area}");
	}
	//THREE CONSTRUCTORS TO DEMONSTRATE CONSTRUCTOR OVERLOADING
	public Box(string name) : this(name, 23, 46, 92)
	{
	}
	public Box(int L, int W) : this("this box", L, W, 92)
	{
	}
	public Box(string name, int L, int W, int H)
	{
		Length = L;
		Width = W;
		Height = H;

		Console.WriteLine("For {0}, Length is {1}", name, Length);
		Console.WriteLine("For {0}, Width is {1}", name, Width);
		Console.WriteLine("For {0}, Heght is {1}", name, Height);
	}

	//A BUNCH'A CLOWN METHODS RIGHT HERE
	private static double ToFeet(int inch)
	{
		return inch / 12;
	}
	private static void Add(int a, int b)
	{
		Console.WriteLine("The sum is {0}", a + b);
	}
	private static void Subtract(int a, int b)
	{
		Console.WriteLine("The difference is {0}", a - b);
	}
	private static int Product(int a, int b)
	{
		return a * b;
	}

	//MULTIPLICATION TABLE OF A CERTAIN NUMBER
	public static void Multiplication(int number)
	{
		for (int c = 2; c <= 10; c++)
			Console.WriteLine("{0} X {1, 2} = {2}", number, c, number * c);
	}
	//MULTIPLICATION BLOCK FROM 1 - 10 just to confuse them :p
	public static void MultiplicationBlock()
	{
		for (int c = 1; c <= 10; c++)
		{
			for (int i = 1; i <= 10; i++) Console.Write("{0, -2} x {1, 2} = {2, -6} ", i, c, c * i);
			Console.WriteLine();
		}
	}
}
class CarLoan : Loan
{
	public int Year { get; set; }
	public string Make { get; set; }
}
class Employee
{
	public int IdNumber { get; set; }
	public double Salary { get; set; }

	//FOUR CONSTRUCTORS TO DEMONSTRATE CONSTRUCTOR OVERLOADING

	/*
	BASICALLY, METHOD OVERLOADING TAKES PLACE WHEN ANY ONE OF THE CONSTRUCTORS BELOW IS CALLED.
	THE this MODIFIER MAKES SURE THAT ANY OF THE PARAMETERS IT CARRIES
	WILL BE SENT TO THE CONSTRUCTOR THAT TAKES TWO ARGUMENTS.
	THIS WAY, IT IS ENSURED THAT THE CONSTRUCTOR WHICH ACCEPTS 2 ARGUMENTS
	WILL BE CALLED ALWAYS, WHETHER IT HAS BEEN CALLED IMPLICITY OR EXPLICITLY.
	IN ADDITION TO THIS, IN THIS EXAMPLE, THE DEFAULT CONSTRUCTOR ALSO CALLS THE OVERLOADER.
	*/
	public Employee() : this(999, 0)
	{
	}
	public Employee(int empId) : this(empId, 0)
	{
	}
	public Employee(int empId, double sal)
	{
		IdNumber = empId;
		Salary = sal;
	}
	public Employee(char code) : this(111, 100000)
	{
	}
}
class Game
{
	public string Name { get; set; }
	public int MaxNumberOfPlayers { get; set; }

	public override string ToString()
	{
		GetType().ToString();
		return "";
	}
}
class Job
{
	string JobDescription { get; set; }
	double TimeInHours { get; set; }
	double PayPerHour { get; set; }
	double TotalJobFee
	{
		get
		{
			return TimeInHours * PayPerHour;
		}
	}
	//CONSTRUCTOR TO INITIALIZE THE DAMN THING
	public Job(string jd, double time, double rate)
	{
		JobDescription = jd;
		TimeInHours = time;
		PayPerHour = rate;
	}
	//OVERLOADING THE PLUS OPERATOR, BECAUSE YOU KNOW, FOR SOME REASON,
	//SOMEBODY THOUGHT IT WOULD BE FUNNY TO ADD TWO JOBS TOGETHER...
	public static Job operator +(Job first, Job second)
	{
		string NewJobDescription = first.JobDescription + " and " + second.JobDescription;
		double NewTimeInHours = first.TimeInHours + second.TimeInHours;
		double AveragePayRate = (first.PayPerHour + second.PayPerHour) / 2;

		return new Job(NewJobDescription, NewTimeInHours, AveragePayRate);
	}
	public void JobReview()
	{
		Console.WriteLine($"The Job Description: {JobDescription}");
		Console.WriteLine($"Time in hours:       {TimeInHours}");
		Console.WriteLine($"Pay Per Hour:        {PayPerHour}");
		Console.WriteLine($"TotalJobFee:         {TotalJobFee}");
		Console.WriteLine();
	}
}
class Loan
{
	public int LoanNumber { get; set; }
	public string LastName { get; set; }
	public double LoanAmount { get; set; }
}
class NegativeBalanceException : Exception
{
    private static string message = "This is my own custom Exception! \nThe call stack is shown below";
	public NegativeBalanceException() : base(message)
    {
    }
}

class Pizza
{
	private string toppings;
	private int diameter;
	private double price = 13.49;

	private string Toppings
	{
		set{
			if (value == "pepperoni" || value == "pineapple" || value == "cheese" || value == "some weird flavor")
				toppings = value;
			else
				toppings = "Deez...";
		}
		get
		{
			return toppings;
		}
	}
	private int Diameter
	{
		set
		{
			if (value > 0)
				diameter = value;
			else
				diameter = 0;
		}
		get
		{
			return diameter;
		}
	}
	private double Price
	{
		get
		{
			return price;
		}
	}
	public void OrderPizza()
	{
		Console.Write("Which toppings do you want?");
		Toppings = Console.ReadLine();

		Console.Write("How many centimeters diameter? ");
		Diameter = Convert.ToInt32(Console.ReadLine());
	}
	public void DisplayOrder()
	{
		Console.WriteLine($"\nPizza: {Toppings}\nDiameter: {Diameter}cm\nPrice At: {Price.ToString("C2")}");
	}
}
class PriceList
{
	private static double[] price = { 15.99, 27.88, 34.56, 45.89 };
	public static void DisplayPrice(int item)
	{
		double tax;
		double total;
		double pr;
		pr = price[item];
		tax = pr * Tax.DetermineTaxRate(pr);
		total = pr + tax;
		Console.WriteLine("The total price is " +
		total.ToString("C"));
	}
}
class Tax
{
	private static double[] taxRate = { 0.06, 0.07 };
	private static double CUTOFF = 20.00;
	public static double DetermineTaxRate(double price)
	{
		int subscript;
		double rate;
		if (price <= CUTOFF)
			subscript = 0;
		else
        {
				subscript = 2;
        }
		rate = taxRate[subscript];
		return rate;
	}
}
class TaxPayer : Tax
{
	private string SocialSecurityNumber { get; set; }
	private double YearlyGrossIncome { get; set; }
	//SETTING A READ-ONLY PROPERTY USING THE GET ACCESSOR
	private double TaxOwed
	{
		get
		{
			if (YearlyGrossIncome < 30000)
				return YearlyGrossIncome * 0.15;
			else
				return YearlyGrossIncome * 0.28;
		}
	}

	//CONSTRUCTOR TO ACCEPT SSN AND YearlyGrossIncome FROM USER
	public TaxPayer(string socialSecurity, double yearlyIncome)
	{
		SocialSecurityNumber = socialSecurity;
		YearlyGrossIncome = yearlyIncome;
	}
	//PRINT THE DETAILS OF THE TAXPAYER
	public void DisplayIncome()
	{
		double rate = TaxOwed / YearlyGrossIncome;

		Console.WriteLine($"\nFor Tax-Payer: {SocialSecurityNumber,18}");
		Console.WriteLine($"The income is {YearlyGrossIncome.ToString("C2"),21}");
		Console.WriteLine($"Tax Owed Amounts to: {TaxOwed.ToString("C2"),14}");
		Console.WriteLine();
		Console.WriteLine($"Calculated At: {rate.ToString("P0"),13}\n");
		Console.WriteLine();
	}
	//DECLARE ARRAY OF TAXPAYERS
	public static void DeclareTaxPayers(int numberOfTaxpayers)
	{
		string security;
		double income;

		TaxPayer[] Teachers = new TaxPayer[numberOfTaxpayers];

		for (int c = 0; c < Teachers.Length; c++)
		{
			Console.Write($"{c + 1,2}. Social Security Number: ");
			security = Console.ReadLine();
			Console.Write($"{c + 1,2}. Yearly  Income  Figure: ");
			income = Convert.ToDouble(Console.ReadLine());
			Console.WriteLine();

			Teachers[c] = new TaxPayer(security, income);
		}

		Console.Clear();

		foreach (TaxPayer Teacher in Teachers)
		{
			Teacher.DisplayIncome();
		}
	}
	//OVERLOADED OPERATORS TO COMPARE THE TAXPAYERS BY TAX OWED
	public static bool operator >(TaxPayer first, TaxPayer second)
	{
		if (first.TaxOwed > second.TaxOwed)
			return true;
		else
			return false;
	}
	public static bool operator <(TaxPayer first, TaxPayer second)
	{
		if (first.TaxOwed < second.TaxOwed)
			return true;
		else
			return false;
	}
	//FREEFORM CLASS ENTRY-POINT
	private static int[] areaCode = { 262, 414, 698, 715, 815, 920 };
	private static double[] dollarPerMinute = { 0.07, 0.10, 0.05, 0.16, 0.24, 0.14 };

	private static int[] sales = new int[3] { 0, 1000, 3000 };
	private static double[] commissions = new double[3] { 0.03, 0.04, 0.05 };

	public static void ShowWelcomeMessage()
	{
		Console.WriteLine("Welcome!");
		Console.WriteLine("It's a pleasure to serve you!");
		Console.WriteLine("Enjoy the program!");

		ChatAWhile(2);
	}
	public static void ChatAWhile(int code)
	{
		//CHECK IF AREACODE EXISTS
		if (Array.BinarySearch(areaCode, code) < 0)
			Console.WriteLine("The code you entered does not exist!\n");
		else
		{
			//CALCULATE AND DISPLAY CALL RATE
			Console.Write("For how many minutes? ");

			Console.WriteLine("The total cost of the call is ${0}\n",
			dollarPerMinute[Array.BinarySearch(areaCode, code)] * Convert.ToInt32(Console.ReadLine()));
		}
	}
	//ALIGN COMMISSIONS FIGURE WITH SALES FIGURE
	public static double Commissions(int sale)
	{
		int i;
		for (i = 0; i < sales.Length && sale >= sales[i + 1]; i++) { }
		return commissions[i];
	}
}
class Program
{
	public static void Main()
    {
        //MAIN ENTRY POINT
        Console.WriteLine("Hello World!\n\nCalling Method A");
        try
        {
            MethodA();
            Console.WriteLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("{0}\n{1}", e.Message, e.StackTrace);

        }
        //KEEP THE PROGRAM HANGING
        Console.ReadLine();
		return;
	}
	public static void MethodA()
    {
        try
        {
            Console.WriteLine("Calling Method B");
            MethodB();
        }
        catch (Exception)
        {
            Console.WriteLine("Caught in Method A!\n");
			throw;
        }
    }
    public static void MethodB()
    {
        try
        {
            Console.WriteLine("Calling Method C");
            MethodC();
        }
        catch (Exception)
        {
            Console.WriteLine("Caught in Method B!");
			throw;
        }
    }
    public static void MethodC()
    {
        try
        {
            Console.WriteLine();
            BankAccount future = new BankAccount(1234, 60);
			Console.WriteLine();
			BankAccount present = new BankAccount(12345, 50);
            Console.WriteLine();
			BankAccount past = new BankAccount(123456, -1000);
            Console.WriteLine();
        }
        catch (Exception)
        {
            Console.WriteLine("Caught in Method C!");
            throw;
        }
	}
}