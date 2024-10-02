﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MeetingMinutes.Shared.Models;

public partial class MeetingItemModel
{
    [Key]
    public int MeetingItemId { get; set; }

    public int MeetingId { get; set; }

    public int ItemId { get; set; }

    public int ItemStatusId { get; set; }

    public string Comment { get; set; }

    public int? ActionBy { get; set; }
    public virtual UserModel ActionByNavigation { get; set; }

    public virtual ItemModel Item { get; set; }

    public virtual ItemStatusModel ItemStatus { get; set; }

    public virtual MeetingModel Meeting { get; set; }
}