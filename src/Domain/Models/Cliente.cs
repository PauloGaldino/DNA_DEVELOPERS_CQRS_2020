using Domain.Core.Models;
using System;

namespace Domain.Models
{
    public class Cliente : Entity
    {
        public Cliente(Guid id, string nome, string email, DateTime dataNascimento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
        }

        // Empty constructor for EF
        protected Cliente() { }

        public string Nome { get; private set; }

        public string Email { get; private set; }

        public DateTime DataNascimento { get; private set; }
    }
}