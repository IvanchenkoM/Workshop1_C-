using System.Globalization;
Console.OutputEncoding = System.Text.Encoding.Unicode;

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
        case "BAL":
            Console.WriteLine("\r\nYour accounts:\r\n");
            foreach (var sign in accountBalance)
            {
                Console.WriteLine($"{sign.Key} account = {WriteCurrencySing(sign.Key, sign.Value)}");
                //Console.Write(WriteCurrencySing(sign.Key, sign.Value));
            }
            break;
                
        case "CONVERSION":
        case "CON":
            bool converCircle = true;
            while(converCircle)
            {
                string currency = ReadString("\r\nWhat currency do you want to convert: EUR, USD or CNY?\t");
                currency = currency.ToUpper().Replace(" ","");
                for (int i=0; i < accountBalance.Keys.Count; i++)
                {
                    if (currency == accountBalance.ElementAt(i).Key)
                    {
                        double amount = ReadDouble($"How many {currency.ToUpper()} do you want to convert?\t");
                        
                        if (amount > accountBalance.ElementAt(i).Value || amount < 0)
                        {
                            Console.WriteLine($"\r\nYou have {WriteCurrencySing(accountBalance.ElementAt(i).Key, accountBalance.ElementAt(i).Value)} in your account. Try again.");
                            break;
                        }
                        
                        string convertCurrency = ReadOutgoingCurrency(amount,currency).ToUpper().Replace(" ","");
                        
                        if (currency == convertCurrency)
                        {
                            Console.WriteLine($"\r\nYou have chosen the same currency. Try again.");
                            break;
                        }
                        else if (convertCurrency!=accountBalance.ElementAt(0).Key && convertCurrency!=accountBalance.ElementAt(1).Key && convertCurrency!=accountBalance.ElementAt(2).Key) 
                        {
                            Console.WriteLine("\r\nYou enter the wrong currency. Try again.");
                            break;
                        }
                        Calculation(currency,amount,convertCurrency);
                        converCircle = false;
                    }
                    else if ((currency!=accountBalance.ElementAt(0).Key && currency!=accountBalance.ElementAt(1).Key && currency!=accountBalance.ElementAt(2).Key))
                    {
                        Console.WriteLine("\r\nYou enter the wrong currency. Try again.");
                        break;
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
    double temp = Convert.ToDouble(Console.ReadLine());
    if (int.TryParse(Console.ReadLine(),out int num))
    {
        Console.Write("");
    }
    else
    {
        Console.WriteLine("Please enter only number");
    }
    return temp;
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
        Console.WriteLine($"{sign.Key} account = {WriteCurrencySing(sign.Key, sign.Value)}");
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
    string result = ReadString($"What currency do you want to transfer {number} {incomingCurrency}: {listCurrency[0]} or {listCurrency[1]}?\t");
    return result; 
}

string WriteCurrencySing (string whatCurrency, double number)
{
    string result = "";
    if (whatCurrency == accountBalance.ElementAt(0).Key)
    {
        CultureInfo.CurrentCulture = new CultureInfo("fr-Be");
        result = String.Format("{0:C2}",accountBalance.ElementAt(0).Value);
    }
    else if (whatCurrency == accountBalance.ElementAt(1).Key)
    {
        CultureInfo.CurrentCulture = new CultureInfo("en-US");
        result = String.Format("{0:C2}",accountBalance.ElementAt(1).Value);
    }
    else if (whatCurrency == accountBalance.ElementAt(2).Key)
    {
        CultureInfo.CurrentCulture = new CultureInfo("zh-CN");
        result = String.Format("{0:C2}",accountBalance.ElementAt(2).Value);
    }
    return result;
}