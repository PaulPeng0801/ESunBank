using System;
using System.Collections.Generic;

namespace ESunBank.Models;

public partial class FutureWeather
{
    public int Id { get; set; }

    public string City { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public string Weather { get; set; } = null!;

    public DateTime CreateTime { get; set; }
}
