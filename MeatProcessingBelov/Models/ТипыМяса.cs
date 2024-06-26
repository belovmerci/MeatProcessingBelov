﻿using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class ТипыМяса
{
    public int ТипМясаId { get; set; }

    public string? Название { get; set; }

    public virtual ICollection<Мясо> Мясоs { get; set; } = new List<Мясо>();

    public virtual ICollection<ТипыМясаПоРецептурам> ТипыМясаПоРецептурамs { get; set; } = new List<ТипыМясаПоРецептурам>();
}
