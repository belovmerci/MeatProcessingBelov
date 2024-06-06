using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class Рецептуры
{
    public int РецептураId { get; set; }

    public string? Название { get; set; }

    public string? Описание { get; set; }

    public virtual ICollection<Ассортименты> Ассортиментыs { get; set; } = new List<Ассортименты>();

    public virtual ICollection<ОборудованиеПоРецептурам> ОборудованиеПоРецептурамs { get; set; } = new List<ОборудованиеПоРецептурам>();

    public virtual ICollection<ПартииМясныхПродуктов> ПартииМясныхПродуктовs { get; set; } = new List<ПартииМясныхПродуктов>();

    public virtual ICollection<ТипыМясаПоРецептурам> ТипыМясаПоРецептурамs { get; set; } = new List<ТипыМясаПоРецептурам>();
}
