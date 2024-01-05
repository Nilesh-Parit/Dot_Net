using BOL;
using MySql.Data.MySqlClient;
using ZstdSharp.Unsafe;

namespace DAL;

public static class DBManager
{
    public static void Insert(Timesheet ts)
    {
        MySqlConnection conn = new MySqlConnection();

        conn.ConnectionString = "server=192.168.10.150;port=3306;user=dac3;password=welcome;database=dac3";

        string query = "Insert into timesheet(date,work,duration,status)values('"+ts.Date+"','"+ts.Work+"',"+ts.Duration+",'"+ts.Status+"')";

        MySqlCommand cmd = new MySqlCommand(query,conn);

        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            conn.Close();
        }
    }

     public static List<Timesheet> Display()
    {
        MySqlConnection conn = new MySqlConnection();

        conn.ConnectionString = "server=192.168.10.150;port=3306;user=dac3;password=welcome;database=dac3";

        string query = "Table Timesheet";

        MySqlCommand cmd = new MySqlCommand(query,conn);
        List<Timesheet> ls = new List<Timesheet>();

        try
        {
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Timesheet ts = new Timesheet();
                ts.id = int.Parse(reader["id"].ToString());
                ts.Date = reader["Date"].ToString();
                ts.Work = reader["Work"].ToString();
                ts.Duration = int.Parse(reader["Duration"].ToString());
                ts.Status = reader["Status"].ToString();

                ls.Add(ts);
            }

            return ls;
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
        finally
        {
            conn.Close();
        }
    }

    public static void Update(Timesheet ts)
    {
        MySqlConnection conn = new MySqlConnection();

        conn.ConnectionString = "server=192.168.10.150;port=3306;user=dac3;password=welcome;database=dac3";

        string query = "Update timesheet set date='"+ts.Date+"',work='"+ts.Work+"',duration="+ts.Duration+",status='"+ts.Status+"' Where id="+ts.id;
        
        MySqlCommand cmd = new MySqlCommand(query,conn);

        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            conn.Close();
        }
    }
}