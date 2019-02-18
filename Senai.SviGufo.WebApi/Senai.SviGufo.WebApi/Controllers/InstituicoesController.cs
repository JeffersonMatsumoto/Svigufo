using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Senai.SviGufo.WebApi.Repositories;

namespace Senai.SviGufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class InstituicoesController : ControllerBase
    {

        private IInstituicaoRepository InstituicaoRepository { get; set; }

        public InstituicoesController()
        {
            InstituicaoRepository = new InstituicaoRepository();
        }

        [HttpGet]
        public IEnumerable<InstituicaoDomain> Listar()
        {
            return InstituicaoRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            InstituicaoDomain instituicao = InstituicaoRepository.GetById(id);
            return Ok(instituicao);
        }

        [HttpPost]
        public IActionResult Cadastrar(InstituicaoDomain instituicaoCadastrada)
        {
            InstituicaoRepository.Cadastrar(instituicaoCadastrada);
            return Ok();
        }

        [HttpPut]
        public IActionResult Editar(InstituicaoDomain instituicaoEditada)
        {
            InstituicaoRepository.Editar(instituicaoEditada);
            return Ok(InstituicaoRepository.Listar());
        }

        [HttpDelete("{ID}")]
        public IActionResult Deletar(int id)
        {
            InstituicaoRepository.Deletar(id);
            return Ok();
        }

    }
}
