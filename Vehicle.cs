class Vehicle
{
    private string _make;
    private string _model;
    private string _year;
    private long _mileage;
    private decimal _price;

    // default constructor
    public Vehicle()
    {
        _make = "";
        _model = "";
        _year = "";
        _mileage = 0;
        _price = 0m;
    }

    // full constructor
    public Vehicle(string make, string model, string year, long mileage, decimal price)
    {
        _make = make;
        _model = model;
        _year = year;
        _mileage = mileage;
        _price = price;
    }

    public string Make { get { return _make; } set { _make = value; } }
    public string Model { get { return _model; } set { _model = value; } }
    public string Year { get { return _year; } set { _year = value; } }
    public long Mileage { get { return _mileage; } set { _mileage = value; } }
    public decimal Price { get { return _price; } set { _price = value; } }
   
}

