﻿
using Model;
namespace Repositories;
public class CustomerEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public CustomerLevel Level { get; set; }
}

