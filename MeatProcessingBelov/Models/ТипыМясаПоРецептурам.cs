using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class ТипыМясаПоРецептурам
{
    public int ТмпрId { get; set; }

    public int? РецептураFk { get; set; }

    public int? ТипМясаFk { get; set; }

    public virtual Рецептуры? РецептураFkNavigation { get; set; }

    public virtual ТипыМяса? ТипМясаFkNavigation { get; set; }
}
