using ApiAspNetCore.Dominio.Entidades;
using ApiAspNetCore.Dominio.Query.Usuario;
using System.Collections.Generic;

namespace ApiAspNetCore.Dominio.Repositorio
{
    public interface IUsuarioRepositorio
    {
        void Salvar(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Deletar(int id);

        UsuarioQueryResult Obter(int id);
        List<UsuarioQueryResult> Listar();
        UsuarioQueryResult Logar(string login, string senha);

        bool CheckLogin(string login);
        bool CheckId(int id);
        int LocalizarMaxId();
    }
}