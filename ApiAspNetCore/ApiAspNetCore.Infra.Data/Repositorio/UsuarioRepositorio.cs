using ApiAspNetCore.Dominio.Entidades;
using ApiAspNetCore.Dominio.Query.Usuario;
using ApiAspNetCore.Dominio.Repositorio;
using System;
using System.Collections.Generic;

namespace ApiAspNetCore.Infra.Data.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public void Salvar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public UsuarioQueryResult Obter(int id)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioQueryResult> Listar()
        {
            throw new NotImplementedException();
        }

        public UsuarioQueryResult Logar(string login, string senha)
        {
            throw new NotImplementedException();
        }

        public bool CheckLogin(string login)
        {
            throw new NotImplementedException();
        }

        public bool CheckId(int id)
        {
            throw new NotImplementedException();
        }

        public int LocalizarMaxId()
        {
            throw new NotImplementedException();
        }
    }
}