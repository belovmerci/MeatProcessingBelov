using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class РаботникиМагазинов
{
    public int РаботникМагазинаId { get; set; }

    public int? РаботникFk { get; set; }

    public int? МагазинFk { get; set; }

    public virtual Магазины? МагазинFkNavigation { get; set; }

    public virtual Работники? РаботникFkNavigation { get; set; }
}
