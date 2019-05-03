using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoContatos.Model;
using Smart.Model;

namespace GerenciamentoContatos.BLL
{
    public static class Validacao
    {
        public static bool ValidaCPF(string cpf, int idContato)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;
            string digito;

            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = new String(cpf.Where(Char.IsDigit).ToArray());

            if (cpf.Length != 11)
                return false;

            switch (cpf)
            {
                case "11111111111":
                    return false;
                case "00000000000":
                    return false;
                case "2222222222":
                    return false;
                case "33333333333":
                    return false;
                case "44444444444":
                    return false;
                case "55555555555":
                    return false;
                case "66666666666":
                    return false;
                case "77777777777":
                    return false;
                case "88888888888":
                    return false;
                case "99999999999":
                    return false;
            }

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();

            using (ContatoBLL contatoBLL = new ContatoBLL())
            {
                List<ContatoInfo> listaContatos = new List<ContatoInfo>();

                contatoBLL.Filters.FilterFields.Add(new DbFilterEqual(ContatoInfo.GetDsCpf(cpf)));

                listaContatos = contatoBLL.Listar();

                int cpfExiste = 0;
                    
                cpfExiste = (listaContatos.Count() > 0) ? listaContatos.FirstOrDefault().CdContato.Value : cpfExiste;

                return cpfExiste == idContato;

                //return cpf.EndsWith(digito);
            }            
        }

        public static bool ValidaEmail(string email)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return mail.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidaData(string data)
        {
            DateTime dt;

            bool dataValida = DateTime.TryParse(data, out dt);

            int idade = DateTime.Now.Year - dt.Year;

            if (dataValida && idade >= 18 && idade <= 60 && dt > DateTime.MinValue && dt < DateTime.Now)
                return true;
            else
                return false;
        }

        public static bool ValidaNome(string nome)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^([A-Za-zÀ-ú]{2,}\s[A-Za-zÀ-ú]{1,}'?-?[A-Za-zÀ-ú]{2,}\s?([A-Za-zÀ-ú]{1,})?)");

            return regex.IsMatch(nome);
        }
    }
}