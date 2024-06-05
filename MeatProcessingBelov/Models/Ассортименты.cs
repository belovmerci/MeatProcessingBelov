using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class Ассортименты
{
    public int АссортиментId { get; set; }

    public int? Количество { get; set; }

    public int? МагазинFk { get; set; }

    public int? РецептураFk { get; set; }

    public virtual Магазины? МагазинFkNavigation { get; set; }

    public virtual ICollection<Продажи>? Продажиs { get; set; } = new List<Продажи>();

    public virtual Рецептуры? РецептураFkNavigation { get; set; }
}
