using Atores;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace ComandosTestSuite
{
    public class VirarTest
    {
        GameObject bonecoDeTeste;
        Comandavel componenteComandavel;
        SpriteRenderer componenteSpriteRenderer;

        GameObject virar;
        IAcao componenteVirar;

        [SetUp]
        public void Setup()
        {
            bonecoDeTeste = new GameObject("Boneco de teste");
            componenteComandavel = bonecoDeTeste.AddComponent<Jogador1>();
            componenteSpriteRenderer = bonecoDeTeste.AddComponent<SpriteRenderer>();

            virar = new GameObject("Virar");
            componenteVirar = virar.AddComponent<Virar>();
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(bonecoDeTeste);
            Object.Destroy(virar);
        }

        [UnityTest]
        public IEnumerator Executar_ObjetoInstanciadoEmDirecaoADireita_MudaOSentidoHorizontalDoSpriteParaAEsquerda()
        {
            componenteVirar.Executar(componenteComandavel);
            yield return null;
            Assert.True(componenteSpriteRenderer.flipY);
        }

        [UnityTest]
        public IEnumerator Executar_ObjetoInstanciadoEmDirecaoADireita_IncrementaQtdRepeticoes()
        {
            componenteVirar.Executar(componenteComandavel);
            yield return null;
            Assert.AreEqual(1, componenteVirar.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Executar_ObjetoInstanciadoEmDirecaoAEsquerda_MudaOSentidoHorizontalDoSpriteParaADireita()
        {
            componenteSpriteRenderer.flipY = true;

            componenteVirar.Executar(componenteComandavel);
            yield return null;

            Assert.False(componenteSpriteRenderer.flipY);
        }

        [UnityTest]
        public IEnumerator Executar_ObjetoInstanciadoEmDirecaoAEsquerda_IncrementaAQtdDeRepeticoes()
        {
            componenteSpriteRenderer.flipY = true;

            componenteVirar.Executar(componenteComandavel);
            yield return null;

            Assert.AreEqual(1, componenteVirar.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Reverter_ObjetoInstanciadoEmDirecaoADireita_MudaOSentidoDoSpriteDeVoltaParaADireita()
        {
            componenteVirar.Executar(componenteComandavel);
            yield return null;

            componenteVirar.Reverter(componenteComandavel);
            yield return null;

            Assert.False(componenteSpriteRenderer.flipY);
        }

        [UnityTest]
        public IEnumerator Reverter_ObjetoInstanciadoEmDirecaoADireita_DecrementaQtdRepeticoes()
        {
            componenteVirar.Executar(componenteComandavel);
            yield return null;

            componenteVirar.Reverter(componenteComandavel);
            yield return null;

            Assert.Zero(componenteVirar.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Reverter_ObjetoInstanciadoEmDirecaoAEsquerda_MudaOSentidoDoSpriteDeVoltaParaAEsquerda()
        {
            componenteSpriteRenderer.flipY = true;

            componenteVirar.Executar(componenteComandavel);
            yield return null;

            componenteVirar.Reverter(componenteComandavel);
            yield return null;

            Assert.True(componenteSpriteRenderer.flipY);
        }

        [UnityTest]
        public IEnumerator Reverter_ObjetoInstanciadoEmDireçãoAEsquerda_DecrementaQtdRepeticoes()
        {
            componenteSpriteRenderer.flipY = true;

            componenteVirar.Executar(componenteComandavel);
            yield return null;

            componenteVirar.Reverter(componenteComandavel);
            yield return null;

            Assert.Zero(componenteVirar.QtdRepeticoes);
        }
    }
}
