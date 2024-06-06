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

    public virtual ICollection<ЖурналОпераций> ЖурналОперацийs { get; set; } = new List<ЖурналОпераций>();

    public virtual Склады? СкладFkNavigation { get; set; }

    public virtual ТипыКорма? ТипКормаFkNavigation { get; set; }
}
