using System;
using System.Data.SQLite;
using System.IO;

public class DatabaseSetup
{
    private SQLiteConnection sqlite_conn;

    public void CreateDatabase()
    {
        // Get the path to the user's application data folder
        string appDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        // Create a subdirectory for your application
        string appFolder = Path.Combine(appDataDirectory, "InvoiceApplication");
         
        // Ensure the directory exists
        if (!Directory.Exists(appFolder))
        {
            Directory.CreateDirectory(appFolder);
        }

        // Combine the app folder with the database file name
        string dbPath = Path.Combine(appFolder, "invoice.db");

        // Establish the SQLite connection
        sqlite_conn = new SQLiteConnection($"Data Source={dbPath};Version=3;");
        sqlite_conn.Open();

        // SQL to create the Invoices table if it doesn't exist
        string createTableQuery = @"CREATE TABLE IF NOT EXISTS Invoices (
                                    CustomerID TEXT,
                                    CustomerName TEXT,
                                    InvoiceID INTEGER PRIMARY KEY AUTOINCREMENT,
                                    TotalAmount REAL,
                                    TotalPrice REAL,
                                    Discount REAL,
                                    Date TEXT,
                                    Time TEXT,
                                    PlateNumber TEXT,
                                    PaymentType TEXT
                                    );";

        // Execute the SQL command
        SQLiteCommand createTableCmd = new SQLiteCommand(createTableQuery, sqlite_conn);
        createTableCmd.ExecuteNonQuery();

        // Close the connection
        sqlite_conn.Close();
    }

    public SQLiteConnection GetConnection()
    {
        string appDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string appFolder = Path.Combine(appDataDirectory, "InvoiceApplication");
        string dbPath = Path.Combine(appFolder, "invoice.db");

        return new SQLiteConnection($"Data Source={dbPath};Version=3;");
    }
}
