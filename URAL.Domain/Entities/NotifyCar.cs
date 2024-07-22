﻿using URAL.Domain.Common;

namespace URAL.Domain.Entities;

public class NotifyCar : NotifyEntity
{
    public ulong CarId { get; set; }
    public Car? Car { get; set; }
}
