using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Atividade.Model
{
    class Telefone
    {

        private string ddd = "";
        private string telefoneCelular = "";
        private string operadora = "";

        public Telefone() { }

        public Telefone(string ddd, string telefone, string operadora)
        {
            this.ddd = ddd;
            this.telefoneCelular = telefone;
            this.operadora = operadora;
        }

        public string Ddd { get => ddd; set => ddd = value; }
        public string TelefoneCelular { get => telefoneCelular; set => telefoneCelular = value; }
        public string Operadora { get => operadora; set => operadora = value; }

        public override string ToString()
        {
            return $"({Ddd}) {TelefoneCelular} - {Operadora}";
        }

    }
}
