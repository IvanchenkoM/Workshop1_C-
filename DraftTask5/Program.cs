// Конвертер валют
// У пользователя есть баланс каждой из представленных валют.
// С помощью команд может попоросить сконвертировать одну из валют в другую и перевести с баланса
// одной на другую.
// Курс конвертации просто описать в программе.
// Программа завершает работу в тот момент, когда решит пользователь. 

bool circle = true;

Console.WriteLine("\r\nHello!\r\nThis is a currency converter.");
double numberEUR = 70.65;
double numberUSD = 100.00;
double numberCNY = 150.78;

double rateEURtoUSD = 1.06509;
double rateEURtoCNY = 7.40083;
double rateUSDtoEUR = 0.93888;
double rateUSDtoCNY = 6.95507;
double rateCNYtoEUR = 0.13512;
double rateCNYtoUSD = 0.14378;

while(circle)
{
    string userChoice = ReadString("\r\nChoose the option:\r\n-> Balance\r\n-> Conversion  \r\n-> Exit\r\n");
    userChoice = userChoice.ToLower().Replace(" ","").Replace("-","");

    switch(userChoice)
    {
        case "exit":
            Console.WriteLine("\r\nSee you later.");
            circle = false;
            break;
            
        case "balance":
            Console.WriteLine($"\r\nYour accounts:\r\n{string.Format("EUR = {0:C2}",numberEUR)} \r\n{string.Format("USD = {0:C2}",numberUSD)} \r\n{string.Format("CNY = {0:C2}",numberCNY)}\r\n");
            break;
                
        case "conversion":
            bool converCircle = true;
            while(converCircle)
            {
                string currency = ReadString("\r\nWhat currency do you want to convert: EUR, USD or CNY?\r\n");
                currency = currency.ToLower().Replace(" ","");
                switch(currency)
                {
                    case "eur":
                        double amountEUR = ReadDouble($"How many {currency.ToUpper()} do you want to convert?\r\n");
                        if (amountEUR > numberEUR || amountEUR < 0)
                        {
                            Console.WriteLine($"\r\nYou have {string.Format("{0:C2} EUR",numberEUR)}. Try again.");
                            break;
                        }
                        string convertCurrencyEUR = ReadString($"What currency do you want to transfer {amountEUR} {currency.ToUpper()}: USD or CNY?\r\n");
                        convertCurrencyEUR = convertCurrencyEUR.ToLower().Replace(" ","");
                        if (convertCurrencyEUR == currency)
                        {
                            Console.WriteLine($"\r\nYou have chosen the same currency. Try again.");
                        }
                        else if (convertCurrencyEUR == "usd")
                        {
                            numberEUR -= amountEUR;
                            numberUSD += amountEUR*rateEURtoUSD;
                            Console.WriteLine($"\r\nYou convert {amountEUR} {currency.ToUpper()} to {string.Format("{0:C2} USD",amountEUR*rateEURtoUSD)}.");
                            Console.WriteLine($"\r\nYour accounts:\r\n{string.Format("EUR = {0:C2}",numberEUR)} \r\n{string.Format("USD = {0:C2}",numberUSD)} \r\n{string.Format("CNY = {0:C2}",numberCNY)}\r\n");
                            converCircle = false;
                        }
                        else if (convertCurrencyEUR == "cny")
                        {
                            numberEUR -= amountEUR;
                            numberCNY += amountEUR*rateEURtoCNY;
                            Console.WriteLine($"\r\nYou convert {amountEUR} {currency.ToUpper()} to {string.Format("{0:C2} CNY",amountEUR*rateEURtoCNY)}.");
                            Console.WriteLine($"\r\nYour accounts:\r\n{string.Format("EUR = {0:C2}",numberEUR)} \r\n{string.Format("USD = {0:C2}",numberUSD)} \r\n{string.Format("CNY = {0:C2}",numberCNY)}\r\n");
                            converCircle = false;
                        }
                        break;

                    case "usd":
                        double amountUSD = ReadDouble($"How many {currency.ToUpper()} do you want to convert?\r\n");
                        if (amountUSD > numberUSD || amountUSD < 0)
                        {
                            Console.WriteLine($"\r\nYou have {string.Format("{0:C2} USD",numberUSD)}. Try again.");
                            break;
                        }
                        string convertCurrencyUSD = ReadString($"What currency do you want to transfer {amountUSD} {currency.ToUpper()}: EUR or CNY?\r\n");
                        convertCurrencyUSD = convertCurrencyUSD.ToLower().Replace(" ","");
                        if (convertCurrencyUSD == currency)
                        {
                            Console.WriteLine($"\r\nYou have chosen the same currency. Try again.");
                        }
                        else if (convertCurrencyUSD == "eur")
                        {
                            numberUSD -= amountUSD;
                            numberEUR += amountUSD*rateUSDtoEUR;
                            Console.WriteLine($"\r\nYou convert {amountUSD} {currency.ToUpper()} to {string.Format("{0:C2} EUR",amountUSD*rateUSDtoEUR)}.");
                            Console.WriteLine($"\r\nYour accounts:\r\n{string.Format("EUR = {0:C2}",numberEUR)} \r\n{string.Format("USD = {0:C2}",numberUSD)} \r\n{string.Format("CNY = {0:C2}",numberCNY)}\r\n");
                            converCircle = false;
                        }
                        else if (convertCurrencyUSD == "cny")
                        {
                            numberUSD -= amountUSD;
                            numberCNY += amountUSD*rateUSDtoCNY;
                            Console.WriteLine($"\r\nYou convert {amountUSD} {currency.ToUpper()} to {string.Format("{0:C2} CNY",amountUSD*rateUSDtoCNY)}.");
                            Console.WriteLine($"\r\nYour accounts:\r\n{string.Format("EUR = {0:C2}",numberEUR)} \r\n{string.Format("USD = {0:C2}",numberUSD)} \r\n{string.Format("CNY = {0:C2}",numberCNY)}\r\n");
                            converCircle = false;
                        }
                        break;

                    case "cny":
                        double amountCNY = ReadDouble($"How many {currency.ToUpper()} do you want to convert?\r\n");
                        if (amountCNY > numberCNY || amountCNY < 0)
                        {
                            Console.WriteLine($"\r\nYou have {string.Format("{0:C2} CNY",numberCNY)}. Try again.");
                            break;
                        }
                        string convertCurrencyCNY = ReadString($"What currency do you want to transfer {amountCNY} {currency.ToUpper()}: USD or EUR?\r\n");
                        convertCurrencyCNY = convertCurrencyCNY.ToLower().Replace(" ","");
                        if (convertCurrencyCNY == currency)
                        {
                            Console.WriteLine($"\r\nYou have chosen the same currency. Try again.");
                        }
                        else if (convertCurrencyCNY == "usd")
                        {
                            numberCNY -= amountCNY;
                            numberUSD += amountCNY*rateCNYtoUSD;
                            Console.WriteLine($"\r\nYou convert {amountCNY} {currency.ToUpper()} to {string.Format("{0:C2} USD",amountCNY*rateCNYtoUSD)}.");
                            Console.WriteLine($"\r\nYour accounts:\r\n{string.Format("EUR = {0:C2}",numberEUR)} \r\n{string.Format("USD = {0:C2}",numberUSD)} \r\n{string.Format("CNY = {0:C2}",numberCNY)}\r\n");
                            converCircle = false;
                        }
                        else if (convertCurrencyCNY == "eur")
                        {
                            numberCNY -= amountCNY;
                            numberEUR += amountCNY*rateCNYtoEUR;
                            Console.WriteLine($"\r\nYou convert {amountCNY} {currency.ToUpper()} to {string.Format("{0:C2} EUR",amountCNY*rateCNYtoEUR)}.");
                            Console.WriteLine($"\r\nYour accounts:\r\n{string.Format("EUR = {0:C2}",numberEUR)} \r\n{string.Format("USD = {0:C2}",numberUSD)} \r\n{string.Format("CNY = {0:C2}",numberCNY)}\r\n");
                            converCircle = false;
                        }
                        break;

                    default:
                        Console.WriteLine("\r\nWrong currency. Try again.");
                        break;
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