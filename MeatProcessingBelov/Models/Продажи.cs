using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class Продажи
{
    public int ПродажаId { get; set; }

    public int? Количество { get; set; }

    public int? МагазинFk { get; set; }

    public int? АссортиментFk { get; set; }

    public virtual Ассортименты? АссортиментFkNavigation { get; set; }

    public virtual Магазины? МагазинFkNavigation { get; set; }
}
