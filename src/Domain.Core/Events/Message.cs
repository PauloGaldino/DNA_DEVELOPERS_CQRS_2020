using MediatR;
using System;

namespace Domain.Core.Events
{
    /// <summary>
    /// Classe resposável  responder o Requst
    /// e enviar mensagens de erro ou sucesso nos eventos
    /// </summary>
    public abstract class Message : IRequest<bool>
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}