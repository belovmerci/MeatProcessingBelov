using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class Животные
{
    public int ЖивотноеId { get; set; }

    public string? Кличка { get; set; }

    public DateOnly? ДатаРождения { get; set; }

    public string? Пол { get; set; }

    public int? Количество { get; set; }

    public int? ЗагонFk { get; set; }

    public int? ТипЖивотногоFk { get; set; }

}
