using AutoMapper;
using EcoSolution.Domain.DTos;
using EcoSolution.Domain.Entities;
using EcoSolution.Domain.Interface.Application.Services;
using EcoSolution.Domain.Interface.Infra.Data.Repositories;
using EcoSolution.Infra.CrossCutting.DI;

namespace EcoSolution.Service.Services
{
    public class UsuarioService : IUsuarioService , IScopedDependency
    {

        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        #region Private Methods
        #endregion

        #region Public Methods

        public Task<bool> AlterarStatusUsuario(bool status, long estacaoId)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario?> BuscarUsuario(long estacaoId, string chaveSecreta)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> BuscarUsuario(long estacaoId)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> InserirUsuario(UsuarioDTo model)
        {
            throw new NotImplementedException();
        }


        #endregion

    }
}
