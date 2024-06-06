using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class ТипыКорма
{
    public int ТипКормаId { get; set; }

    public string? Название { get; set; }

    public virtual ICollection<Корма> Кормаs { get; set; } = new List<Корма>();
}
