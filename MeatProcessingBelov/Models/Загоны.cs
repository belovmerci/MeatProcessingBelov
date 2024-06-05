using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class Загоны
{
    public int ЗагонId { get; set; }

    public string? Название { get; set; }

    public string? Описание { get; set; }

    public virtual ICollection<Животные>? Животныеs { get; set; } = new List<Животные>();
}
