// BOL - Business Object Layer -- All Classes -- .cs Files
namespace BOL;

public class Employee
{
    public int EmpID;
    public string Fname;
    public string Lname;
    public string Gender;
    public string Dept;
    public int Salary;

    public Employee(){}
    public Employee(int EmpID,string Fname,string Lname,string Gender,string Dept,int Salary)
    {
        this.EmpID = EmpID;
        this.Fname = Fname;
        this.Lname = Lname;
        this.Gender = Gender;
        this.Dept = Dept;
        this.Salary = Salary;
    }
}