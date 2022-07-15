class Restaurant
{
    // 3 parts of a class (in general)
    // Properties
    // In C# properties are separate from fields
    // fields hold value
    // properties provide a way to add logic in getting
    // or setting the field value
    // properties are the c# equivalent of a getter and 
    // setter in java
    // You don't have to define backing field for properties
    // if you don't require any special logic to access 
    // or set their value, you can just declare a property
    // and the compiler generates a backing field (aka variable
    // that holds actual data) for you
    // Methods
    // Constructors

    public string Name { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int Rating { get; set; }
    public string Description { get; set; }

    // parameterized constructor for setting up initial values
    public Restaurant(string name, string city, string state, int rating, string description)
    {
        this.Name = name;
        this.City = city;
        this.State = state;
        this.Rating = rating;
        this.Description = description;
    }
    public Restaurant()
    {

    }
    public override string ToString()
    {
        return $"Name: {this.Name} \nAddress: {this.City}, {this.State} \nRating: {this.Rating} / 5 \n{this.Description}";
    }
}