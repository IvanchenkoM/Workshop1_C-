// Есть программа с бесконечным циклом. Когда пользователь вводит exit программа заканчивается.
// + Добавить еще 4 команды.

bool circle = true;
string[] stopCircle = {"exit", "setname", "help", "setpassword", "setemail"};

while(circle)
{
    string userAnswer = ReadIn("Guess the word: ");
    userAnswer = userAnswer.ToLower().Replace(" ","").Replace("-","");
    
    for (int i=0; i < stopCircle.Length; i++)
    {
        int temp = string.Compare(userAnswer,stopCircle[i]);
        if (temp == 0)
        {
            switch(stopCircle[i])
            {
                case "exit":
                    Console.WriteLine();
                    Console.WriteLine("Excellent!");
                    return;
                
                case "setname":
                    Console.WriteLine();
                    string userName = ReadIn("Set your name:");
                    Console.WriteLine();
                    break;
                
                case "help":
                    Console.WriteLine();
                    Console.WriteLine("There are five options:\r\nHelp \r\nSet Name \r\nSet Password \r\nSet e-mail \r\nExit");
                    Console.WriteLine();
                    break;
                
                case "setpassword":
                    Console.WriteLine();
                    string userPassword = ReadIn("Set your password:");
                    Console.WriteLine();
                    break;
                
                case "setemail":
                    Console.WriteLine();
                    string userEmail = ReadIn("Set your e-mail:");
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("Wrong word. Try again.");
                    break;

                
            }    
        }
    }
}

string ReadIn(string msg)
{
    Console.Write(msg);
    return Convert.ToString(Console.ReadLine())??String.Empty;
}