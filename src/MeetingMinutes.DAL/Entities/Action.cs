﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MeetingMinutes.DAL.Entities;

[Table("Action")]
public partial class Action
{
    [Key]
    public int ActionId { get; set; }

    public bool IsDone { get; set; }

    [Required]
    [StringLength(500)]
    [Unicode(false)]
    public string Todo { get; set; }
}