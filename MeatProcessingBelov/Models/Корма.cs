using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class Корма
{
    public int КормId { get; set; }

    public string? Описание { get; set; }

    public decimal? КоличествоКг { get; set; }

    public int? ТипКормаFk { get; set; }

    public int? СкладFk { get; set; }

}
