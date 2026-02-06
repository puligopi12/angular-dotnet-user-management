using System.ComponentModel.DataAnnotations;
namespace EntityFrameWorkCoreFirstApp.Models
{
    public class Users
    {
           [Key]
           public int ID { get; set; }
           
           public string Name { get; set; }

           public string Contact { get; set; }
    }
}
