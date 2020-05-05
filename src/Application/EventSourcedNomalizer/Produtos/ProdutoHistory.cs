using Application.EventSourcedNomalizer.Cliente;
using Domain.Core.Events;
using FluentValidation.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Application.EventSourcedNomalizer.Produtos
{
    public class ProdutoHistory
    {
        public static IList<ProdutoHistoryData> HistoryData { get; set; }

        public static IList<ProdutoHistoryData> ToJavaScriptProdutoHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<ProdutoHistoryData>();
            ProdutoHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(p => p.When);
            var list = new List<ProdutoHistoryData>();
            var last = new ProdutoHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new ProdutoHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id ? "" : change.Id,
                    Descricao = string.IsNullOrWhiteSpace(change.Descricao) || change.Descricao == last.Descricao ? "" : change.Descricao,
                    Preco = string.IsNullOrWhiteSpace(change.Preco) || change.Preco == last.Preco ? "" : change.Preco,
                    Lote = string.IsNullOrWhiteSpace(change.Lote) || change.Lote == last.Lote ? "" : change.Lote,
                    DataFabraicacao = string.IsNullOrWhiteSpace(change.DataFabraicacao) || change.DataFabraicacao == last.DataFabraicacao ? "" : change.DataFabraicacao.Substring(0, 10),
                    DataValidade = string.IsNullOrWhiteSpace(change.DataValidade) || change.DataValidade == last.DataValidade ? "" : change.DataValidade.Substring(0, 10),
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };
                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void ProdutoHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new ProdutoHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "PodutoRegisteredEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.DataValidade = values["DataValidade"];
                        slot.DataFabraicacao = values["DataFabricacao"];
                        slot.Lote = values["Lote"];
                        slot.Preco = values["Preco"];
                        slot.Descricao = values["Descricao"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;

                    case "PodutoUpdateEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.DataValidade = values["DataValidade"];
                        slot.DataFabraicacao = values["DataFabricacao"];
                        slot.Lote = values["Lote"];
                        slot.Preco = values["Preco"];
                        slot.Descricao = values["Descricao"];
                        slot.Action = "Updated";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;

                    case "PodutoRemoveEvent":
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
