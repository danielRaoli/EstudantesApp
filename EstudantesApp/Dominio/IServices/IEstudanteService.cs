using EstudantesApp.Transporte;

namespace EstudantesApp.Dominio.IServices
{
    public interface IEstudanteService
    {
        Task<List<EstudanteDTO>> ConsultaEstudantes();
        Task<EstudanteDTO> ConsultaEstudantes(int id);
        Task<bool> CriarEstudante(EstudanteDTO estudante);
        Task <bool>DeletarEstudante(int id);
        Task<bool> EditarEstudantes(EstudanteDTO estudante);
    }
}
