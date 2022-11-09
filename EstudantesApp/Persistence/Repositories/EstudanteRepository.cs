using EstudantesApp.Dominio.IRepositories;
using EstudantesApp.Dominio.Models;
using EstudantesApp.Persistence.Context;
using EstudantesApp.Transporte;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstudantesApp.Persistence.Repositories
{
    public class EstudanteRepository : IEstudanteRepository
    {
        private readonly AplicationDbContex _context;

        public EstudanteRepository(AplicationDbContex context)
        {
            _context = context;
        }

        public async Task<List<EstudanteDTO>> ConsultaEstudantes()
        {
            var estudantes = await (from t in _context.Estudantes
                                    select new EstudanteDTO
                                    {
                                        Id = t.Id,
                                        Nome = t.Nome,
                                        Sobrenome = t.Sobrenome,
                                        FechaInscrição = t.FechaInscrição.ToShortDateString()
                                    }).ToListAsync();
            return estudantes;
        }

        public async Task<EstudanteDTO> ConsultaEstudantes(int id)
        {
            var estudante = await (from t in _context.Estudantes
                                   where t.Id == id
                                   select new EstudanteDTO
                                   {
                                       Id = t.Id,
                                       Nome = t.Nome,
                                       Sobrenome = t.Sobrenome,
                                       FechaInscrição = t.FechaInscrição.ToShortDateString(),
                                       FechaDate = t.FechaInscrição
                                   }).FirstOrDefaultAsync();
            return estudante;
        }

        public async Task<bool> CriarEstudante(EstudanteDTO estudanteFront)
        {
            try
            {
                var fecha = estudanteFront == null ? "" : estudanteFront.FechaInscrição;
                var esCorreto= DateTime.TryParse(fecha, out DateTime result);
                if (!esCorreto) return false;

                var estudante = new Estudante
                {
                    FechaInscrição = result,
                    Nome= estudanteFront.Nome,
                    Sobrenome= estudanteFront.Sobrenome

                };
                _context.Estudantes.Add(estudante);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeletarEstudante(int id)
        {
            try
            {
                var estudante = await (from t in _context.Estudantes
                                       where t.Id == id
                                       select t).FirstOrDefaultAsync();

                if (estudante == null) return false;

                _context.Estudantes.Remove(estudante);
                _context.SaveChanges();
                return true;

            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<bool> EditarEstudantes(EstudanteDTO estudanteFront)
        {
            try
            {
                var estudante = await (from t in _context.Estudantes
                                        where t.Id== estudanteFront.Id
                                        select t).FirstOrDefaultAsync();

                if (estudante == null) return false;

                var fecha = estudanteFront.FechaInscrição;
                var esCorreto = DateTime.TryParse(fecha, out DateTime result);
                if (!esCorreto) return false;

                estudante.FechaInscrição = result;
                estudante.Nome= estudanteFront.Nome;
                estudante.Sobrenome= estudanteFront.Sobrenome;

                await _context.SaveChangesAsync();
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}
