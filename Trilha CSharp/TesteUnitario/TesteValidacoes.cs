using GerenciamentoContatos.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            ContatoBLL target = new ContatoBLL();
            string cpf = "35988186882";
            int idContato = 1;
            bool expected = true;
            bool actual;
            actual = Validacao.ValidaCPF(cpf, idContato);
            Assert.AreEqual(expected, actual, "CPF válido.");            
        }

        [TestMethod()]
        public void ValidaDataTest()
        {
            string data = "05/08/1988";
            bool expected = true;
            bool actual;
            actual = Validacao.ValidaData(data);            
            Assert.AreEqual(expected, actual, "Data válida.");            
        }

        [TestMethod()]
        public void ValidaNomeTest()
        {
            string nome = "Nome Sobrenome";
            bool expected = true;
            bool actual;
            actual = Validacao.ValidaNome(nome);
            Assert.AreEqual(expected, actual, "Nome está completo.");            
        }
    }
}