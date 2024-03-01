using CrudAPI.Models;
using CrudAPI.Sevice;
using Microsoft.AspNetCore.Mvc;

namespace CrudAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PessoasController : ControllerBase
{
    private readonly PessoaService _service;

    public PessoasController(PessoaService service)
    {
        _service = service;
    }

    // GET: api/<ValuesController>
    [HttpGet]
    public async Task<IActionResult> ObterTodasPessoas()
    {
        var pessoas = await _service.ObterPessoasAsync();
        return Ok(pessoas);
    }

    // GET api/<ValuesController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPessoaId(int id)
    {
        var pessoa = await _service.ObterPessoaIdAsync(id);
        if (pessoa == null)
        {
            return NotFound();
        }
        return Ok(pessoa);
    }

    // POST api/<ValuesController>
    [HttpPost]
    public async Task<IActionResult> AdicionarPessoa(Pessoa pessoa)
    {
        await _service.InserirAsync(pessoa);
        return Ok();
    }

    // PUT api/<ValuesController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> EditarPessoa(int id, Pessoa pessoa)
    {
        if (id != pessoa.PessoaId)
        {
            return BadRequest();
        }
        try
        {
            await _service.AtualizarAsync(pessoa);
            return Ok();
        }
        catch (Exception)
        {

            return NoContent();
        }
    }

    // DELETE api/<ValuesController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePessoa(int id)
    {
        await _service.RemoverAsync(id);
        return Ok();
    }
}
