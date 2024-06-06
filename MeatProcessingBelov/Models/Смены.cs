using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class Смены
{
    public int СменаId { get; set; }

    public DateTime? Начало { get; set; }

    public DateTime? Конец { get; set; }

    public int? РаботникFk { get; set; }

}
