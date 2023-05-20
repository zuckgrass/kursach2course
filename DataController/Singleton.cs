using System;

class DatabaseConnection
{
    // Private static instance of the class
    private static DatabaseConnection instance;

    // Private constructor to prevent instantiation from outside the class
    private DatabaseConnection()
    {
        // Perform necessary initialization
    }

    // Public static method to get the instance of the class
    public static DatabaseConnection GetInstance()
    {
        // Create a new instance if it doesn't exist
        if (instance == null)
        {
            instance = new DatabaseConnection();
        }

        return instance;
    }

    // Other methods and properties of the class
    public void Connect()
    {
        Console.WriteLine("Connecting to the database...");
    }

    public void Disconnect()
    {
        Console.WriteLine("Disconnecting from the database...");
    }

}


