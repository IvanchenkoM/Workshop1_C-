/* 1 переменная секретное сообщение.
2 - пароль
3 попытки ввести пароль
и увидеть секретное сообщение*/

string secretMsg = "Well done";
string password = "Qwerty123";

for (int i=1; i<=3; i++)
{
    string userAnswer = ReadIn("Enter the password: ");
    int result = string.Compare(userAnswer,password);
    if (result==0)
    {
        Console.WriteLine($"Right password. Your secret message: {secretMsg}.");
        break;
    }
    else
    {
        Console.WriteLine($"Invalid password. Remaining attempts {3-i}.");
    }
}

string ReadIn(string msg)
{
    Console.Write(msg);
    return Convert.ToString(Console.ReadLine())??String.Empty;
}