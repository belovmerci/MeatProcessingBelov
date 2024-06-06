using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class ОборудованиеПоРецептурам
{
    public int ОпрId { get; set; }

    public int? РецептураFk { get; set; }

    public int? ОборудованиеFk { get; set; }

    public virtual Оборудование? ОборудованиеFkNavigation { get; set; }

    public virtual Рецептуры? РецептураFkNavigation { get; set; }
}
