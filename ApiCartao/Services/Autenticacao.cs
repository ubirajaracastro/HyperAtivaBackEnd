using BackEndCadastro.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuRH.Data.Services
{
    public class Autenticacao
    {
        public static bool Login(string login, string senha)
        {
            using (AppDbContext entities = new AppDbContext())
            {
                return entities.tblUsuario.Any(user => user.Login.Equals(login, StringComparison.OrdinalIgnoreCase)
                        && user.Senha == senha);
            }
        }


    }
}
