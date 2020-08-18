using ApiAspNetCore.Dominio.Enums;

namespace ApiAspNetCore.Dominio.Query.Usuario
{
    public class UsuarioQueryResult
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public EPrivilegioUsuario Privilegio { get; set; }
        public string Token { get; set; }
    }
}