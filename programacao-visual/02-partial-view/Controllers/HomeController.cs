using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TechStore.Models;

namespace TechStore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Notebook TechStore X1",
                Description = "Notebook leve e rapido para trabalho e estudo.",
                Price = 4999.90m
            },
            new Product
            {
                Id = 2,
                Name = "Mouse Sem Fio Pro",
                Description = "Mouse ergonomico com bateria de longa duracao.",
                Price = 199.90m
            },
            new Product
            {
                Id = 3,
                Name = "Headset Gamer Vibe",
                Description = "Audio imersivo com microfone destacavel.",
                Price = 349.50m
            }
        };

        return View(products);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult ProdutoDetalhe(int id)
    {
        // Dados mockados para teste - simulando busca no banco de dados
        var produto = new ProdutoLojaViewModel
        {
            Id = id,
            NomeProduto = "Notebook Gamer TechPro X1",
            Descricao = "Notebook de alta performance com processador Intel i9, 32GB RAM, SSD 1TB e placa de vídeo RTX 4080. Ideal para jogos e trabalhos pesados de edição.",
            Preco = 12500.00m,
            PossuiEstoque = true
        };

        // Simulando um produto esgotado quando o ID é par
        if (id % 2 == 0)
        {
            produto.NomeProduto = "Smartphone Galaxy Ultra 5G";
            produto.Descricao = "Smartphone premium com câmera de 200MP, tela AMOLED 120Hz e bateria de 5000mAh.";
            produto.Preco = 4500.00m;
            produto.PossuiEstoque = false;
        }

        return View(produto);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
