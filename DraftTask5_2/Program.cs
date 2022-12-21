// Конвертер валют
// У пользователя есть баланс каждой из представленных валют.
// С помощью команд может попоросить сконвертировать одну из валют в другую и перевести с баланса
// одной на другую.
// Курс конвертации просто описать в программе.
// Программа завершает работу в тот момент, когда решит пользователь. 

using System.Globalization;
bool circle = true;
//Console.OutputEncoding = System.Text.Encoding.Unicode;

Console.WriteLine("\r\nHello!\r\nThis is a currency converter.");
double numberEUR = 70.65;
double numberUSD = 100.00;
double numberCNY = 150.78;

string[] arrayCurrency = {"EUR", "USD", "CNY"};
double[] arrayAccount = {numberEUR,numberUSD,numberCNY};

double rateEURtoUSD = 1.06509;
double rateEURtoCNY = 7.40083;
double rateUSDtoEUR = 0.93888;
double rateUSDtoCNY = 6.95507;
double rateCNYtoEUR = 0.13512;
double rateCNYtoUSD = 0.14378;

double[,] arrayRate = new double[3,2] {{rateEURtoUSD,rateEURtoCNY},{rateUSDtoEUR,rateUSDtoCNY},{rateCNYtoEUR,rateCNYtoUSD}};

while(circle)
{
    string userChoice = ReadString("\r\nChoose the option:\r\n-> Balance\r\n-> Conversion  \r\n-> Exit\r\n");
    userChoice = userChoice.ToUpper().Replace(" ","").Replace("-","");

    switch(userChoice)
    {
        case "EXIT":
            Console.WriteLine("\r\nSee you later.");
            circle = false;
            break;
            
        case "BALANCE":
            Console.WriteLine($"\r\nYour accounts:\r\n{WriteCurrencySing(arrayCurrency[0],arrayAccount[0])} \r\n{WriteCurrencySing(arrayCurrency[1],arrayAccount[1])} \r\n{WriteCurrencySing(arrayCurrency[2],arrayAccount[2])}\r\n");
            break;
                
        case "CONVERSION":
            bool converCircle = true;
            while(converCircle)
            {
                string currency = ReadString("\r\nWhat currency do you want to convert: EUR, USD or CNY?\r\n");
                currency = currency.ToUpper().Replace(" ","");
                for (int i=0; i < arrayCurrency.Length; i++)
                {
                    if (currency == arrayCurrency[i])
                    {
                        double amount = ReadDouble($"How many {currency.ToUpper()} do you want to convert?\r\n");

                        if (amount > arrayAccount[i] || amount < 0)
                        {
                            Console.WriteLine($"\r\nYou have {WriteCurrencySing(arrayCurrency[i],amount)}. Try again.");
                            break;
                        }
                        
                        string convertCurrency = ReadOutgoingCurrency(amount,currency).ToUpper().Replace(" ","");
                        
                        if (currency == convertCurrency)
                        {
                            Console.WriteLine($"\r\nYou have chosen the same currency. Try again.");
                            break;
                        }

                        Calculation(currency,amount,convertCurrency,converCircle);
                    }
                }

            }
            break;
                
        default:
            Console.WriteLine("\r\nInvalid command. Try again.");
            break;           
    }
}

string ReadString(string msg)
{
    Console.Write(msg);
    return Convert.ToString(Console.ReadLine())??String.Empty;
}

double ReadDouble(string msg)
{
    Console.Write(msg);
    return Convert.ToDouble(Console.ReadLine());
}

bool Calculation (string entryCurrency, double number, string outgoingCurrency, bool stopCircle)
{
    for (int i=0; i < arrayRate.GetLength(0); i++)
    {
        if (entryCurrency == arrayCurrency[i])
            arrayAccount[i] -= number;
        for (int j=0; j < arrayRate.GetLength(1); j++)
        {
            if (outgoingCurrency == arrayCurrency[i])
            {
                double temp = number*arrayRate[i,j];
                arrayAccount[i] += temp;
                Console.WriteLine($"\r\nYou convert {number} {entryCurrency} to {WriteCurrencySing(outgoingCurrency,temp)}.");
            }
        }
    }
    Console.WriteLine($"\r\nYour accounts:\r\n{WriteCurrencySing(arrayCurrency[0],arrayAccount[0])} \r\n{WriteCurrencySing(arrayCurrency[1],arrayAccount[1])} \r\n{WriteCurrencySing(arrayCurrency[2],arrayAccount[2])}\r\n");
    return stopCircle = false;
}

string WriteCurrencySing (string whatCurrency, double number)
{
    string result = "";
    var usd = new CultureInfo("en-US");
    var cny =  new CultureInfo("zh-CN");
    if (whatCurrency == arrayCurrency[0])
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("fr");
        Console.WriteLine("{0:C2}", arrayAccount[0]);
    }
    else if (whatCurrency == arrayCurrency[1])
        Console.WriteLine($"{arrayAccount[1]} {usd.NumberFormat.CurrencySymbol}");
    else if (whatCurrency == arrayCurrency[2])
        Console.WriteLine($"{arrayAccount[2]} {cny.NumberFormat.CurrencySymbol}");
    return result;
}

string ReadOutgoingCurrency (double number, string incomingCurrency)
{
    List<string> listCurrency = new List<string>();
    listCurrency.AddRange(arrayCurrency);
    for (int i=0; i<listCurrency.Count; i++)
    {
        if (listCurrency[i] == incomingCurrency)
            listCurrency.Remove(listCurrency[i]);
    }
    string result = ReadString($"What currency do you want to transfer {number} {incomingCurrency}: {listCurrency[0]} or {listCurrency[1]}?\r\n");
    return result; 
}