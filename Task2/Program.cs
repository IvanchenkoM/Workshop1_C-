// Есть программа с бесконечным циклом. Когда пользователь вводит exit программа заканчивается.

bool circle = true;
string stopCircle = "exit";

while(circle)
{
    string userAnswer = ReadIn("Guess the word: ");

    int result = string.Compare(userAnswer.ToLower(),stopCircle);
    if (result==0)
    {
        Console.WriteLine("Excellent!");
        break;
    }
    else
    {
        Console.WriteLine("Wrong word. Try again.");
    }
}

string ReadIn(string msg)
{
    Console.Write(msg);
    return Convert.ToString(Console.ReadLine())??String.Empty;
}