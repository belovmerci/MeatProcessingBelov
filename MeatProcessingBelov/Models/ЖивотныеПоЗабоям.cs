using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class ЖивотныеПоЗабоям
{
    public int ЖпзId { get; set; }

    public string? Название { get; set; }

    public int? ЗабойFk { get; set; }

    public int? ЖивотноеFk { get; set; }

    public virtual Животные? ЖивотноеFkNavigation { get; set; }

    public virtual Забои? ЗабойFkNavigation { get; set; }
}
