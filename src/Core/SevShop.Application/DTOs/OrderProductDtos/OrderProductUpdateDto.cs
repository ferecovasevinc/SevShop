﻿namespace SevShop.Application.DTOs.OrderProductDtos;

public class OrderProductUpdateDto
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
