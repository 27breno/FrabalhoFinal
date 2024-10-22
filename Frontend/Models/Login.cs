using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Frontend.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int PessoaId { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}  Login: Email: {Email}, Senha: {Senha}";
        }
    }
}
