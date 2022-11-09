using EstudantesApp.Dominio.IRepositories;
using EstudantesApp.Dominio.IServices;
using EstudantesApp.Transporte;

namespace EstudantesApp.Services
{
    public class EstudanteService : IEstudanteService
    {
        private readonly IEstudanteRepository _estudanteRepository;

        public EstudanteService(IEstudanteRepository estudanteRepository)
        {
            _estudanteRepository = estudanteRepository;
        }

        public async Task<List<EstudanteDTO>> ConsultaEstudantes()
        {
            return await _estudanteRepository.ConsultaEstudantes();
        }

        public async Task<EstudanteDTO> ConsultaEstudantes(int id)
        {
            return await _estudanteRepository.ConsultaEstudantes(id);
        }

        public async Task<bool> CriarEstudante(EstudanteDTO estudante)
        {
           return await _estudanteRepository.CriarEstudante(estudante);
        }

        public async Task<bool> DeletarEstudante(int id)
        {
           return await _estudanteRepository.DeletarEstudante(id);
        }

        public async Task<bool> EditarEstudantes(EstudanteDTO estudante)
        {
            return await _estudanteRepository.EditarEstudantes(estudante);
        }
    }
}
