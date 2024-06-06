using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class ТипыРаботников
{
    public int ТрId { get; set; }

    public string? Название { get; set; }

    public string? Описание { get; set; }

    public virtual ICollection<РаботникиПоТипам> РаботникиПоТипамs { get; set; } = new List<РаботникиПоТипам>();
}
