﻿using ApiAspNetCore.Dominio.Enums;
using LSCode.Validador.ValidacoesNotificacoes;
using LSCode.Validador.ValueObjects;

namespace ApiAspNetCore.Dominio.Entidades
{
    public class Usuario : Notificadora
    {
        public int Id { get; set; }
        public Texto Login { get; set; }
        public SenhaMedia Senha { get; set; }
        public EPrivilegioUsuario Privilegio { get; set; }

        public Usuario(int id, Texto login, SenhaMedia senha, EPrivilegioUsuario privilegio)
        {
            Id = id;
            Login = login;
            Senha = senha;
            Privilegio = privilegio;
        }

        public Usuario(int id) => Id = id;
    }
}