

using System.Threading.Tasks.Dataflow;

namespace ConsoleApp3Tb3
{
 

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You may use next command:");
            Console.WriteLine("    /start, /help, /info, /echo, /exit, /addtask, /showtasks, /removetask");


            string? name = null;  // имя пользователя
            string? input;        // переменнная ввода  команд с консоли
            var ListTask = new List<string> (); // список заданий


            input = Console.ReadLine();



            while (input != "/exit")
            {
                //
                string? AfterEcho = null; // переменная сохраняет символы после /echo
                if (input?.Length >= 5) AfterEcho = input?.Substring(5);
                if (input?.Length >= 5) input = SelectCommandEcho(input); // выделение команды /echo

                switch (input)  // разбор и выполнение команд
                {
                    case "/start":
                        {
                            name = CommandStart(name);
                        }
                        break;

                    case "/help":
                        {
                            CommandHelp(name);
                        }
                        break;

                    case "/info":
                        {
                            Console.WriteLine("Version and Date");
                        }
                        break;

                    case "/echo":
                        {
                            if (name != null)
                            {
                                Console.WriteLine($"Hi, {name}!");
                                Console.WriteLine($"{AfterEcho}");
                            }
                        }
                        break;
 
                    case "/addtask":
                        {
                            if (name != null)
                            {
                                CommandAddTask(ListTask);
                            }
                        }
                        break;

                    case "/showtasks":
                        {
                            if (name != null)
                            {
                                CommandShowTasks(ListTask);
                            }
                        }
                        break;

                    case "/removetask":
                        {
                            if (name != null)
                            {
                                CommandRemoveTask(ListTask);
                            }
                        }
                        break;

                    default:
                        {
                            Console.WriteLine("Command invalid");
                        }
                        break;
                  

                }

                input = Console.ReadLine(); // ожидание новой команды, возврат в while
            }

            Console.WriteLine("bay"); // завершение программы по /exit
        }

        // конец программы
    
        // функции исполнения команд
        static public string SelectCommandEcho(string input1)
        {

            string CommandEcho = input1.Substring(0, 5);

            if (CommandEcho == "/echo") return CommandEcho;
            else return input1;
        }

        static public string? CommandStart(string? names)
        {
            if (names == null)
            {
                Console.WriteLine("Whats your name?");
                names = Console.ReadLine();
                if (names == "") names = "Mister X";
                Console.WriteLine($"Hi, {names}!");
                return names;
            }
            else
            {
                Console.WriteLine($"Hi, {names}!");
                return names;
            }

        }   
       
        static public void CommandHelp(string? nameh)
        {
            if (nameh != null)
            {
                Console.WriteLine($"Hi, {nameh}!");
                Console.WriteLine("You may use next command: /start, /help, /info, /exit, /addtask, /showtasks, /removetask");
            }
            else
            {
                Console.WriteLine("Please, enter /start and than enter your name");
            }

        }
        static public void CommandAddTask(List<string> dela1)
        {
            Console.WriteLine("Please, enter your task:");
            string? delo;
            delo = Console.ReadLine();
            if(delo != null) dela1.Add(delo);
            Console.WriteLine("You add task:");
            Console.WriteLine($"{dela1.Count}. {delo}");
            
        }
       
        static public void CommandShowTasks(List<string> dela2)
        {
            if(dela2.Count> 0)
            {
                int i = 0;
                foreach (var onetask in dela2)
                {
                    Console.WriteLine($"{++i}. {onetask}");
                }
            }
            else
            {
                Console.WriteLine("List tasks is empty");
            }
        }
        
         static public void CommandRemoveTask(List<string> dela3)       // удаление задания
         {
            if(dela3.Count> 0)                                          // проверяем что список заданий не пустой
            {
                Console.WriteLine("Select task number for delete");    
                int j = 0;
                foreach (var onetask in dela3)                           // вывод списка заданий на экран
                {
                    Console.WriteLine($"{++j}. {onetask}");
                }
          
                string? NomerTask = Console.ReadLine();                  // ввод номера удаляемого задания 
                if (int.TryParse(NomerTask, out var x))                  
                {
                    if (x <= dela3.Count)                                // если номер существует, удаление задания из списка
                    {
                        string CurrentTask = dela3[x-1];
                        dela3.RemoveAt(x - 1);
                        Console.WriteLine($"Task {CurrentTask} delete");
                    }
                }
                else Console.WriteLine("No task with this number");     // вывод, если введенный номер задания не валидный


            }
            else
            {
                Console.WriteLine("List tasks is empty");              // вывод, если в списке нет ни одного заадания
            } 
         }
        


    }
}
