﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LetsPollPeople.DAL.Entities;

public partial class UserVote
{
    [Key]
    public int UserVoteId { get; set; }

    public int UserId { get; set; }

    public int QuestionId { get; set; }

    public int OptionId { get; set; }

    [ForeignKey("OptionId")]
    [InverseProperty("UserVote")]
    public virtual Option Option { get; set; }

    [ForeignKey("QuestionId")]
    [InverseProperty("UserVote")]
    public virtual Question Question { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("UserVote")]
    public virtual User User { get; set; }
}