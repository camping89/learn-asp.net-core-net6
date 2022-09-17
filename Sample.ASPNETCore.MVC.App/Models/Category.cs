using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sample.ASPNETCore.MVC.App.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [DisplayName("Display Order")]
    [Range(1, 100, ErrorMessage = "100 is max")]
    public int DisplayOrder { get;         set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
}