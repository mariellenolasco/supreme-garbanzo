using Microsoft.Data.SqlClient;
/// <summary>
/// Class for interacting with our data source (aka the restaurant DB)
/// </summary>
class DataAccess
{
    // Connection string is used to hold all the info we need to locate and connect to our DB (that's somewhere on the internet)
    private static string connectionString = DBCreds.connectionString;
    /// <summary>
    /// Method that adds a restaurant to the DB. Takes in a restaurant object that contains the new data we need to 
    /// insert to the restaurant table
    /// </summary>
    /// <param name="newRestaurant"></param>
    public static void AddRestaurant(Restaurant newRestaurant)
    {
        /// <summary>
        /// This contains the query we want to execute on the DB
        /// </summary>
        /// <param name="('{newRestaurant.Name}'"></param>
        /// <returns></returns>
        string queryString = $"insert into restaurant (name, city, state, rating, description) values ('{newRestaurant.Name}', '{newRestaurant.City}', '{newRestaurant.State}', {newRestaurant.Rating}, '{newRestaurant.Description}')";

        // Using block meant to dispose of the SQLConnection when the code finishes executing within the block
        // Good for resource management and clean up 
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            // represent a statement to execute against a db
            // composed of the query you want to execute in the form of the query string and the connection to the Db
            // made possible by the connection string
            SqlCommand cmd = new SqlCommand(queryString, conn);
            try
            {
                //this opens up a connection using DB properties in the connection string
                // means that the connection is "live"
                // we now have a portal/access to the DB 
                conn.Open();

                // actual execution of the query against DB 
                // execute non query is for executing insert, update, delete commands that don't return records but instead
                // returns number of rows affected
                cmd.ExecuteNonQuery();
                Console.WriteLine("Saved");
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
    /// <summary>
    /// Method for getting all restaurants stored in DB
    /// </summary>
    /// <returns></returns>
    public static List<Restaurant> GetRestaurants()
    {
        /// <summary>
        /// This is going to hold the data we'll be getting from the DB
        /// </summary>
        /// <typeparam name="Restaurant"></typeparam>
        /// <returns></returns>
        List<Restaurant> allRestaurants = new List<Restaurant>();
        string queryString = "select * from restaurant";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(queryString, conn);
            try
            {
                conn.Open();
                // this reads a stream of rows from the sql server db
                // this holds the raw data from the DB 
                SqlDataReader reader = cmd.ExecuteReader();
                // we unpack what we get from the DB
                while (reader.Read())
                {
                    // each record we're mapping to a restaurant object and adding it to our restaurants that we want to return
                    allRestaurants.Add(
                        new Restaurant( // reader[0] represents the ID column and we're not mapping that currently 
                            reader[1].ToString(), // map the name column to the name property 
                            reader[2].ToString(), // map the city column to the city property
                            reader[3].ToString(), // map the state column to the state property
                            int.Parse(reader[5].ToString()), // map the rating column to rating property
                            reader[4].ToString()) // map the description column to description property 
                                                  // note that the rating column is on index 5 while the description column is on index 4 because when
                                                  // we built the table in the db, we declared the description column before the rating column
                    );
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        // return all restaurants you've parsed and mapped. 
        return allRestaurants;
    }
}