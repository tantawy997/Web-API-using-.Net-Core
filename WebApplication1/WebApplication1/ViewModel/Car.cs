using System.ComponentModel.DataAnnotations;
using WebApplication1.Valdation;

namespace WebApplication1.ViewModel;

public class Car
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    [CreatedDateValdation]

    public DateTime CreatedDate { get; set; }


    public string Type { get; set; } = "Gaz";
}
