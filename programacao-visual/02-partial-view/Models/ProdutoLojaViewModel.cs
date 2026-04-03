namespace TechStore.Models;

public class ProdutoLojaViewModel
{
    public int Id { get; set; }
    public string NomeProduto { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public bool PossuiEstoque { get; set; }
}
