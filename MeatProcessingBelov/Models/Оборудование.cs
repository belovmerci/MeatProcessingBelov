using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class Оборудование
{
    public int ОборудованиеId { get; set; }

    public string Название { get; set; } = null!;

    public string? Модель { get; set; }

    public int? ГодПроизводства { get; set; }

    public bool Активный { get; set; }

    public virtual ICollection<ЖурналОпераций> ЖурналОперацийs { get; set; } = new List<ЖурналОпераций>();

    public virtual ICollection<ОборудованиеПоРецептурам> ОборудованиеПоРецептурамs { get; set; } = new List<ОборудованиеПоРецептурам>();
}
