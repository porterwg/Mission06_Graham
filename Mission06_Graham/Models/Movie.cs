using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Mission06_Graham.Models;
//This model connects the form to the database. Prof Hilton helped me make sure everything here is right
//There is a foreign key CategoryId that connects this table to the categories table
//Instructions say only title, year, edited, and copied to plex are required, which is why everything else has a '?'
//also movieId is always required but hidden
public class Movie
{
    [Key] [Required] 
    public int MovieId{ get; set; }
    
     [ForeignKey("CategoryId")] 
     public int? CategoryId { get; set; }
     public Category? Category { get; set; }
     
    public string Title { get; set; }
    
    [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or more recent")]
    public int Year { get; set; }
    
    public string? Director { get; set; }
    public string? Rating { get; set; }
    
    public bool Edited { get; set; } = false;
    
    public string? LentTo { get; set; }
    
    public bool CopiedToPlex { get; set; } = false;
    
    [StringLength(25, ErrorMessage = "Notes cannot be more than 25 characters.")] 
    public string? Notes { get; set; }

}