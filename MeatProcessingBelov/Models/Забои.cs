using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class Забои
{
    public int ЗабойId { get; set; }

    public int? СменаFk { get; set; }

    public virtual ICollection<ЖивотныеПоЗабоям> ЖивотныеПоЗабоямs { get; set; } = new List<ЖивотныеПоЗабоям>();

    public virtual ICollection<Мясо> Мясоs { get; set; } = new List<Мясо>();

    public virtual Смены? СменаFkNavigation { get; set; }
}
