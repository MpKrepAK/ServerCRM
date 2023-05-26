﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRM_Server_Side.Models.Database.Entitys.Enums;

namespace CRM_Server_Side.Models.Database.Entitys;

public class Employee
{
    public long Id { get; set; }
    [MaxLength(100)]
    public string Email { get; set; }
    [MaxLength(20)]
    public string Password { get; set; }
    [MaxLength(20)]
    public string FirstName { get; set; }
    [MaxLength(20)]
    public string MidleName { get; set; }
    [MaxLength(20)]
    public string LastName { get; set; }
    public Genders Gender { get; set; }
    [MaxLength(14)]
    public string PassportIdentifier { get; set; }
    public decimal Salary { get; set; }
    [ForeignKey("Address")]
    public long AddressId { get; set; }
    public Address Address { get; set; }
    public EmployeeRoles Role { get; set; }
}