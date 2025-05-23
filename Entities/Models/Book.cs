﻿using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Book
{
    [Key]
    public int Id { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public bool IsBanner { get; set; }=true;
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }

}
