using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoticiasWebApi.Data;
using NoticiasWebApi.Models;

namespace NoticiasWebApi.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly ApiNoticiasContext _context;

        public ArticulosController(ApiNoticiasContext context)
        {
            _context = context;
        }

        // GET: api/Articulos
        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetArticles()
        {

            var query = _context.Articulos.AsQueryable();

            var articles = query.Select(articles => new ArticulosDto
            {
                Titulo = articles.Titulo,
                Descripcion = articles.Descripcion,
                Contenido = articles.Contenido,
                NombreAutor = articles.Autor.NombreAutor,
                UrlToImage = articles.UrlToImage,
                Url = articles.Url,
                FechaPublicacion = articles.FechaPublicacion,
                NombreCategoria = articles.Categoria.NombreCategoria,
                NombreFuente = articles.Fuente.NombreFuente,
                NombrePais = articles.Pais.NombrePais

            }).ToArray();

            return Ok(articles);
        }

        [HttpGet("{busqueda}")]
        [AllowAnonymous]
        public async Task<ActionResult<Articulo>> GetArticulo(String busqueda)
        {
            var query = _context.Articulos.AsQueryable().Where(a => a.Titulo.Contains(busqueda));

            if (!string.IsNullOrEmpty(busqueda))
            {
                query = query.Where(a => a.Titulo.Contains(busqueda));

                var articles = query.Select(articles => new ArticulosDto
                {
                    Titulo = articles.Titulo,
                    Descripcion = articles.Descripcion,
                    Contenido = articles.Contenido,
                    NombreAutor = articles.Autor.NombreAutor,
                    UrlToImage = articles.UrlToImage,
                    Url = articles.Url,
                    FechaPublicacion = articles.FechaPublicacion
                }).ToArray();

                return Ok(articles);

            }
            return NotFound();

        }

        //public async Task<ActionResult<IEnumerable<Articulo>>> GetArticulos()
        //{
        //    var articulo = await (from Articulo in _context.Articulos
        //                          join Autore in _context.Autores
        //                          on Articulo.AutorId equals Autore.AutorId
        //                          join Categoria in _context.Categorias
        //                          on Articulo.CategoriaId equals Categoria.CategoriaId
        //                          join Fuente in _context.Fuentes
        //                          on Articulo.FuenteId equals Fuente.FuenteId
        //                          join Paise in _context.Paises
        //                          on Articulo.PaisId equals Paise.PaisId
        //                          select new
        //                          {
        //                              Articulo.ArticuloId,
        //                              Fuente = Fuente.NombreFuente,
        //                              AutorId = Autore.AutorId,
        //                              Autor = Autore.NombreAutor,
        //                              Articulo.Titulo,
        //                              Articulo.Descripcion,
        //                              Articulo.Contenido,
        //                              Articulo.Url,
        //                              Articulo.UrlToImage,
        //                              Articulo.FechaPublicacion,
        //                              Articulo.CategoriaId,
        //                              NombreCategoria = Categoria.NombreCategoria,
        //                              Articulo.PaisId,
        //                              NombrePais = Paise.NombrePais

        //                          }).ToListAsync();
        //    return Ok(articulo);
        //}


        //    ArticuloId = item.ArticuloId,
        //    Titulo = item.Titulo,
        //    Descripcion = item.Descripcion,
        //    Url = item.Url,
        //    UrlToImage = item.UrlToImage,
        //    FechaPublicacion = item.FechaPublicacion,
        //    Contenido = item.Contenido,
        //    AutorId = item.AutorId,
        //    //CategoriaId = item.CategoriaId,
        //    //PaisId = item.PaisId,
        //    //FuenteId = item.FuenteId

        //    }).ToListAsync();


        //GET: api/Articulos/5
        //[ActionName(nameof(GetArticle))]
        //[HttpGet("{q}")]
        //[AllowAnonymous]
        //public async Task<ActionResult<Articulo>> GetArticulos(/*int id*/ string q = null, string cat = null, int id = 0)
        //{
        //    var articulo = await (from Articulo in _context.Articulos
        //                          join Autore in _context.Autores
        //                          on Articulo.AutorId equals Autore.AutorId
        //                          join Categoria in _context.Categorias
        //                          on Articulo.CategoriaId equals Categoria.CategoriaId
        //                          join Fuente in _context.Fuentes
        //                          on Articulo.FuenteId equals Fuente.FuenteId
        //                          join Paise in _context.Paises
        //                          on Articulo.PaisId equals Paise.PaisId
        //                          select new
        //                          {
        //                              Articulo.ArticuloId,
        //                              Fuente = Fuente.NombreFuente,
        //                              AutorId = Autore.AutorId,
        //                              Autor = Autore.NombreAutor,
        //                              Articulo.Titulo,
        //                              Articulo.Descripcion,
        //                              Articulo.Contenido,
        //                              Articulo.Url,
        //                              Articulo.UrlToImage,
        //                              Articulo.FechaPublicacion,
        //                              CategoriaId = Categoria.CategoriaId,
        //                              NombreCategoria = Categoria.NombreCategoria,
        //                              PaisId = Paise.PaisId,
        //                              //NombrePais = Paise.NombrePais

        //                          }).FirstOrDefaultAsync(x => q != null ? x.Titulo.Contains(q) : id != 0 ? x.ArticuloId == id : cat != null ? x.NombreCategoria == cat : x.Titulo == "");

        //    if (articulo == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(articulo);
        //}


        // PUT: api/Articulos/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticulo(int id, Articulo articulo)
        {
            if (id != articulo.ArticuloId)
            {
                return BadRequest();
            }

            _context.Entry(articulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticuloExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Articulos

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Articulo>> PostArticulo(Articulo articulo)
        {

            var _articulo = new Articulo
            {
                Titulo = articulo.Titulo,
                Descripcion = articulo.Descripcion,
                Contenido = articulo.Contenido,
                Url = articulo.Url,
                UrlToImage = articulo.UrlToImage,
                FechaPublicacion = articulo.FechaPublicacion,
                AutorId = articulo.AutorId,
                FuenteId = articulo.FuenteId,
                CategoriaId = articulo.CategoriaId,
                PaisId = articulo.PaisId,               
                
            };


            _context.Articulos.Add(_articulo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetArticulo), new { busqueda = _articulo.Titulo }, _articulo);
        }
        


        // DELETE: api/Articulos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulo(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }

            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArticuloExists(int id)
        {
            return _context.Articulos.Any(e => e.ArticuloId == id);
        }
    }
}



