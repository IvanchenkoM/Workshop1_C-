// Есть программа с бесконечным циклом. Когда пользователь вводит exit программа заканчивается.
// + Добавить еще 4 команды.

bool circle = true;

string[] stopCircle = {"exit", "date", "allnotes", "account", "makenote"};

string userEmail = ReadInt("\r\nBefore you start \r\nEnter your e-mail: ");
string userPassword ="";
while(circle)
{
    userPassword = ReadInt ("\r\nCreate a password: ");
    string password2 = ReadInt ("\r\nEnter the password again: ");
    if (userPassword == password2)
        break;
    Console.WriteLine("\r\nPasswords do not match. Please try again.");
}

string userName = ReadInt("\r\nEnter a username:");
string userNotes="";

while(circle)
{
    Console.WriteLine("\r\nThere are five options:\r\n-> Account \r\n-> Date \r\n-> Make note \r\n-> All notes \r\n-> Exit");
    string userChoice = ReadInt("\r\nChoose the option: ");
    userChoice = userChoice.ToLower().Replace(" ","").Replace("-","");
   
    if (userChoice == stopCircle[0])
    {
        Console.WriteLine("\r\nSee you later.");
        break;
    }
    else if (userChoice == stopCircle[1])
    {
        Console.WriteLine($"\r\nToday {DateTime.Now}");
    }
    else if (userChoice == stopCircle[2])
    {
        Console.WriteLine($"\r\nYour notes:\r\n{userNotes}");
    }
    else if (userChoice == stopCircle[3])
    {
        string enteredPassword = ReadInt("\r\nSet password:");
        if (userPassword == enteredPassword)
            Console.WriteLine($"\r\nUser name:{userName}\r\nUser e-mail:{userEmail}.");
        else
            Console.WriteLine("\r\nWrong password. Try again.");
    }
    else if (userChoice == stopCircle[4])
    {
        string note = ReadInt("\r\nNote: ");
        userNotes += note+" - "+DateTime.Now+";\r\n";
    }                
    else
    {
        Console.WriteLine("\r\nWrong word. Try again.");
    }
    
    //в switch не получилось сделать заполнить userNotes
    /*switch(userChoice)
    {
        case "exit":
            Console.WriteLine("\r\nSee you later.");
            return;
            
        case "date":
            Console.WriteLine($"\r\nToday {DateTime.Now}");
            break;
                
        case "makenote":
            string note = ReadInt("\r\nNote: ");
            userNotes = userNotes + ";|r\n" + note;
            break;
                
        case "account":
            string enteredPassword = ReadInt("\r\nSet password:");
            if (userPassword == enteredPassword)
                Console.WriteLine($"\r\nUser name:{userName}\r\nUser e-mail:{userEmail}.");
            else
                Console.WriteLine("\r\nWrong password. Try again.");
            break;        
                
        case "allnotes":
            Console.WriteLine($"\r\n{userNotes}");
            break;

        default:
            Console.WriteLine("\r\nWrong word. Try again.");
            break;           
    }*/
}

string ReadInt(string msg)
{
    Console.Write(msg);
    return Convert.ToString(Console.ReadLine())??String.Empty;
}