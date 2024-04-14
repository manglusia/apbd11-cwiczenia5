namespace WebApp.Models;

public class Visit
{
    public string VisitDate { get; set; }
    public Pet VisPet { get; set; }
    public string VisitDescription { get; set; }
    public double VisitCost { get; set; }
    
}