// DAL -- Data Access Layer -- Database Connectivity
using MySql.Data.MySqlClient;
using BOL;
namespace DAL;

public static class DBManager
{
    public static void Insert(Employee emp)
    {
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = "server=127.0.0.1;port=3306;user=root;password=temp@9545;database=Neel";
        
        string query = "Insert into employee(EmpID,Fname,Lname,Gender,Dept,Salary)Values("+emp.EmpID+",'"+emp.Fname+"','"+emp.Lname+"','"+emp.Gender+"','"+emp.Dept+"',"+emp.Salary+")";
        
        MySqlCommand command = new MySqlCommand(query,connection);

        try
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connection.Close();
        }
    }

    public static List<Employee> Display()
    {
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = "server=127.0.0.1;port=3306;user=root;password=temp@9545;database=Neel";
        string query = "select * from employee";
        
        MySqlCommand command = new MySqlCommand(query,connection);

        try
        {
            connection.Open();
            MySqlDataReader reader=command.ExecuteReader();

            List<Employee> ls = new List<Employee>();

            while(reader.Read())
            {
                Employee emp = new Employee();

                emp.EmpID = int.Parse(reader["EmpID"].ToString());
                emp.Fname = reader["Fname"].ToString();
                emp.Lname = reader["Lname"].ToString();
                emp.Gender = reader["Gender"].ToString();
                emp.Dept = reader["Dept"].ToString();
                emp.Salary = int.Parse(reader["Salary"].ToString());

                ls.Add(emp);
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
            connection.Close();
        }
    }

    public static void Update(Employee emp)
    {
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = "server=127.0.0.1;port=3306;user=root;password=temp@9545;database=Neel";
        string query = "update employee set Fname='"+emp.Fname+"',Lname='"+emp.Lname+"',gender='"+emp.Gender+"',dept='"+emp.Dept+"',salary="+emp.Salary+"where empid="+emp.EmpID+"";
        
        MySqlCommand command = new MySqlCommand(query,connection);

        try
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connection.Close();
        }
    }

    public static void Delete(int EmpID)
    {
        MySqlConnection connection = new MySqlConnection();
        connection.ConnectionString = "server=127.0.0.1;port=3306;user=root;password=temp@9545;database=Neel";
        string query = "delete from employee where EmpID="+EmpID+"";
        
        MySqlCommand command = new MySqlCommand(query,connection);

        try
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connection.Close();
        }
    }
}