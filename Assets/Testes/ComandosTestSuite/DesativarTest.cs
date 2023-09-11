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
        public IEnumerator Executar_TodosOsFilhosAtivos_DesativaTodosOsFilhos(
            [Values(2,6,3,19,5)] int qtdFilhos)
        {
            InstanciarFilhos(qtdFilhos);

            componenteDesativar.Executar(componenteComandavel);
            yield return null;

            AssertTodosFilhosDesativados();
        }

        [UnityTest]
        public IEnumerator Executar_TodosOsFilhosAtivos_QtdFilhosNaoAfetaQtdRepeticoes(
            [Values(1,6,10,15,21)] int qtdFilhos)
        {
            InstanciarFilhos(qtdFilhos);

            componenteDesativar.Executar(componenteComandavel);
            yield return null;

            Assert.AreEqual(1, componenteDesativar.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Executar_UmDosFilhosInativo_DesativaTodosOsFilhos(
            [Values(3)] int qtdFilhos,
            [Values(1, 2, 3)] int filhoNumero)
        {
            InstanciarFilhos(qtdFilhos);
            var indiceFilho = filhoNumero - 1;
            DesativarFilho(indiceFilho);

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
        public IEnumerator Reverter_UmDosFilhosInativo_AtivaTodosOsFilhos(
            [Values(3)] int qtdFilhos,
            [Values(1,2,3)] int filhoNumero)
        {
            InstanciarFilhos(qtdFilhos);
            var indiceFilho = filhoNumero - 1;
            DesativarFilho(indiceFilho);

            componenteDesativar.Executar(componenteComandavel);
            yield return null;
            componenteDesativar.Reverter(componenteComandavel);
            yield return null;

            AssertTodosOsFilhosAtivos();
        }

        [UnityTest]
        public IEnumerator Reverter_TodosOsFilhosAtivos_QtdFilhosNaoAfetaQtdRepeticoes(
            [Values(8, 3, 5, 84, 1)] int qtdFilhos)
        {
            InstanciarFilhos(qtdFilhos);

            componenteDesativar.Executar(componenteComandavel);
            yield return null;
            componenteDesativar.Reverter(componenteComandavel);
            yield return null;

            Assert.Zero(componenteDesativar.QtdRepeticoes);
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

        // Instancia objetos de jogo e os coloca como filhos do boneco de teste.
        // Pressupõe que a qtdDeFilhos é maior ou igual a 0.
        private void InstanciarFilhos(int qtdDeFilhos)
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

        // Desativa o filho do boneco de teste localizado no indice passado como argumento.
        // Pressupõe que o indice é maior ou igual a zero e menor que a quantidade de filhos do boneco de teste.
        private void DesativarFilho(int indice)
        {
            var filho = bonecoDeTeste.transform.GetChild(indice);
            filho.gameObject.SetActive(false);
        }
    }
}

