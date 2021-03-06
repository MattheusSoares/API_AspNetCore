﻿using ApiAspNetCore.Dominio.Commands.Usuario.Input;
using ApiAspNetCore.Dominio.Commands.Usuario.Output;
using ApiAspNetCore.Dominio.Entidades;
using ApiAspNetCore.Dominio.Helpers;
using ApiAspNetCore.Dominio.Query.Usuario;
using ApiAspNetCore.Dominio.Repositorio;
using LSCode.Facilitador.Api.InterfacesCommand;
using LSCode.Facilitador.Api.Results;
using LSCode.Validador.ValidacoesNotificacoes;
using System;

namespace ApiAspNetCore.Dominio.Handlers
{
    public class UsuarioHandler : Notificadora, ICommandHandler<AdicionarUsuarioCommand, Notificacao>,
                                                ICommandHandler<AtualizarUsuarioCommand, Notificacao>,
                                                ICommandHandler<ApagarUsuarioCommand, Notificacao>,
                                                ICommandHandler<LoginUsuarioCommand, Notificacao>
    {
        private readonly IUsuarioRepositorio _repository;

        public UsuarioHandler(IUsuarioRepositorio repository)
        {
            _repository = repository;
        }

        public ICommandResult<Notificacao> Handler(AdicionarUsuarioCommand command)
        {
            try
            {
                Usuario usuario = UsuarioHelper.GerarEntidade(command);

                AddNotificacao(usuario.Login.Notificacoes);
                AddNotificacao(usuario.Senha.Notificacoes);

                if (_repository.CheckLogin(usuario.Login.ToString()))
                    AddNotificacao("Login", "Esse login não está disponível pois já está sendo usado por outro usuário");

                if (Invalido)
                    return new CommandResult<Notificacao>("Inconsistência(s) no(s) dado(s)", Notificacoes);

                _repository.Salvar(usuario);

                usuario.Id = _repository.LocalizarMaxId();

                AdicionarUsuarioCommandOutput dadosRetorno = UsuarioHelper.GerarDadosRetornoInsert(usuario);

                return new CommandResult<Notificacao>("Usuário gravado com sucesso!", dadosRetorno);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ICommandResult<Notificacao> Handler(AtualizarUsuarioCommand command)
        {
            try
            {
                Usuario usuario = UsuarioHelper.GerarEntidade(command);

                AddNotificacao(usuario.Login.Notificacoes);
                AddNotificacao(usuario.Senha.Notificacoes);

                if (!_repository.CheckId(usuario.Id))
                    AddNotificacao("Id", "Id inválido. Este id não está cadastrado!");

                if (_repository.CheckLogin(usuario.Login.ToString()))
                    AddNotificacao("Login", "Esse login não está disponível pois já está sendo usado por outro usuário");

                if (Invalido)
                    return new CommandResult<Notificacao>("Inconsistência(s) no(s) dado(s)", Notificacoes);

                _repository.Atualizar(usuario);

                AtualizarUsuarioCommandOutput dadosRetorno = UsuarioHelper.GerarDadosRetornoUpdate(usuario);

                return new CommandResult<Notificacao>("Usuário atualizado com sucesso!", dadosRetorno);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ICommandResult<Notificacao> Handler(ApagarUsuarioCommand command)
        {
            try
            {
                if (!_repository.CheckId(command.Id))
                    AddNotificacao("Id", "Id inválido. Este id não está cadastrado!");

                if (Invalido)
                    return new CommandResult<Notificacao>("Inconsistência(s) no(s) dado(s)", Notificacoes);

                _repository.Deletar(command.Id);

                ApagarUsuarioCommandOutput dadosRetorno = UsuarioHelper.GerarDadosRetornoDelete(command.Id);

                return new CommandResult<Notificacao>("Usuário excluído com sucesso!", dadosRetorno);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ICommandResult<Notificacao> Handler(LoginUsuarioCommand command)
        {
            try
            {
                string login = command.Login;
                string senha = command.Senha;

                if (!_repository.CheckLogin(login))
                    AddNotificacao("Login", "Login incorreto! Esse login de usuário não existe");

                if (Invalido)
                    return new CommandResult<Notificacao>("Inconsistência(s) no(s) dado(s)", Notificacoes);

                UsuarioQueryResult usuario = _repository.Logar(login, senha);

                if (usuario != null)
                {
                    return new CommandResult<Notificacao>("Usuário logado com sucesso!", usuario);
                }
                else
                {
                    AddNotificacao("Senha", "Senha incorreta!");
                    return new CommandResult<Notificacao>("Inconsistência(s) no(s) dado(s)", Notificacoes);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}