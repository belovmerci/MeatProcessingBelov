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

}
