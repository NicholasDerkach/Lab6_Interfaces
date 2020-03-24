using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;

namespace Lab6_Interfaces
{
    class Program
    {
        static void Main()
        {
            ConsoleColor dftForeColor = Console.ForegroundColor;
            ConsoleColor dftBackColor = Console.BackgroundColor;
            bool continueFlag = true;


            Console.Clear();
            Console.WriteLine("Write, what you wnat to do?");
            Console.WriteLine("1 - read existing contact\n2 - add new contact\n3 - change color\n4 - play music\n5 - end progarm");
            int k = 0;
            //Check for correct data
            while (!int.TryParse(Console.ReadLine(), out k) && k < 1 && k > 4)
            {
                Console.WriteLine("Does not appropriate data");
            }

            //Creating directory for contacts if it is not exist
            string path = "C:\\Users\\nicho\\Desktop";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            switch (k)
            {
                #region ReadContact
                case 1:
                    using (FileStream fstream = File.OpenRead($"{path}\\lab6.txt"))
                    {
                        byte[] array = new byte[fstream.Length];
                        fstream.Read(array, 0, array.Length);
                        string textFromFile = System.Text.Encoding.Default.GetString(array);
                        Console.WriteLine($"\n{textFromFile}");
                        Console.WriteLine("Press any button to continue");
                        Console.ReadKey();
                    }
                    Main();
                    break;
                #endregion
                #region WriteContact
                case 2:
                    List<Contact> list = new List<Contact>();
                    string iteration = "";
                    int number = 0;
                    string name = "";
                    string email = "";
                    string phone = "";

                    do
                    {
                        number++;

                        Console.WriteLine("Enter the name:");
                        name = Console.ReadLine();

                        Console.WriteLine("Enter an email");
                        email = Console.ReadLine();

                        Console.WriteLine("Enter the phone number");
                        phone = Console.ReadLine();

                        list.Add(new Contact(name, email, phone));

                        Console.WriteLine("Enter \"+\", if you want to add another contact");
                        iteration = Console.ReadLine();

                    }
                    while (iteration == "+");
                    string text = "";

                    for (int i = 0; i < list.Count; i++)
                    {
                        Console.WriteLine(list[i].DisplayInfo());
                        text += list[i].DisplayInfo() + "\n";
                    }

                    // write in file
                    using (FileStream fstream = new FileStream($"{path}\\lab6.txt", FileMode.OpenOrCreate))
                    {
                        byte[] array = System.Text.Encoding.Default.GetBytes(text);
                        fstream.Write(array, 0, array.Length);
                        Console.WriteLine("All contacts were added");
                    }

                    Main();
                    break;
                #endregion
                #region ChangeColor
                case 3:
                    do
                    {
                        ConsoleColor newForeColor = ConsoleColor.White;
                        ConsoleColor newBackColor = ConsoleColor.Black;

                        Char foreColorSelection = GetKeyPress("Select Text Color (B for Blue, R for Red, Y for Yellow): ",
                                                             new Char[] { 'B', 'R', 'Y' });
                        switch (foreColorSelection)
                        {
                            case 'B':
                            case 'b':
                                newForeColor = ConsoleColor.DarkBlue;
                                break;
                            case 'R':
                            case 'r':
                                newForeColor = ConsoleColor.DarkRed;
                                break;
                            case 'Y':
                            case 'y':
                                newForeColor = ConsoleColor.DarkYellow;
                                break;
                        }
                        Char backColorSelection = GetKeyPress("Select Background Color (W for White, G for Green, M for Magenta): ",
                                                             new Char[] { 'W', 'G', 'M' });
                        switch (backColorSelection)
                        {
                            case 'W':
                            case 'w':
                                newBackColor = ConsoleColor.White;
                                break;
                            case 'G':
                            case 'g':
                                newBackColor = ConsoleColor.Green;
                                break;
                            case 'M':
                            case 'm':
                                newBackColor = ConsoleColor.Magenta;
                                break;
                        }

                        Console.WriteLine();
                        Console.Write("Enter a message to display: ");
                        String textToDisplay = Console.ReadLine();
                        Console.WriteLine();
                        Console.ForegroundColor = newForeColor;
                        Console.BackgroundColor = newBackColor;
                        Console.WriteLine(textToDisplay);
                        Console.WriteLine();
                        if (Char.ToUpper(GetKeyPress("Display another message (Y/N): ", new Char[] { 'Y', 'N' })) == 'N')
                            continueFlag = false;

                        // Restore the default settings and clear the screen.
                        Console.ForegroundColor = dftForeColor;
                        Console.BackgroundColor = dftBackColor;
                        Console.Clear();
                    } while (continueFlag);
                    Main();
                    break;
                #endregion
                #region PlayMusic
                case 4:
                    Console.WriteLine("Write, what music do you want to listen");
                    Console.WriteLine("1 - Happy birthday\n2 - Mission imposible\n3 - grasshopper");
                    int music = 0;
                    while (!int.TryParse(Console.ReadLine(), out music) && music < 1 && music > 3)
                    {
                        Console.WriteLine("Does not appropriate data");
                    }
                    switch (music)
                    {
                        case 1:
                            HappyBirthday();
                            break;
                        case 2:
                            MissionImpossible();
                            break;
                        case 3:
                            Grasshoper();
                            break;
                    }
                    Main();
                    break;
                #endregion
                #region End
                default:
                    break;
                    #endregion
            }
        }

