// Program: Vehicle Inventory
// Programmer: Elvin Jackson
// Date Created: 09/12/2023
// Description: This program reads a text file containing inventory data about vehicles at a 
// used car lot. This program will then display the data for each vehicle on a single line and
// will calculate and display the total retail value for all vehicles. This program will also
// write the data for each vehicle to a text file.
class Program
{
    static void Main(string[] args)
    {
        //declare variables
        int number_of_vehicles = 0;
        string input_filename = "inventory.txt" , output_filename = "inventory output.txt";
        bool get_data_failed = false;

        SetConsoleColors();

        Vehicle[] vehicle_array = new Vehicle[1000];
        GetData(vehicle_array, input_filename, ref number_of_vehicles, ref get_data_failed);

        if (!get_data_failed)
        {
            DisplayOutput(vehicle_array, number_of_vehicles);
            DisplayOutputToFile(vehicle_array, output_filename, number_of_vehicles);
        }

    }

    //*******************************************************************************************************
    //DisplayOutputToFile
    //*******************************************************************************************************
    static void DisplayOutputToFile(Vehicle[] array, string filename, int number_of_vehicles)
    {
        StreamWriter outfile = new StreamWriter(filename);

        string format_string = " {0, -10} {1, -30} {2, -5} {3, 14} {4, 14:C0}";

        //display header
        outfile.WriteLine(format_string, "Make", "Model", "Year", "Mileage", "Price");
        outfile.WriteLine(" ----------------------------------------------------------------------------------");

        //display vehicle data
        for (int c = 0; c < number_of_vehicles; c++)
        {
            outfile.WriteLine(format_string, array[c].Make, array[c].Model, array[c].Year, array[c].Mileage, array[c].Price);
        }
        outfile.WriteLine();

        //Calculate and display the toal reail value of all vehicles
        decimal total_retail_value = 0m;
        for (int c = 0; c < number_of_vehicles; c++)
        {
            total_retail_value += array[c].Price;
        }
        outfile.WriteLine($"\nTotal retail value: {total_retail_value.ToString("C0")}");
        outfile.Close();

    }

    //*******************************************************************************************************
    //DisplayOutput
    //*******************************************************************************************************
    static void DisplayOutput(Vehicle[] array, int number_of_vehicles)
    {
        string format_string = " {0, -10} {1, -30} {2, -5} {3, 14} {4, 14:C0}";

        //display header
        Console.WriteLine(format_string, "Make", "Model", "Year", "Mileage", "Price");
        Console.WriteLine(" ----------------------------------------------------------------------------------");

        //display vehicle data
        for (int c = 0; c < number_of_vehicles; c++)
        {
            Console.WriteLine(format_string, array[c].Make, array[c].Model, array[c].Year, array[c].Mileage, array[c].Price);
        }
        Console.WriteLine();

        //Calculate and display the toal reail value of all vehicles
        decimal total_retail_value = 0m;
        for(int c = 0; c < number_of_vehicles; c++)
        {
            total_retail_value += array[c].Price;
        }
        Console.WriteLine($"\nTotal retail value: {total_retail_value.ToString("C0")}");

    }

    //*******************************************************************************************************
    //SetConsoleColors
    //*******************************************************************************************************
    static void SetConsoleColors()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Black;
    }

    //*******************************************************************************************************
    //GetData
    //*******************************************************************************************************
    static void GetData(Vehicle[] array, string filename, ref int number_of_vehicles, ref bool get_data_failed)
    {
        // declare variables
        string make, model, year, line = "";
        long mileage;
        decimal price;

        try
        {
            StreamReader infile = new StreamReader(filename);

            while (line != null)
            {
                make = infile.ReadLine()!;
                model = infile.ReadLine()!;
                year = infile.ReadLine()!;
                mileage = Convert.ToInt64(infile.ReadLine()!);
                price = Convert.ToDecimal(infile.ReadLine()!);
                line = infile.ReadLine()!; //read blank line

                Vehicle new_vehicle = new Vehicle(make, model, year, mileage, price);
                array[number_of_vehicles] = new_vehicle;
                number_of_vehicles++;
            }
            infile.Close();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            get_data_failed = true;
        } 
    }
}
