namespace BOL;

public class Timesheet
{
    public int id;
    public string? Date;
    public string? Work;
    public int Duration;
    public string? Status;

    public Timesheet()
    {

    }

     public Timesheet(int id, string Date, string Work, int Duration, string Status)
    {
        this.id=id;
        this.Date=Date;
        this.Work=Work;
        this.Duration=Duration;
        this.Status=Status;
    }

     public Timesheet(string Date, string Work, int Duration, string Status)
    {
        this.Date=Date;
        this.Work=Work;
        this.Duration=Duration;
        this.Status=Status;
    }
}