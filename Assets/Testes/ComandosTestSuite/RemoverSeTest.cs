using Comportamentos;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace ComportamentosTestSuite
{
    public class RemoverSeTest
    {
        GameObject removerSe;
        IComando componenteRemoverSe;
        GameObject bonecoDeTeste;

        [SetUp]
        public void Setup()
        {
            removerSe = new GameObject("RemoverSe");
            componenteRemoverSe = removerSe.AddComponent<RemoverSe>();
            bonecoDeTeste = new GameObject("Boneco de teste");
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(removerSe);
            Object.Destroy(bonecoDeTeste);
        }

        [UnityTest]
        public IEnumerator Executar_ObjetoAtivoSemFilhos_DesativaOObjeto()
        {
            componenteRemoverSe.Executar(bonecoDeTeste);
            yield return null;

            Assert.False(bonecoDeTeste.activeInHierarchy);
        }

        [UnityTest]
        public IEnumerator Executar_ObjetoAtivoSemFilhos_IncrementaQtdRepeticoes()
        {
            componenteRemoverSe.Executar(bonecoDeTeste);
            yield return null;

            Assert.AreEqual(1, componenteRemoverSe.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Executar_ObjetoInativoSemFilhos_NaoIncrementaQtdRepeticoes()
        {
            bonecoDeTeste.SetActive(false);

            componenteRemoverSe.Executar(bonecoDeTeste);
            yield return null;

            Assert.Zero(componenteRemoverSe.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Executar_TodosOsFilhosAtivos_DesativaTodosOsFilhos()
        {
            InstanciarFilhos();

            componenteRemoverSe.Executar(bonecoDeTeste);
            yield return null;

            AssertTodosFilhosDesativados();
        }

        [UnityTest]
        public IEnumerator Executar_QuatroFilhos_QtdFilhosNaoAfetaQtdRepeticoes()
        {
            InstanciarFilhos(4);

            componenteRemoverSe.Executar(bonecoDeTeste);
            yield return null;
            var qtdExecucoes = 1;

            Assert.AreEqual(qtdExecucoes, componenteRemoverSe.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Executar_NoveFilhos_QtdFilhosNaoAfetaQtdRepeticoes()
        {
            InstanciarFilhos(9);

            componenteRemoverSe.Executar(bonecoDeTeste);
            yield return null;
            var qtdExecucoes = 1;

            Assert.AreEqual(qtdExecucoes, componenteRemoverSe.QtdRepeticoes);
        }


        [UnityTest]
        public IEnumerator Executar_PrimeiroFilhoInativo_DesativaTodosOsFilhos()
        {
            InstanciarFilhos();
            DesativarPrimeiroFilho();

            componenteRemoverSe.Executar(bonecoDeTeste);
            yield return null;

            AssertTodosFilhosDesativados();
        }


        [UnityTest]
        public IEnumerator Executar_FilhoDoMeioInativo_DesativaTodosOsFilhos()
        {
            InstanciarFilhos();
            DesativarFilhoDoMeio();

            componenteRemoverSe.Executar(bonecoDeTeste);
            yield return null;

            AssertTodosFilhosDesativados();
        }

        [UnityTest]
        public IEnumerator Executar_UltimoFilhoInativo_DesativaTodosOsFilhos()
        {
            InstanciarFilhos();
            DesativarUltimoFilho();

            componenteRemoverSe.Executar(bonecoDeTeste);
            yield return null;

            AssertTodosFilhosDesativados();
        }

        [UnityTest]
        public IEnumerator Reverter_ObjetoAtivoSemFilhos_ReativaOObjeto()
        {
            componenteRemoverSe.Executar(bonecoDeTeste);
            yield return null;
            componenteRemoverSe.Reverter(bonecoDeTeste);
            yield return null;

            Assert.True(bonecoDeTeste.activeInHierarchy);
        }

        [UnityTest]
        public IEnumerator Reverter_ObjetoAtivoSemFilhos_DecrementaQtdRepeticoes()
        {
            componenteRemoverSe.Executar(bonecoDeTeste);
            yield return null;
            componenteRemoverSe.Reverter(bonecoDeTeste);
            yield return null;

            Assert.Zero(componenteRemoverSe.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Reverter_ObjetoAtivoSemFilhos_NaoReverteSeQtdRepeticoesFor0()
        {
            componenteRemoverSe.Reverter(bonecoDeTeste);
            yield return null;

            Assert.Zero(componenteRemoverSe.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Reverter_ObjetoInativoSemFilhos_NaoReverteObjetoAtivo()
        {
            componenteRemoverSe.Executar(bonecoDeTeste);
            yield return null;

            bonecoDeTeste.SetActive(true);

            componenteRemoverSe.Reverter(bonecoDeTeste);
            yield return null;

            Assert.AreEqual(1, componenteRemoverSe.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Reverter_PrimeiroFilhoInativo_AtivaTodosOsFilhos()
        {
            InstanciarFilhos();
            DesativarPrimeiroFilho();

            componenteRemoverSe.Executar(bonecoDeTeste);
            yield return null;
            componenteRemoverSe.Reverter(bonecoDeTeste);
            yield return null;

            AssertTodosOsFilhosAtivos();
        }

        [UnityTest]
        public IEnumerator Reverter_FilhoDoMeioInativo_AtivaTodosOsFilhos()
        {
            InstanciarFilhos();
            DesativarFilhoDoMeio();

            componenteRemoverSe.Executar(bonecoDeTeste);
            yield return null;
            componenteRemoverSe.Reverter(bonecoDeTeste);
            yield return null;

            AssertTodosOsFilhosAtivos();
        }

        [UnityTest]
        public IEnumerator Reverter_UltimoFilhoInativo_AtivaTodosOsFilhos()
        {
            InstanciarFilhos();
            DesativarUltimoFilho();

            componenteRemoverSe.Executar(bonecoDeTeste);
            yield return null;
            componenteRemoverSe.Reverter(bonecoDeTeste);
            yield return null;

            AssertTodosOsFilhosAtivos();
        }

        [UnityTest]
        public IEnumerator Reverter_CincoFilhos_QtdFilhosNaoAfetaQtdRepeticoes()
        {
            InstanciarFilhos(5);

            componenteRemoverSe.Executar(bonecoDeTeste);
            yield return null;
            var qtdExecucoes = 1;
            
            componenteRemoverSe.Reverter(bonecoDeTeste);
            yield return null;
            var qtdReversoes = 1;
            Assert.AreEqual(qtdExecucoes - qtdReversoes, componenteRemoverSe.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Reverter_DozeFilhos_QtdFilhosNaoAfetaQtdRepeticoes()
        {
            InstanciarFilhos(12);

            componenteRemoverSe.Executar(bonecoDeTeste);
            yield return null;
            var qtdExecucoes = 1;

            componenteRemoverSe.Reverter(bonecoDeTeste);
            yield return null;
            var qtdReversoes = 1;
            Assert.AreEqual(qtdExecucoes - qtdReversoes, componenteRemoverSe.QtdRepeticoes);
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

