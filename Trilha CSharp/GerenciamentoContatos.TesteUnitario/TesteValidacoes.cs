using Microsoft.VisualStudio.TestTools.UnitTesting;
using GerenciamentoContatos.BLL;
using Smart.Model;


namespace GerenciamentoContatos.TesteUnitario
{
    [TestClass()]
    public class TesteValidacoes
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        [TestMethod()]
        public void ValidaCPFTest()
        {
            BusinessObject.DbConnAssemblyName = "GerenciamentoContatos.Database";
            BusinessObject.DbConnClassPath = "GerenciamentoContatos.Database.DbConn";

            string cpf = "35988186882";
            int idContato = 1;
            bool expected = true;
            bool actual;

            actual = Validacao.ValidaCPF(cpf, idContato);

            Assert.AreEqual(expected, actual, "Número do CPF inválido ou já cadastrado.");            
        }

        [TestMethod()]
        public void ValidaDataTest()
        {
            string data = "05/08/1988";
            bool expected = true;
            bool actual;
            actual = Validacao.ValidaData(data);
            Assert.AreEqual(expected, actual, "Data de Nascimento inválida.");            
        }

        [TestMethod()]
        public void ValidaNomeTest()
        {
            string nome = "Nome Sobrenome";
            bool expected = true;
            bool actual;
            actual = Validacao.ValidaNome(nome);
            Assert.AreEqual(expected, actual, "Nome completo inválido.");            
        }
    }
}