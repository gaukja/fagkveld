using System.ComponentModel.DataAnnotations;

namespace Application.Admin;
public record SecretInfoDto
{
    [Required]
    public required string Name { get; set; }
}
