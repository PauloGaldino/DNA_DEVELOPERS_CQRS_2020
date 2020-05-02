using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Events.Interfaces
{
    public interface IHandler<in T> where T : Message
    {
        void Handle(T message);
    }
}