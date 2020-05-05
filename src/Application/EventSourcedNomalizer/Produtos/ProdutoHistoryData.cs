namespace Application.EventSourcedNomalizer.Produtos
{
    public class ProdutoHistoryData
    {
        public string Action { get; set; }
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string Preco { get; set; }
        public string Lote { get; set; }
        public string DataFabraicacao { get; set; }
        public string DataValidade { get; set; }
        public string When { get; set; }
        public string Who { get; set; }
    }
}
