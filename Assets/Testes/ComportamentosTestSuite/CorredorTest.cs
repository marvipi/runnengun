using Atores;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace ComportamentosTestSuite
{
    public class CorredorTest
    {
        GameObject bonecoDeTeste;

        GameObject objetoCorredor;
        Corredor componenteCorredor;


        [SetUp]
        public void Setup()
        {
            bonecoDeTeste = new GameObject("Boneco de teste");
            bonecoDeTeste.AddComponent<Jogador1>();
            bonecoDeTeste.AddComponent<Rigidbody2D>();
            bonecoDeTeste.AddComponent<SpriteRenderer>();

            objetoCorredor = new GameObject("Corredor");
            componenteCorredor = objetoCorredor.AddComponent<Corredor>();

            objetoCorredor.transform.SetParent(bonecoDeTeste.transform);
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(bonecoDeTeste);
            Object.Destroy(objetoCorredor);
        }

        [UnityTest]
        public IEnumerator Inicializacao_ObjetoAcabaDeSerInstanciado_AgregaOObjetoPai()
        {
            yield return null;

            Assert.AreSame(bonecoDeTeste.gameObject, componenteCorredor.Pai.gameObject);
        }

        [UnityTest]
        public IEnumerator Inicializacao_ObjetoAcabaDeSerInstanciado_AgregaOComandoAvancar()
        {
            var avancar = objetoCorredor.GetComponent<Avancar>();
            yield return null;

            Assert.NotNull(avancar);
        }

        [UnityTest]
        public IEnumerator Inicializacao_ObjetoAcabaDeSerInstanciado_AgregaOComandoVirar()
        {
            var virar = objetoCorredor.GetComponent<Virar>();
            yield return null;

            Assert.NotNull(virar);
        }

        [UnityTest]
        public IEnumerator Avancar_ComandavelPedeUmMovimento_OObjetoPaiEMovido()
        {
            var posicaoInicial = bonecoDeTeste.transform.position;

            componenteCorredor.Avancar();
            yield return new WaitForFixedUpdate();

            var posicaoFinal = bonecoDeTeste.transform.position;
            Assert.AreNotEqual(posicaoFinal, posicaoInicial);
        }

        [UnityTest]
        public IEnumerator Virar_ComandavelPedeParaVirar_OSpriteDoObjetoPaiEVirado()
        {
            var spriteRenderer = bonecoDeTeste.GetComponent<SpriteRenderer>();
            var spriteInicial = spriteRenderer.flipY;

            componenteCorredor.Virar();
            yield return new WaitForFixedUpdate();

            var spriteFinal = spriteRenderer.flipY;
            Assert.AreNotEqual(spriteFinal, spriteInicial);
        }

        [UnityTest]
        public IEnumerator Virar_ComandavelPedeParaVirar_AVelocidadeDoCorredorEInvertida()
        {
            var velocidadeInicial = componenteCorredor.Velocidade;

            componenteCorredor.Virar();
            yield return new WaitForFixedUpdate();

            var velocidadeInvertida = -velocidadeInicial;
            Assert.AreEqual(velocidadeInvertida, componenteCorredor.Velocidade);
        }
    }
}
