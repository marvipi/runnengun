using Atores;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace ComportamentosTestSuite
{
    public class RemoverTest
    {
        GameObject remover;
        IComando componenteRemover;
        GameObject bonecoDeTeste;
        Comandavel componenteComandavel;

        [SetUp]
        public void Setup()
        {
            remover = new GameObject("Remover");
            componenteRemover = remover.AddComponent<Remover>();

            bonecoDeTeste = new GameObject("Boneco de teste");
            componenteComandavel = bonecoDeTeste.AddComponent<Jogador1>();
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(remover);
            Object.Destroy(bonecoDeTeste);
        }

        [UnityTest]
        public IEnumerator Executar_ObjetoAtivoSemFilhos_DesativaOObjeto()
        {
            componenteRemover.Executar(componenteComandavel);
            yield return null;

            Assert.False(bonecoDeTeste.activeInHierarchy);
        }

        [UnityTest]
        public IEnumerator Executar_ObjetoAtivoSemFilhos_IncrementaQtdRepeticoes()
        {
            componenteRemover.Executar(componenteComandavel);
            yield return null;

            Assert.AreEqual(1, componenteRemover.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Executar_ObjetoInativoSemFilhos_NaoIncrementaQtdRepeticoes()
        {
            bonecoDeTeste.SetActive(false);

            componenteRemover.Executar(componenteComandavel);
            yield return null;

            Assert.Zero(componenteRemover.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Executar_TodosOsFilhosAtivos_DesativaTodosOsFilhos()
        {
            InstanciarFilhos();

            componenteRemover.Executar(componenteComandavel);
            yield return null;

            AssertTodosFilhosDesativados();
        }

        [UnityTest]
        public IEnumerator Executar_QuatroFilhos_QtdFilhosNaoAfetaQtdRepeticoes()
        {
            InstanciarFilhos(4);

            componenteRemover.Executar(componenteComandavel);
            yield return null;
            var qtdExecucoes = 1;

            Assert.AreEqual(qtdExecucoes, componenteRemover.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Executar_NoveFilhos_QtdFilhosNaoAfetaQtdRepeticoes()
        {
            InstanciarFilhos(9);

            componenteRemover.Executar(componenteComandavel);
            yield return null;
            var qtdExecucoes = 1;

            Assert.AreEqual(qtdExecucoes, componenteRemover.QtdRepeticoes);
        }


        [UnityTest]
        public IEnumerator Executar_PrimeiroFilhoInativo_DesativaTodosOsFilhos()
        {
            InstanciarFilhos();
            DesativarPrimeiroFilho();

            componenteRemover.Executar(componenteComandavel);
            yield return null;

            AssertTodosFilhosDesativados();
        }


        [UnityTest]
        public IEnumerator Executar_FilhoDoMeioInativo_DesativaTodosOsFilhos()
        {
            InstanciarFilhos();
            DesativarFilhoDoMeio();

            componenteRemover.Executar(componenteComandavel);
            yield return null;

            AssertTodosFilhosDesativados();
        }

        [UnityTest]
        public IEnumerator Executar_UltimoFilhoInativo_DesativaTodosOsFilhos()
        {
            InstanciarFilhos();
            DesativarUltimoFilho();

            componenteRemover.Executar(componenteComandavel);
            yield return null;

            AssertTodosFilhosDesativados();
        }

        [UnityTest]
        public IEnumerator Reverter_ObjetoAtivoSemFilhos_ReativaOObjeto()
        {
            componenteRemover.Executar(componenteComandavel);
            yield return null;
            componenteRemover.Reverter(componenteComandavel);
            yield return null;

            Assert.True(bonecoDeTeste.activeInHierarchy);
        }

        [UnityTest]
        public IEnumerator Reverter_ObjetoAtivoSemFilhos_DecrementaQtdRepeticoes()
        {
            componenteRemover.Executar(componenteComandavel);
            yield return null;
            componenteRemover.Reverter(componenteComandavel);
            yield return null;

            Assert.Zero(componenteRemover.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Reverter_ObjetoAtivoSemFilhos_NaoReverteSeQtdRepeticoesFor0()
        {
            componenteRemover.Reverter(componenteComandavel);
            yield return null;

            Assert.Zero(componenteRemover.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Reverter_ObjetoInativoSemFilhos_NaoReverteObjetoAtivo()
        {
            componenteRemover.Executar(componenteComandavel);
            yield return null;

            bonecoDeTeste.SetActive(true);

            componenteRemover.Reverter(componenteComandavel);
            yield return null;

            Assert.AreEqual(1, componenteRemover.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Reverter_PrimeiroFilhoInativo_AtivaTodosOsFilhos()
        {
            InstanciarFilhos();
            DesativarPrimeiroFilho();

            componenteRemover.Executar(componenteComandavel);
            yield return null;
            componenteRemover.Reverter(componenteComandavel);
            yield return null;

            AssertTodosOsFilhosAtivos();
        }

        [UnityTest]
        public IEnumerator Reverter_FilhoDoMeioInativo_AtivaTodosOsFilhos()
        {
            InstanciarFilhos();
            DesativarFilhoDoMeio();

            componenteRemover.Executar(componenteComandavel);
            yield return null;
            componenteRemover.Reverter(componenteComandavel);
            yield return null;

            AssertTodosOsFilhosAtivos();
        }

        [UnityTest]
        public IEnumerator Reverter_UltimoFilhoInativo_AtivaTodosOsFilhos()
        {
            InstanciarFilhos();
            DesativarUltimoFilho();

            componenteRemover.Executar(componenteComandavel);
            yield return null;
            componenteRemover.Reverter(componenteComandavel);
            yield return null;

            AssertTodosOsFilhosAtivos();
        }

        [UnityTest]
        public IEnumerator Reverter_CincoFilhos_QtdFilhosNaoAfetaQtdRepeticoes()
        {
            InstanciarFilhos(5);

            componenteRemover.Executar(componenteComandavel);
            yield return null;
            var qtdExecucoes = 1;
            
            componenteRemover.Reverter(componenteComandavel);
            yield return null;
            var qtdReversoes = 1;
            Assert.AreEqual(qtdExecucoes - qtdReversoes, componenteRemover.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Reverter_DozeFilhos_QtdFilhosNaoAfetaQtdRepeticoes()
        {
            InstanciarFilhos(12);

            componenteRemover.Executar(componenteComandavel);
            yield return null;
            var qtdExecucoes = 1;

            componenteRemover.Reverter(componenteComandavel);
            yield return null;
            var qtdReversoes = 1;
            Assert.AreEqual(qtdExecucoes - qtdReversoes, componenteRemover.QtdRepeticoes);
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

