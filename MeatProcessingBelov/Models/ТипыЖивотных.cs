using System;
using System.Collections.Generic;

namespace MeatProcessingBelov.Models;

public partial class ТипыЖивотных
{
    public int ТипЖивотногоId { get; set; }

    public string? Название { get; set; }

    public virtual ICollection<Животные> Животныеs { get; set; } = new List<Животные>();
}
