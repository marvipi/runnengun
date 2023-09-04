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
        GameObject filhoDeTeste1;
        GameObject filhoDeTeste2;

        [SetUp]
        public void Setup()
        {
            removerSe = new GameObject("RemoverSe");
            componenteRemoverSe = removerSe.AddComponent<RemoverSe>();
            bonecoDeTeste = new GameObject("Boneco de teste");

            filhoDeTeste1 = new GameObject("Primeiro filho de teste");
            filhoDeTeste1.transform.SetParent(bonecoDeTeste.transform);

            filhoDeTeste2 = new GameObject("Primeiro filho de teste");
            filhoDeTeste2.transform.SetParent(bonecoDeTeste.transform);
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
            yield return Executar();

            Assert.False(bonecoDeTeste.activeInHierarchy);
        }

        [UnityTest]
        public IEnumerator Executar_ObjetoAtivoSemFilhos_IncrementaQtdRepeticoes()
        {
            yield return Executar();

            Assert.AreEqual(1, componenteRemoverSe.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Executar_ObjetoInativoSemFilhos_NaoIncrementaQtdRepeticoes()
        {
            bonecoDeTeste.SetActive(false);

            yield return Executar();

            Assert.Zero(componenteRemoverSe.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Executar_UmFilhoAtivo_DesativaOFilho()
        {
            yield return Executar();

            Assert.False(filhoDeTeste1.activeInHierarchy);
        }

        [UnityTest]
        public IEnumerator Executar_DoisFilhosAtivos_DesativaTodosOsFilhos()
        {
            yield return Executar();

            Assert.False(filhoDeTeste1.activeInHierarchy && filhoDeTeste2.activeInHierarchy);
        }

        [UnityTest]
        public IEnumerator Executar_UmFilhoAtivoEUmFilhoInativo_DesativaTodosOsFilhos()
        {
            filhoDeTeste2.SetActive(false);

            yield return Executar();

            Assert.False(filhoDeTeste1.activeInHierarchy && filhoDeTeste2.activeInHierarchy);
        }

        [UnityTest]
        public IEnumerator Executar_DoisFilhosAtivos_IncrementaQtdRepeticoesUmaUnicaVez()
        {
            yield return Executar();
            Assert.AreEqual(1, componenteRemoverSe.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Reverter_ObjetoAtivoSemFilhos_ReativaOObjeto()
        {
            yield return ExecutarEReverter();

            Assert.True(bonecoDeTeste.activeInHierarchy);
        }

        [UnityTest]
        public IEnumerator Reverter_ObjetoAtivoSemFilhos_DecrementaQtdRepeticoes()
        {
            yield return ExecutarEReverter();

            Assert.Zero(componenteRemoverSe.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Reverter_ObjetoAtivoSemFilhos_NaoReverteSeQtdRepeticoesFor0()
        {
            yield return Reverter();

            Assert.Zero(componenteRemoverSe.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Reverter_ObjetoInativoSemFilhos_NaoReverteObjetoAtivo()
        {
            yield return Executar();

            bonecoDeTeste.SetActive(true);

            yield return Reverter();

            Assert.AreEqual(1, componenteRemoverSe.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Reverter_UmFilhoAtivo_ReativaOFilho()
        {
            yield return ExecutarEReverter();

            Assert.True(filhoDeTeste1.activeInHierarchy);
        }

        [UnityTest]
        public IEnumerator Reverter_UmFilhoInativo_ReativaOFilho()
        {
            filhoDeTeste1.SetActive(false);

            yield return ExecutarEReverter();

            Assert.True(filhoDeTeste1.activeInHierarchy);
        }

        [UnityTest]
        public IEnumerator Reverter_DoisFilhosInativos_AtivaTodosOsFilhos()
        {
            yield return ExecutarEReverter();

            Assert.True(filhoDeTeste1.activeInHierarchy && filhoDeTeste2.activeInHierarchy);
        }

        [UnityTest]
        public IEnumerator Reverter_UmFilhoAtivoEUmFilhoInativo_AtivaTodosOsFilhos()
        {
            filhoDeTeste2.SetActive(false);

            yield return ExecutarEReverter();

            Assert.True(filhoDeTeste1.activeInHierarchy && filhoDeTeste2.activeInHierarchy);
        }

        [UnityTest]
        public IEnumerator Reverter_DoisFilhosInativos_DecrementaQtdRepeticoesUmaUnicaVez()
        {
            yield return ExecutarEReverter();

            Assert.Zero(componenteRemoverSe.QtdRepeticoes);
        }

        private IEnumerator ExecutarEReverter()
        {
            yield return Executar();
            yield return Reverter();
        }

        private IEnumerator Executar()
        {
            componenteRemoverSe.Executar(bonecoDeTeste);
            yield return null;
        }

        private IEnumerator Reverter()
        {
            componenteRemoverSe.Reverter(bonecoDeTeste);
            yield return null;
        }
    }
}

