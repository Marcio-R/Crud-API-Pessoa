using CrudAPI.Data;
using CrudAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI.Sevice;

public class PessoaService
{
    private readonly CrudAPIContext _context;

    public PessoaService(CrudAPIContext context)
    {
        _context = context;
    }
    public async Task<List<Pessoa>> ObterPessoasAsync()
    {
        return await _context.Pessoa.ToListAsync();
    }
    public async Task<Pessoa> ObterPessoaIdAsync(int? id)
    {
        var pessoa = await _context.Pessoa.FindAsync(id);
        return pessoa;
    }
    public async Task InserirAsync(Pessoa pessoa)
    {
        _context.AddAsync(pessoa);
        await _context.SaveChangesAsync();
    }
    public async Task AtualizarAsync(Pessoa pessoa)
    {
        bool pessoaExite = await _context.Pessoa.AnyAsync(p => p.PessoaId == pessoa.PessoaId);
        if (pessoaExite != null)
        {
            _context.Update(pessoa);
            await _context.SaveChangesAsync();
           
        }
    }
    public async Task RemoverAsync(int id)
    {
        var obj = await _context.Pessoa.FindAsync(id);
        if (obj != null)
        {
            _context.Pessoa.Remove(obj);
            await _context.SaveChangesAsync();
        }
    }

}
