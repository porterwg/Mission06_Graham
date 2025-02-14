using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Mission06_Graham.Models;

public class Movie
{
    [Key] [Required] public int MovieID{ get; set; }
     public string Category { get; set; }
    public string Title { get; set; }
    public string Year { get; set; }
    public string Director { get; set; }
    public string Rating { get; set; }
    public bool? Edited { get; set; }
    public string? LentTo { get; set; }
    [StringLength(25, ErrorMessage = "Notes cannot be more than 25 characters.")] public string? Notes { get; set; }

}