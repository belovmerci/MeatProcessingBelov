using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class ПартииМясныхПродуктов
{
    public int ПмпId { get; set; }

    public DateTime? ДатаПроизводства { get; set; }

    public int? РецептураFk { get; set; }

    public virtual ICollection<ПартииПоМагазинам> ПартииПоМагазинамs { get; set; } = new List<ПартииПоМагазинам>();

    public virtual Рецептуры? РецептураFkNavigation { get; set; }
}
