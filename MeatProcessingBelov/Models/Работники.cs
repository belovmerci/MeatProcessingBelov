using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class Работники
{
    public int РаботникId { get; set; }

    public string Имя { get; set; } = null!;

    public string Фамилия { get; set; } = null!;

    public string? Отчество { get; set; }

    public DateOnly? ДатаРождения { get; set; }

    public string? Пол { get; set; }

    public string? СерияНомерПаспорта { get; set; }

}