        private static Char GetKeyPress(String msg, Char[] validChars)
        {
            ConsoleKeyInfo keyPressed;
            bool valid = false;

            Console.WriteLine();
            do
            {
                Console.Write(msg);
                keyPressed = Console.ReadKey();
                Console.WriteLine();
                if (Array.Exists(validChars, ch => ch.Equals(Char.ToUpper(keyPressed.KeyChar))))
                    valid = true;
            } while (!valid);
            return keyPressed.KeyChar;
        }

        #region Music
        private static void MissionImpossible()
        {
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(932, 150);
            Thread.Sleep(150);
            Console.Beep(1047, 150);
            Thread.Sleep(150);
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(699, 150);
            Thread.Sleep(150);
            Console.Beep(740, 150);
            Thread.Sleep(150);
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(932, 150);
            Thread.Sleep(150);
            Console.Beep(1047, 150);
            Thread.Sleep(150);
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(784, 150);
            Thread.Sleep(300);
            Console.Beep(699, 150);
            Thread.Sleep(150);
            Console.Beep(740, 150);
            Thread.Sleep(150);
            Console.Beep(932, 150);
            Console.Beep(784, 150);
            Console.Beep(587, 1200);
            Thread.Sleep(75);
            Console.Beep(932, 150);
            Console.Beep(784, 150);
            Console.Beep(554, 1200);
            Thread.Sleep(75);
            Console.Beep(932, 150);
            Console.Beep(784, 150);
            Console.Beep(523, 1200);
            Thread.Sleep(150);
            Console.Beep(466, 150);
            Console.Beep(523, 150);
        }
        private static void HappyBirthday()
        {
            Thread.Sleep(2000);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(297, 500);
            Thread.Sleep(125);
            Console.Beep(264, 500);
            Thread.Sleep(125);
            Console.Beep(352, 500);
            Thread.Sleep(125);
            Console.Beep(330, 1000);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(297, 500);
            Thread.Sleep(125);
            Console.Beep(264, 500);
            Thread.Sleep(125);
            Console.Beep(396, 500);
            Thread.Sleep(125);
            Console.Beep(352, 1000);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(2642, 500);
            Thread.Sleep(125);
            Console.Beep(440, 500);
            Thread.Sleep(125);
            Console.Beep(352, 250);
            Thread.Sleep(125);
            Console.Beep(352, 125);
            Thread.Sleep(125);
            Console.Beep(330, 500);
            Thread.Sleep(125);
            Console.Beep(297, 1000);
            Thread.Sleep(250);
            Console.Beep(466, 125);
            Thread.Sleep(250);
            Console.Beep(466, 125);
            Thread.Sleep(125);
            Console.Beep(440, 500);
            Thread.Sleep(125);
            Console.Beep(352, 500);
            Thread.Sleep(125);
            Console.Beep(396, 500);
            Thread.Sleep(125);
            Console.Beep(352, 1000);
        }
        private static void Grasshoper()
        {
            Console.Beep(440, 300);
            Console.Beep(330, 300);
            Console.Beep(440, 300);
            Console.Beep(330, 300);
            Console.Beep(440, 300);
            Console.Beep(415, 300);
            Console.Beep(415, 300);
            Thread.Sleep(600);
            Console.Beep(415, 300);
            Console.Beep(330, 300);
            Console.Beep(415, 300);
            Console.Beep(330, 300);
            Console.Beep(415, 300);
            Console.Beep(440, 300);
            Console.Beep(440, 300);
            Thread.Sleep(600);
            Console.Beep(440, 300);
            Console.Beep(494, 300);
            Console.Beep(494, 100);
            Console.Beep(494, 100);
            Console.Beep(494, 300);
            Console.Beep(494, 300);
            Console.Beep(523, 300);
            Console.Beep(523, 100);
            Console.Beep(523, 100);
            Console.Beep(523, 300);
            Console.Beep(523, 300);
            Console.Beep(523, 300);
            Console.Beep(494, 300);
            Console.Beep(440, 300);
            Console.Beep(415, 300);
            Console.Beep(440, 800);
        }
        #endregion
    }
    struct Contact
    {
        public string Name { get; }
        public string Email { get; }
        public string PhoneNumber { get; }

        public Contact(string name, string email, string phoneNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public string DisplayInfo()
        {
            return $"Name: {Name}, Email: {Email}, PhoneNumber: {PhoneNumber} ";
        }
    }
}