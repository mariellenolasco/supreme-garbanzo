// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
// this is used to check whether or not the end user wishes to exit out of the program
Boolean runAgain = true;
// Loop through the options at least once to present them to the end user, if the end user does not wish to exit, keep
// presenting this list of options
do
{
    // present menu to end user
    Console.WriteLine("Welcome to my restaurant reveiws app! The essential app for the amateur foodie");
    Console.WriteLine("[1] See that welcome message again");
    Console.WriteLine("[2] Add Restaurant");
    Console.WriteLine("[x] Exit");

    // get user input
    // create a string called userInput to store the value of the user's choice. We read the user's choice from the console 
    // using the readline method
    string userInput = Console.ReadLine();

    // using string interpolation we're able to present what the user chose
    Console.WriteLine($"You chose {userInput}");

    // using switch code block we define multiple paths of logic depending on the value of our user input
    switch (userInput)
    {
        case "1":
            Console.WriteLine("Hello World!");
            break;
        case "2":
            // lhs Restaurant defines the type of the variable 
            // lhs newRestaurant defines the name of the variable
            Restaurant newRestaurant = new Restaurant();
            //rhs new keyword refers to creating a new object and setting aside space for it in memory
            // rhs Restaurant() refers to the constructor of the Restaurant class

            //set restaurant properties
            newRestaurant.Name = "Balajadia's Eatery";
            newRestaurant.City = "Baguio City";
            newRestaurant.State = "Benguet";
            newRestaurant.Rating = 5;
            newRestaurant.Description = "Ilocano cuisine at it's finest. Fresh meat from the slaughterhouse next door";
            // print my new restaurant
            Console.WriteLine(newRestaurant);
            break;
        case "x":
            //exit out of program
            // set the runAgain value to false to exit out of the loop
            runAgain = false;
            Console.WriteLine("Goodbye Cruel World...");
            break;
        default:
            Console.WriteLine("Sorry your input was invalid, try again");
            break;
    }
} while (runAgain);


