using Domain.Core.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.EventSourcedNomalizer.Cliente
{
    public class ClienteHistory
    {
        public static IList<ClienteHistoryData> HistoryData { get; set; }

        public static IList<ClienteHistoryData> ToJavaScriptClienteHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<ClienteHistoryData>();
            ClienteHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<ClienteHistoryData>();
            var last = new ClienteHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new ClienteHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    Nome = string.IsNullOrWhiteSpace(change.Nome) || change.Nome == last.Nome
                        ? ""
                        : change.Nome,
                    Email = string.IsNullOrWhiteSpace(change.Email) || change.Email == last.Email
                        ? ""
                        : change.Email,
                    DataNascimento = string.IsNullOrWhiteSpace(change.DataNascimento) || change.DataNascimento == last.DataNascimento
                        ? ""
                        : change.DataNascimento.Substring(0, 10),
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void ClienteHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new ClienteHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "ClienteRegisteredEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.DataNascimento = values["DataNascimento"];
                        slot.Email = values["Email"];
                        slot.Nome = values["Nome"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "ClienteUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.DataNascimento = values["DataNascimento"];
                        slot.Email = values["Email"];
                        slot.Nome = values["Nome"];
                        slot.Action = "Updated";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "ClienteRemovedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Action = "Removed";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                }
                HistoryData.Add(slot);
            }
        }
    }
}