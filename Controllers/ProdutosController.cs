using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Repos;
using System.Collections.Generic;
using System.Linq;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDatabase _context;

        public ProdutosController(AppDatabase context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Produto> Get()
        {
            var produtos = _context.Produtos.ToList();

            return produtos;

        }

        [HttpGet("{id}")]
        public Produto Get(int id)
        {
            //var produto = _context.Produtos.Where(p=>p.Id==id).First();
            //var produto = _context.Produtos.First(p=>p.Id==id);
            var produto = _context.Produtos.Find(id);

            return produto;

        }

        [HttpPost]
        public ActionResult<Produto> Post(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            var existingProduto = _context.Produtos.Find(id);
            if (existingProduto == null)
            {
                return NotFound();
            }

            existingProduto.Nome = produto.Nome;
            existingProduto.Valor = produto.Valor;
            existingProduto.Descricao = produto.Descricao;

            _context.Produtos.Update(existingProduto);
            _context.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return NoContent();
        }


    }
}
