using EstudantesApp.Transporte;
using Microsoft.Build.Framework;

namespace EstudantesApp.Dominio.IRepositories
{
    public interface IEstudanteRepository
    {
        Task<List<EstudanteDTO>> ConsultaEstudantes();
        Task<EstudanteDTO> ConsultaEstudantes(int id);

        Task<bool> CriarEstudante(EstudanteDTO estudante);
        Task<bool> EditarEstudantes(EstudanteDTO estudante);
        Task<bool> DeletarEstudante(int id);
    }
}
