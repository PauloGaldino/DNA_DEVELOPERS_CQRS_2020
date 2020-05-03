using Domain.Core.Commands;
using System;

namespace Domain.Commands.Clientes
{

    public abstract class ClienteCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Nome { get; protected set; }
            
        public string Email { get; protected set; }

        public DateTime DataNascimento { get; protected set; }
    }
}