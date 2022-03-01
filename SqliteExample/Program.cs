using Microsoft.Data.Sqlite;
using SqliteExample;

var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();


using (var connection = new SqliteConnection($@"Data Source={path}{Path.DirectorySeparatorChar}mydatabase.db"))
{
    connection.Open();

    
    var command = connection.CreateCommand();

    command.CommandText = "select * from User";

    var data = command.ExecuteReader();

    Console.WriteLine(data.FieldCount);

    var users = new List<User>();

    while (data.Read())
    {
        var dict = new Dictionary<string, object>();

        for (int i = 0; i < data.FieldCount; i++)
        {

            dict.Add(data.GetName(i), data.GetValue(i));
        }

        users.Add(new User((long)(dict["Id"]), (string)dict["Name"]));
  
       
    }

    foreach (var item in users)
    {
        Console.WriteLine(item.Name);
    }

    

    /*for (int i = 0; i < 50; i++)
    {
        command.CommandText = "INSERT INTO User (Name) VALUES ('Cory')";

        command.ExecuteNonQuery();
    }*/
    

    //command.Parameters.AddWithValue("$id", id);

   /* using (var reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            var name = reader.GetString(0);

            Console.WriteLine($"Hello, {name}!");
        }
    }*/
}