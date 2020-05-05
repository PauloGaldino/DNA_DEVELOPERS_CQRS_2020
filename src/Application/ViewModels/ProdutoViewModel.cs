using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "O campo da descrição é obrigatório")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Descrição")]
        public String Descricao { get; set; }

        [Required(ErrorMessage = "O campo do preço é obrigatório")]
        [MinLength(2)]
        [DisplayName("Preço")]
        public decimal Preco { get; set; }


        [Required(ErrorMessage = "O ncampo do lote é obrigatório")]
        [MinLength(2)]
        public string Lote { get; set; }

        [Required(ErrorMessage = "Preencher campo Data de Fabricação")]
        [Display(Name = "Data de Fabricação")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataFabricacao { get; set; }

        [Required(ErrorMessage = "Preencher campo Data de Validade")]
        [Display(Name = "Data de Fabricação")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataValidade { get; set; }
    }
}
