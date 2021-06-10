using System;
using System.Text;
using System.Threading;
using CustomerPortal.Services;
using PortalLibrary.Models;

namespace CustomerPortal.Menu
{
    public class AuthenticationHandler : AuthenticationService
    {
        internal static void RegistrationForm()
        {
            string[] requiredRegistrationInformation = new string[]{"First Name", "Last Name", "Phone Number", "Email Address", "Password"};
            string[] providedRegistrationInformation = new string[]{"First Name", "Last Name", "Phone Number", "Email Address", "Password"};
            Random idGen = new Random();

            for (int i = 0; i < requiredRegistrationInformation.Length; i++)
            {
                var value = "";
                var validatedValue = "";
                Console.Write($"\n> Enter your {requiredRegistrationInformation[i]} : ");

                if (requiredRegistrationInformation[i] == "Password")
                {
                    value = GetConsolePassword();
                    validatedValue = ValidateUserInput(value, requiredRegistrationInformation[i]);
                }
                else
                {
                    value = Console.ReadLine().Trim();
                    validatedValue = ValidateUserInput(value, requiredRegistrationInformation[i]);
                }
                
                providedRegistrationInformation[i] = validatedValue;
            }

            while(providedRegistrationInformation[4].Length < 11 || !ulong.TryParse(providedRegistrationInformation[4],out ulong result))
            {
                Console.Write("\n> Please enter an 11 digit number\n");
                Console.Write("> Phone Number : ");
                providedRegistrationInformation[2] = Console.ReadLine().Trim();
            }

            Customer model = new Customer
            {
                FirstName = providedRegistrationInformation[0],
                LastName = providedRegistrationInformation[1],
                PhoneNumber = providedRegistrationInformation[2],
                EmailAddress = providedRegistrationInformation[3],
                Password = providedRegistrationInformation[4],
                Id = "CUS-" + idGen.Next(125000, 525999).ToString(),
                MeterNumber = "MTN-" + idGen.Next(21000, 124000).ToString(),
            };

            string registrationResponse = RegisterUser(model);
            if (registrationResponse == "success")
            {
                Console.Clear();
                Console.WriteLine($"> Registration Successful! \n\nRegistered Details: \n\nCustomer ID : {model.Id} \n\nName : {model.FirstName} {model.LastName} \n\nPhone Number : {model.PhoneNumber} \n\nEmail : {model.EmailAddress} \n\nMeter Number : {model.MeterNumber} \n\nPress any key to go to dashboard.");
                Console.ReadKey();
                NavigationMenu.inRegisterPage = false;
                NavigationMenu.inCustomerDashboard = true;
            }
            else
            {
                Console.WriteLine("> Email already exist. Please Sign-In. \n\nPress any key to go back to menu");
                Console.ReadKey();
                NavigationMenu.inRegisterPage = false;
            }
        }


        internal static void LoginForm()
        {
            string[] requiredLoginInformation = new string[]{ "Email", "Password" };
            string[] providedLoginInformation = new string[]{ "Email", "Password" };
            bool isLoggedIn = false;
            
            while(!isLoggedIn)
            {
                Console.Clear();
                Console.WriteLine("Please Login with your Email and Password");

                for (var i = 0; i < requiredLoginInformation.Length; i++)
                {
                    Console.Write($"\n> Please Enter your {requiredLoginInformation[i]} : ");
                    var value = "";
                    var validatedValue = "";

                    if (requiredLoginInformation[i] == "Password")
                    {
                        value = GetConsolePassword();
                        validatedValue = ValidateUserInput(value, requiredLoginInformation[i]);
                    }
                    else
                    {
                        value = Console.ReadLine().Trim();
                        validatedValue = ValidateUserInput(value, requiredLoginInformation[i]);
                    }

                    providedLoginInformation[i] = validatedValue;
                }

                string email, password;
                email = providedLoginInformation[0];
                password = providedLoginInformation[1];

                var customer = LoginUser(email,password);
                if (customer == null)
                {
                    Console.WriteLine("Invalid Login Credentials.");
                    Thread.Sleep(1500);
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Successfully Signed In. \n\n> Redirecting to dashboard...");
                    Thread.Sleep(1500);
                    isLoggedIn = true;
                }
            }

            if (isLoggedIn == true)
            {
                NavigationMenu.inLoginPage = false;
                NavigationMenu.inCustomerDashboard = true;
            }
            else
            {
                NavigationMenu.inLoginPage = false;
            }
        }


        private static string ValidateUserInput(string value, string fieldName)
        {
            while (value == "")
            {
                Console.WriteLine($"The {fieldName} field cannot be empty");
                value = Console.ReadLine();
            }

            return value;
        }

        public static string GetConsolePassword( )
        {
            StringBuilder sb = new StringBuilder( );
            while ( true )
            {
                ConsoleKeyInfo cki = Console.ReadKey( true );
                if ( cki.Key == ConsoleKey.Enter )
                {
                    Console.WriteLine( );
                    break;
                }

                if ( cki.Key == ConsoleKey.Backspace )
                {
                    if ( sb.Length > 0 )
                    {
                        Console.Write( "\b\0\b" );
                        sb.Length--;
                    }

                    continue;
                }

                Console.Write( '*' );
                sb.Append( cki.KeyChar );
            }

            return sb.ToString( );
        }
    }
}