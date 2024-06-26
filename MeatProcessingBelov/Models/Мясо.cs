﻿using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class Мясо
{
    public int МясоId { get; set; }

    public DateTime? ДатаВыработки { get; set; }

    public decimal? КгМяса { get; set; }

    public int? РефрижераторFk { get; set; }

    public int? ТипМясаFk { get; set; }

    public int? ЗабойFk { get; set; }

    public virtual Забои? ЗабойFkNavigation { get; set; }

    public virtual Рефрижераторы? РефрижераторFkNavigation { get; set; }

    public virtual ТипыМяса? ТипМясаFkNavigation { get; set; }
}
