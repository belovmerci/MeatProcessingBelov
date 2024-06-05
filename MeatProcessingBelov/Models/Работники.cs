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

    public virtual ICollection<РаботникиМагазинов> РаботникиМагазиновs { get; set; } = new List<РаботникиМагазинов>();

    public virtual ICollection<РаботникиПоТипам> РаботникиПоТипамs { get; set; } = new List<РаботникиПоТипам>();

    public virtual ICollection<Смены> Сменыs { get; set; } = new List<Смены>();
}
