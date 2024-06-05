using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class ЖурналОпераций
{
    public int ЖоId { get; set; }

    public int? КормFk { get; set; }

    public TimeOnly? ВремяПроведения { get; set; }

    public int? ОборудованиеFk { get; set; }

    public int? СменаFk { get; set; }

    public int? ЖивотноеFk { get; set; }

    public virtual Животные? ЖивотноеFkNavigation { get; set; }

    public virtual Корма? КормFkNavigation { get; set; }

    public virtual Оборудование? ОборудованиеFkNavigation { get; set; }

    public virtual Смены? СменаFkNavigation { get; set; }
}
