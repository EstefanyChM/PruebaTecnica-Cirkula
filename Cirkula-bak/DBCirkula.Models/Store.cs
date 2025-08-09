using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBCirkula.Models;

[Table("Store")]
public partial class Store
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(255)]
    public string? BannerUrl { get; set; }

    [Column(TypeName = "decimal(9, 6)")]
    public decimal Latitude { get; set; }

    [Column(TypeName = "decimal(9, 6)")]
    public decimal Longitude { get; set; }

    public TimeOnly OpenTime { get; set; }

    public TimeOnly CloseTime { get; set; }
}
