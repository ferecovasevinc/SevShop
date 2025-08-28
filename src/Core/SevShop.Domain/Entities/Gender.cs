﻿namespace SevShop.Domain.Entities;

public class Gender : BaseEntity
{
    public string Name { get; set; } 
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
