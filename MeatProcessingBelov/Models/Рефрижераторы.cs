using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class Рефрижераторы
{
    public int РефрижераторId { get; set; }

    public string? Название { get; set; }

    public string? Модель { get; set; }

    public int? ВместимостьКг { get; set; }

}
