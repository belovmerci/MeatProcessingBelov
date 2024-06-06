using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class Магазины
{
    public int МагазинId { get; set; }

    public string? Название { get; set; }

    public string? Город { get; set; }

    public string? Адрес { get; set; }

    public string? Телефон { get; set; }

    public string? Email { get; set; }

    public bool Активный { get; set; }

    public virtual ICollection<Ассортименты> Ассортиментыs { get; set; } = new List<Ассортименты>();

    public virtual ICollection<ПартииПоМагазинам> ПартииПоМагазинамs { get; set; } = new List<ПартииПоМагазинам>();

    public virtual ICollection<Продажи> Продажиs { get; set; } = new List<Продажи>();

    public virtual ICollection<РаботникиМагазинов> РаботникиМагазиновs { get; set; } = new List<РаботникиМагазинов>();
}
