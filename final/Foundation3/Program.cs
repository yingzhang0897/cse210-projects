//this program uses a base class: Event and three derived classes: Lecture, Reception and OutdoorGathering to show Inheritance
// three derived classes inherit 3 methods from the base class and override 2 of them to display their unique Event details
using System;

// Address class to represent event addresses
public class Address
{
    private string _streetAddress;
    private string _city;
    private string _state;
    private string _country;

    public Address(string streetAddress, string city, string state, string country)
    {
        _streetAddress= streetAddress;
        _city = city;
        _state = state;
        _country = country;
    }

    public string GetFullAddress()//will be encapsulated in Event class
    {
        return $"{_streetAddress}, {_city}, {_state}, {_country}";
    }
}

// Base Event class
public class Event
{
    protected string _title;
    protected string _description;
    protected DateTime _dateTime;
    protected Address _address;

    public Event(string title, string description, DateTime dateTime, Address address)
    {
        _title = title;
        _description = description;
        _dateTime = dateTime;
        _address = address;
    }

    public virtual string GetStandardDetails()
    {
        return $"Event: {_title}\nDescription: {_description}\nDate: {_dateTime.ToShortDateString()}\nTime: {_dateTime.ToShortTimeString()}\nAddress: {_address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()//plus type of event and information specific to that event type.
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"Type: Generic Event\nTitle: {_title}\nDate: {_dateTime.ToShortDateString()}";
    }
}

// Derived Lecture class
public class Lecture : Event
{
    private string _speaker;
    private int _capacity;

    public Lecture(string title, string description, DateTime dateTime, Address address, string speaker, int capacity)
        : base(title, description, dateTime, address)
    {
        _speaker = speaker;
        _capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nType: Lecture\nSpeaker: {_speaker}\nCapacity: {_capacity}";
    }

    public override string GetShortDescription()
    {
        return $"Type: Lecture\nTitle: {_title}\nDate: {_dateTime.ToShortDateString()}";
    }
}

// Derived Reception class
public class Reception : Event
{
    private string _rsvpEmail;

    public Reception(string title, string description, DateTime dateTime, Address address, string rsvpEmail)
        : base(title, description, dateTime, address)
    {
        _rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nType: Reception\nRSVP Email: {_rsvpEmail}";
    }

    public override string GetShortDescription()
    {
        return $"Type: Reception\nTitle: {_title}\nDate: {_dateTime.ToShortDateString()}";
    }
}

// Derived OutdoorGathering class
public class OutdoorGathering : Event
{
    private string _weatherForecast;

    public OutdoorGathering(string title, string description, DateTime dateTime, Address address, string weatherForecast)
        : base(title, description, dateTime, address)
    {
        _weatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nType: Outdoor Gathering\nWeather Forecast: {_weatherForecast}";
    }

    public override string GetShortDescription()
    {
        return $"Type: Outdoor Gathering\nTitle: {_title}\nDate: {_dateTime.ToShortDateString()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating instances of Address for different types of events
        Address lectureAddress = new Address("123 Main St", "Anytown", "NY", "USA");
        Address receptionAddress = new Address("456 Elm St", "Othertown", "CA", "Canada");
        Address outdoorGatheringAddress = new Address("789 Oak St", "Sometown", "FL", "USA");

        //Create a list<Event> and add different types of events 
        List<Event> events = new List<Event>
        {
            new Lecture("Tech Talk", "Learn about new technologies", new DateTime(2024, 2, 15, 10, 0, 0), lectureAddress, "John Smith", 50),
            new Reception("Networking Mixer", "Meet professionals from various industries", new DateTime(2024, 3, 20, 18, 0, 0), receptionAddress, "rsvp@example.com"),
            new OutdoorGathering("Summer Picnic", "Enjoy food and games outdoors", new DateTime(2024, 6, 30, 12, 0, 0), outdoorGatheringAddress, "Sunny")
        };

        //use a foreach loop to apply polymorphism to display marketing info of each type of event
        foreach (Event e in events)
        {
            Console.WriteLine(e);
            Console.WriteLine();
            Console.WriteLine("Display standard information: ");
            Console.WriteLine(e.GetStandardDetails());

            Console.WriteLine();
            Console.WriteLine("Display full information about this event: ");
            Console.WriteLine(e.GetFullDetails());

            Console.WriteLine();
            Console.WriteLine("A short Description about this event: ");
            Console.WriteLine(e.GetShortDescription());  
            Console.WriteLine(); 
        }
    }
}
