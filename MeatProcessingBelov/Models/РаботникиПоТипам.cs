using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class РаботникиПоТипам
{
    public int РптId { get; set; }

    public int? РаботникFk { get; set; }

    public int? ТипРаботникаFk { get; set; }

    public virtual Работники? РаботникFkNavigation { get; set; }

    public virtual ТипыРаботников? ТипРаботникаFkNavigation { get; set; }
}
