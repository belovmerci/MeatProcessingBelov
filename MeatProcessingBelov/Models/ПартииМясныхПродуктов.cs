using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class ПартииМясныхПродуктов
{
    public int ПмпId { get; set; }

    public DateTime? ДатаПроизводства { get; set; }

    public int? РецептураFk { get; set; }

}
