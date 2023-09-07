using Atores;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace ComportamentosTestSuite
{
    public class DesativarTest
    {
        GameObject desativar;
        IAcao componenteDesativar;
        GameObject bonecoDeTeste;
        Comandavel componenteComandavel;

        [SetUp]
        public void Setup()
        {
            desativar = new GameObject("Desativar");
            componenteDesativar = desativar.AddComponent<Desativar>();

            bonecoDeTeste = new GameObject("Boneco de teste");
            componenteComandavel = bonecoDeTeste.AddComponent<Jogador1>();
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(desativar);
            Object.Destroy(bonecoDeTeste);
        }

        [UnityTest]
        public IEnumerator Executar_ObjetoAtivoSemFilhos_DesativaOObjeto()
        {
            componenteDesativar.Executar(componenteComandavel);
            yield return null;

            Assert.False(bonecoDeTeste.activeInHierarchy);
        }

        [UnityTest]
        public IEnumerator Executar_ObjetoAtivoSemFilhos_IncrementaQtdRepeticoes()
        {
            componenteDesativar.Executar(componenteComandavel);
            yield return null;

            Assert.AreEqual(1, componenteDesativar.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Executar_ObjetoInativoSemFilhos_NaoIncrementaQtdRepeticoes()
        {
            bonecoDeTeste.SetActive(false);

            componenteDesativar.Executar(componenteComandavel);
            yield return null;

            Assert.Zero(componenteDesativar.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Executar_TodosOsFilhosAtivos_DesativaTodosOsFilhos()
        {
            InstanciarFilhos();

            componenteDesativar.Executar(componenteComandavel);
            yield return null;

            AssertTodosFilhosDesativados();
        }

        [UnityTest]
        public IEnumerator Executar_QuatroFilhos_QtdFilhosNaoAfetaQtdRepeticoes()
        {
            InstanciarFilhos(4);

            componenteDesativar.Executar(componenteComandavel);
            yield return null;
            var qtdExecucoes = 1;

            Assert.AreEqual(qtdExecucoes, componenteDesativar.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Executar_NoveFilhos_QtdFilhosNaoAfetaQtdRepeticoes()
        {
            InstanciarFilhos(9);

            componenteDesativar.Executar(componenteComandavel);
            yield return null;
            var qtdExecucoes = 1;

            Assert.AreEqual(qtdExecucoes, componenteDesativar.QtdRepeticoes);
        }


        [UnityTest]
        public IEnumerator Executar_PrimeiroFilhoInativo_DesativaTodosOsFilhos()
        {
            InstanciarFilhos();
            DesativarPrimeiroFilho();

            componenteDesativar.Executar(componenteComandavel);
            yield return null;

            AssertTodosFilhosDesativados();
        }


        [UnityTest]
        public IEnumerator Executar_FilhoDoMeioInativo_DesativaTodosOsFilhos()
        {
            InstanciarFilhos();
            DesativarFilhoDoMeio();

            componenteDesativar.Executar(componenteComandavel);
            yield return null;

            AssertTodosFilhosDesativados();
        }

        [UnityTest]
        public IEnumerator Executar_UltimoFilhoInativo_DesativaTodosOsFilhos()
        {
            InstanciarFilhos();
            DesativarUltimoFilho();

            componenteDesativar.Executar(componenteComandavel);
            yield return null;

            AssertTodosFilhosDesativados();
        }

        [UnityTest]
        public IEnumerator Reverter_ObjetoAtivoSemFilhos_ReativaOObjeto()
        {
            componenteDesativar.Executar(componenteComandavel);
            yield return null;
            componenteDesativar.Reverter(componenteComandavel);
            yield return null;

            Assert.True(bonecoDeTeste.activeInHierarchy);
        }

        [UnityTest]
        public IEnumerator Reverter_ObjetoAtivoSemFilhos_DecrementaQtdRepeticoes()
        {
            componenteDesativar.Executar(componenteComandavel);
            yield return null;
            componenteDesativar.Reverter(componenteComandavel);
            yield return null;

            Assert.Zero(componenteDesativar.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Reverter_ObjetoAtivoSemFilhos_NaoReverteSeQtdRepeticoesFor0()
        {
            componenteDesativar.Reverter(componenteComandavel);
            yield return null;

            Assert.Zero(componenteDesativar.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Reverter_ObjetoInativoSemFilhos_NaoReverteObjetoAtivo()
        {
            componenteDesativar.Executar(componenteComandavel);
            yield return null;

            bonecoDeTeste.SetActive(true);

            componenteDesativar.Reverter(componenteComandavel);
            yield return null;

            Assert.AreEqual(1, componenteDesativar.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Reverter_PrimeiroFilhoInativo_AtivaTodosOsFilhos()
        {
            InstanciarFilhos();
            DesativarPrimeiroFilho();

            componenteDesativar.Executar(componenteComandavel);
            yield return null;
            componenteDesativar.Reverter(componenteComandavel);
            yield return null;

            AssertTodosOsFilhosAtivos();
        }

        [UnityTest]
        public IEnumerator Reverter_FilhoDoMeioInativo_AtivaTodosOsFilhos()
        {
            InstanciarFilhos();
            DesativarFilhoDoMeio();

            componenteDesativar.Executar(componenteComandavel);
            yield return null;
            componenteDesativar.Reverter(componenteComandavel);
            yield return null;

            AssertTodosOsFilhosAtivos();
        }

        [UnityTest]
        public IEnumerator Reverter_UltimoFilhoInativo_AtivaTodosOsFilhos()
        {
            InstanciarFilhos();
            DesativarUltimoFilho();

            componenteDesativar.Executar(componenteComandavel);
            yield return null;
            componenteDesativar.Reverter(componenteComandavel);
            yield return null;

            AssertTodosOsFilhosAtivos();
        }

        [UnityTest]
        public IEnumerator Reverter_CincoFilhos_QtdFilhosNaoAfetaQtdRepeticoes()
        {
            InstanciarFilhos(5);

            componenteDesativar.Executar(componenteComandavel);
            yield return null;
            var qtdExecucoes = 1;
            
            componenteDesativar.Reverter(componenteComandavel);
            yield return null;
            var qtdReversoes = 1;
            Assert.AreEqual(qtdExecucoes - qtdReversoes, componenteDesativar.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Reverter_DozeFilhos_QtdFilhosNaoAfetaQtdRepeticoes()
        {
            InstanciarFilhos(12);

            componenteDesativar.Executar(componenteComandavel);
            yield return null;
            var qtdExecucoes = 1;

            componenteDesativar.Reverter(componenteComandavel);
            yield return null;
            var qtdReversoes = 1;
            Assert.AreEqual(qtdExecucoes - qtdReversoes, componenteDesativar.QtdRepeticoes);
        }

        private void AssertTodosOsFilhosAtivos()
        {
            foreach (Transform filho in bonecoDeTeste.transform)
            {
                Assert.True(filho.gameObject.activeInHierarchy);
            }
        }

        private void AssertTodosFilhosDesativados()
        {
            foreach (Transform filho in bonecoDeTeste.transform)
            {
                Assert.False(filho.gameObject.activeInHierarchy);
            }
        }

        // Instancia três objetos de jogo e os coloca como filhos do boneco de teste.
        // Para testar todos os pontos de variância, é necessário que o boneco de teste tenha, pelo menos, três filhos.
        private void InstanciarFilhos()
        {
            InstanciarFilhos(3);
        }

        // Instancia objetos de jogo e os coloca como filhos do boneco de teste.
        private void InstanciarFilhos(uint qtdDeFilhos)
        {
            GameObject filhoDeTeste;
            string nomeDoFilho;
            for (int i = 0; i < qtdDeFilhos; i++)
            {
                nomeDoFilho = string.Format("Filho de teste (0)", i);
                filhoDeTeste = new GameObject(nomeDoFilho);
                filhoDeTeste.transform.SetParent(bonecoDeTeste.transform);
            }
        }

        // Pressupõe que o boneco de teste tem pelo menos um filho.
        private void DesativarPrimeiroFilho()
        {
            var indicePrimeiroFilho = 0;
            DesativarFilho(indicePrimeiroFilho);
        }

        // Pressupõe que o boneco de teste tem pelo menos três filhos.
        private void DesativarFilhoDoMeio()
        {
            var indiceFilhoDoMeio = bonecoDeTeste.transform.childCount / 2;
            DesativarFilho(indiceFilhoDoMeio);
        }

        // Pressupõe que o boneco de teste tem pelo menos um filho.
        private void DesativarUltimoFilho()
        {
            var indiceUltimoFilho = bonecoDeTeste.transform.childCount - 1;
            DesativarFilho(indiceUltimoFilho);
        }

        // Desativa o filho do boneco de teste localizado no indice passado como argumento.
        private void DesativarFilho(int indice)
        {
            var filho = bonecoDeTeste.transform.GetChild(indice);
            filho.gameObject.SetActive(false);
        }
    }
}

