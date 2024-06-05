using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class ПартииПоМагазинам
{
    public int ПпмId { get; set; }

    public DateTime? ДатаОтправки { get; set; }

    public DateTime? ДатаПолучения { get; set; }

    public int? ПартияFk { get; set; }

    public int? МагазинFk { get; set; }

    public virtual Магазины? МагазинFkNavigation { get; set; }

    public virtual ПартииМясныхПродуктов? ПартияFkNavigation { get; set; }
}
