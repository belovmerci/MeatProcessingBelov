using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class Магазины
{
    public int МагазинId { get; set; }

    public string? Название { get; set; }

    public string? Город { get; set; }

    public string? Адрес { get; set; }

    public string? Телефон { get; set; }

    public string? Email { get; set; }

    public bool Активный { get; set; }

}
