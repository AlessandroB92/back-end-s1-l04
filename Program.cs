namespace back_end_s1_l04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool loggedIn = false;

            while (true)
            {
                Console.WriteLine("===============OPERAZIONI==============");
                Console.WriteLine("Scegli l'operazione da effettuare:");
                Console.WriteLine("1.: Login");
                Console.WriteLine("2.: Logout");
                Console.WriteLine("3.: Verifica ora e data di login");
                Console.WriteLine("4.: Lista degli accessi");
                Console.WriteLine("5.: Esci");
                Console.WriteLine("========================================");

                Console.Write("Scelta: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if (!loggedIn)
                        {
                            Console.Write("Username: ");
                            string username = Console.ReadLine();
                            Console.Write("Password: ");
                            string password = Console.ReadLine();
                            Console.Write("Conferma Password: ");
                            string confirmPassword = Console.ReadLine();
                            

                            if (Utente.Login(username, password, confirmPassword))
                            {
                                Console.Clear();
                                Console.WriteLine("Login avvenuto con successo.");
                                loggedIn = true;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Errore: Username o password errati.");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Errore: L'utente è già loggato.");
                        }                        
                        break;
                    case "2":
                        if (loggedIn)
                        {
                            Console.Clear();
                            Utente.Logout();
                            loggedIn = false;
                            Console.WriteLine("Logout avvenuto con successo.");
                            
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Errore: Nessun utente loggato.");
                            
                        }
                        break;
                    case "3":
                        if (loggedIn)
                        {
                            Console.Clear();
                            Console.WriteLine($"Ultimo accesso: {Utente.GetLastLoginDateTime()}");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Errore: Nessun utente loggato.");
                        }
                        break;
                    case "4":
                        if (loggedIn)
                        {
                            List<DateTime> accessi = Utente.GetAccessi();
                            if (accessi.Count > 0)
                            {
                                Console.Clear();
                                Console.WriteLine("Accessi precedenti:");
                                foreach (DateTime accesso in accessi)
                                {
                                    Console.WriteLine(accesso);
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Nessun accesso precedente.");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Errore: Nessun utente loggato.");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Arrivederci!");
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Scelta non valida.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }

    static class Utente
    {
        private static string username;
        private static string password;
        private static List<DateTime> accessi = new List<DateTime>();

        public static bool Login(string usr, string pwd, string confirmPwd)
        {
            if (usr != "" && pwd == confirmPwd)
            {
                username = usr;
                password = pwd;
                accessi.Add(DateTime.Now);
                return true;
            }
            return false;
        }

        public static void Logout()
        {
            username = null;
            password = null;
        }

        public static DateTime GetLastLoginDateTime()
        {
            return accessi.Count > 0 ? accessi[accessi.Count - 1] : DateTime.MinValue;
        }

        public static List<DateTime> GetAccessi()
        {
            return accessi;
        }
    }
}
