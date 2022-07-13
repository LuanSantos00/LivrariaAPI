using LivrariaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrariaController : ControllerBase
    {
        private readonly ProdutosContext _context;

        public LivrariaController(ProdutosContext context)
        {
            _context = context;

            // dados mocados, para inicializar o banco em memória.
            //_context.Produtos.Add(new Produto { ID = "1", Nome = "Book1", Preco = 24.99, Quantidade = 1, Categoria = "Acao", Img = "img1" });
            //_context.Produtos.Add(new Produto { ID = "2", Nome = "Book2", Preco = 18.99, Quantidade = 3, Categoria = "Acao", Img = "img2" });
            //_context.Produtos.Add(new Produto { ID = "3", Nome = "Book3", Preco = 30.00, Quantidade = 2, Categoria = "Acao", Img = "img3" });
            //_context.Produtos.Add(new Produto { ID = "4", Nome = "Book4", Preco = 15.50, Quantidade = 5, Categoria = "Terror", Img = "img4" });
            //_context.Produtos.Add(new Produto { ID = "5", Nome = "Book5", Preco = 20.00, Quantidade = 10, Categoria = "Comedia", Img = "img5" });

            _context.SaveChanges();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetItem(int id)
        {
            var item = await _context.Produtos.FindAsync(id.ToString());

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> InserirProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return await GetItem(int.Parse(produto.ID));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarProduto(int id)
        {
            Produto item = await _context.Produtos.FindAsync(id.ToString());
            if(item == null)
            {
                return NotFound();
            }
            _context.Produtos.Remove(item);
            await _context.SaveChangesAsync();

            return Ok();

        }


    }
}
