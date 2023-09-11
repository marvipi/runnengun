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
        public IEnumerator Executar_ObjetoAcabaDeSerInstanciado_MudaOSentidoHorizontalDoSprite([Values(false, true)] bool spriteInvertido)
        {
            componenteSpriteRenderer.flipY = spriteInvertido;

            componenteVirar.Executar(componenteComandavel);
            yield return null;

            Assert.AreNotEqual(spriteInvertido, componenteSpriteRenderer.flipY);
        }

        [UnityTest]
        public IEnumerator Executar_ObjetoAcabaDeSerInstanciado_IncrementaQtdRepeticoes()
        {
            componenteVirar.Executar(componenteComandavel);
            yield return null;
            Assert.AreEqual(1, componenteVirar.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Reverter_ObjetoViradoUmaVez_MudaOSentidoDoSpriteDeVolta([Values(false, true)] bool spriteInvertido)
        {
            componenteSpriteRenderer.flipY = spriteInvertido;

            componenteVirar.Executar(componenteComandavel);
            yield return null;

            componenteVirar.Reverter(componenteComandavel);
            yield return null;

            Assert.AreEqual(spriteInvertido, componenteSpriteRenderer.flipY);
        }

        [UnityTest]
        public IEnumerator Reverter_ObjetoViradoUmaVez_DecrementaQtdRepeticoes()
        {
            componenteVirar.Executar(componenteComandavel);
            yield return null;

            componenteVirar.Reverter(componenteComandavel);
            yield return null;

            Assert.Zero(componenteVirar.QtdRepeticoes);
        }
    }
}
