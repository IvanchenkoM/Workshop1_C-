bool circle = true;
Console.WriteLine("\r\nHello! \r\nThis is a currency converter.");

double numberEUR = 55.66;
double numberUSD = 102.00;
double numberCNY = 360.70;

Dictionary<string, double> accountBalance = new Dictionary<string, double>()
{
    {"EUR", numberEUR},
    {"USD", numberUSD},
    {"CNY", numberCNY}
};

double rateEURtoUSD = 1.06000;
double rateEURtoCNY = 7.42000;
double rateUSDtoEUR = 0.94047;
double rateUSDtoCNY = 6.99000;
double rateCNYtoEUR = 0.13474;
double rateCNYtoUSD = 0.14297;

double[,] arrayRate = new double[3,3] 
{
    {0,rateEURtoUSD,rateEURtoCNY},
    {rateUSDtoEUR,0,rateUSDtoCNY},
    {rateCNYtoEUR,rateCNYtoUSD,0}
};

while(circle)
{
    string userChoice = ReadString("\r\nChoose the option:\r\n-> Balance\r\n-> Conversion  \r\n-> Exit\r\n\r\n");
    userChoice = userChoice.ToUpper().Replace(" ","").Replace("-","");

    switch(userChoice)
    {
        case "EXIT":
            Console.WriteLine("\r\nSee you later.");
            circle = false;
            break;
            
        case "BALANCE":
            Console.WriteLine("\r\nYour accounts:\r\n");
            foreach (var sign in accountBalance)
            {
                Console.WriteLine($"{sign.Key} account = {sign.Value} {sign.Key}");
            }
            break;
                
        case "CONVERSION":
            bool converCircle = true;
            while(converCircle)
            {
                string currency = ReadString("\r\nWhat currency do you want to convert: EUR, USD or CNY?\r\n");
                currency = currency.ToUpper().Replace(" ","");
                for (int i=0; i < accountBalance.Keys.Count; i++)
                {
                    if (currency == accountBalance.ElementAt(i).Key)
                    {
                        double amount = ReadDouble($"How many {currency.ToUpper()} do you want to convert?\r\n");

                        if (amount > accountBalance.ElementAt(i).Value || amount < 0)
                        {
                            Console.WriteLine($"\r\nYou have {accountBalance.ElementAt(i).Value} {accountBalance.ElementAt(i).Key} in your account. Try again.");
                            break;
                        }
                        
                        string convertCurrency = ReadOutgoingCurrency(amount,currency).ToUpper().Replace(" ","");
                        
                        if (currency == convertCurrency)
                        {
                            Console.WriteLine($"\r\nYou have chosen the same currency. Try again.");
                            break;
                        }
                        Calculation(currency,amount,convertCurrency);
                        converCircle = false;
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

void Calculation (string entryCurrency, double number, string outgoingCurrency)
{
    double[] myIntArray = new double[3];
    for (int i=0; i<myIntArray.Length; i++)
    {
        myIntArray[i] = accountBalance.ElementAt(i).Value;
    }

    for (int i=0; i < arrayRate.GetLength(0); i++)
    {
        if (entryCurrency == accountBalance.ElementAt(i).Key)
        {
            myIntArray[i] -= number;
            accountBalance.Remove(entryCurrency);
            accountBalance.Add(entryCurrency, myIntArray[i]);

            for (int j=0; j < arrayRate.GetLength(0); j++)
            {
                if (outgoingCurrency == accountBalance.ElementAt(j).Key)
                {
                    double temp = number*arrayRate[i,j];
                    myIntArray[j] += temp;
                    accountBalance.Remove(outgoingCurrency);
                    accountBalance.Add(outgoingCurrency, myIntArray[j]);
                    Console.WriteLine($"\r\nYou convert {number} {entryCurrency} to {temp} {accountBalance.ElementAt(j).Key}.");
                    break;
                }
            }
        }
    }
    Console.WriteLine("\r\nYour accounts:\r\n");
    foreach (var sign in accountBalance)
    {
        Console.WriteLine($"{sign.Key} account = {sign.Value} {sign.Key}");
    }
}

string ReadOutgoingCurrency (double number, string incomingCurrency)
{
    List<string> listCurrency = new List<string>();
    ICollection<string> keys = accountBalance.Keys;
    listCurrency.AddRange(keys);
    for (int i=0; i<listCurrency.Count; i++)
    {
        if (listCurrency[i] == incomingCurrency)
            listCurrency.Remove(listCurrency[i]);
    }
    string result = ReadString($"What currency do you want to transfer {number} {incomingCurrency}: {listCurrency[0]} or {listCurrency[1]}?\r\n");
    return result; 
}