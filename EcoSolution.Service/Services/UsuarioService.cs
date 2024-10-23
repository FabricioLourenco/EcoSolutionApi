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

        public async Task<Usuario> InserirUsuario(UsuarioDTo model)
        {
            var usuario = await _usuarioRepository.BuscarUsuario(model.EstacaoId);
            if (usuario == null)
                usuario = _mapper.Map<Usuario>(model);
            else
                return usuario;

            return await _usuarioRepository.InserirUsuario(usuario);
        }

        public async Task<bool> AlterarStatusUsuario(bool status, long estacaoId)
        {
            var usuario = await BuscarUsuario(estacaoId);
            if(usuario == null)
                throw new Exception($"Usuario pertencente ao estacaoId: {estacaoId}, não foi encontrado");

            usuario.Ativo = status;
            await _usuarioRepository.AtualizarUsuario(usuario);

            return true;

        }

        public async Task<Usuario> BuscarUsuario(long estacaoId)
        {
            return await _usuarioRepository.BuscarUsuario(estacaoId);
        }

        public async Task<Usuario?> BuscarUsuario(long estacaoId, string chaveSecreta)
        {
            return await _usuarioRepository.BuscarUsuario(estacaoId, chaveSecreta);
        }
        
        #endregion

    }
}
