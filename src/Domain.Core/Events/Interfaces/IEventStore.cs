﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Events.Interfaces
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}