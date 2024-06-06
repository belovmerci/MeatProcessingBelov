using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class Склады
{
    public int СкладId { get; set; }

    public string? Название { get; set; }

    public string? Локация { get; set; }

    public virtual ICollection<Корма> Кормаs { get; set; } = new List<Корма>();
}
