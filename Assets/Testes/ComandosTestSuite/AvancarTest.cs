using Atores;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace ComandosTestSuite
{
    public class AvancarTest
    {
        GameObject bonecoDeTeste;
        Comandavel componenteComandavel;

        GameObject avancar;
        IMovimento componenteAvancar;

        // A quantidade de movimento e o sentido no qual o boneco de teste será movido.
        const float DELTA = 50f;

        // A distância mínima entre a posição inicial e a posição após uma reversão, para que
        // uma reversão seja considerada um sucesso.
        const float DISTANCIA_REVERSAO = 0.01f;

        // A posição inicial do boneco de teste.
        Vector2 origem;

        // A posição para a qual o boneco de teste deverá ser movido.
        Vector2 destino;

        // A distância entre o objeto de jogo e o destino, antes de uma execução.
        float distanciaInicial;

        // A distância entre o objeto de jogo e o destino, após uma execução.
        float distanciaAtual;

        [SetUp]
        public void Setup()
        {
            bonecoDeTeste = new GameObject("Boneco de teste");
            componenteComandavel = bonecoDeTeste.AddComponent<Jogador1>();
            bonecoDeTeste.AddComponent<Rigidbody2D>();

            avancar = new GameObject("Avançar");
            componenteAvancar = avancar.AddComponent<Avancar>();
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(bonecoDeTeste);
            Object.Destroy(avancar);

            origem = Vector2.zero;
            destino = Vector2.zero;
            distanciaInicial = 0f;
            distanciaAtual = 0f;
        }

        [UnityTest]
        public IEnumerator Executar_EixoHorizontal_MoveOObjetoDeJogo([Values(DELTA, -DELTA)] float delta, [Values(Eixo.Horizontal)] Eixo eixo)
        {
            PegarOrigemEDestino(delta, eixo);

            componenteAvancar.Executar(componenteComandavel, eixo, delta);
            yield return new WaitForFixedUpdate();

            CalcularDistancias();

            Assert.Less(distanciaAtual, distanciaInicial);
        }

        [UnityTest]
        public IEnumerator Executar_EixoHorizontal_IncrementaQtdRepeticoes([Values(DELTA, -DELTA)] float delta, [Values(Eixo.Horizontal)] Eixo eixo)
        {
            componenteAvancar.Executar(componenteComandavel, eixo, delta);
            yield return new WaitForFixedUpdate();

            Assert.AreEqual(1, componenteAvancar.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Reverter_EixoHorizontal_ReverteOUltimoAvanco([Values(DELTA, -DELTA)] float delta, [Values(Eixo.Horizontal)] Eixo eixo)
        {
            PegarOrigemEDestino(delta, eixo);

            componenteAvancar.Executar(componenteComandavel, eixo, delta);
            yield return new WaitForFixedUpdate();

            componenteAvancar.Reverter(componenteComandavel, eixo, -delta);
            yield return new WaitForFixedUpdate();

            bool proximoOSuficiente = bonecoDeTeste.transform.position.x - origem.x < DISTANCIA_REVERSAO;
            Assert.True(proximoOSuficiente);
        }

        [UnityTest]
        public IEnumerator Reverter_EixoHorizontalDeltaPositivo_DecrementaQtdRepeticoes([Values(DELTA, -DELTA)] float delta, [Values(Eixo.Horizontal)] Eixo eixo)
        {
            componenteAvancar.Executar(componenteComandavel, eixo, delta);
            yield return new WaitForFixedUpdate();

            componenteAvancar.Reverter(componenteComandavel, eixo, -delta);
            yield return new WaitForFixedUpdate();

            Assert.Zero(componenteAvancar.QtdRepeticoes);
        }

        // Pega a posição inicial do boneco de teste e a usa para calcular a posição para a qual ele deverá ser movido.
        private void PegarOrigemEDestino(float delta, Eixo eixo)
        {
            origem = bonecoDeTeste.transform.position;
            switch (eixo)
            {
                case Eixo.Horizontal:
                    destino = new Vector2(origem.x + delta, origem.y);
                    break;
                case Eixo.Vertical:
                    throw new System.NotImplementedException();
                case Eixo.Diagonal:
                    throw new System.NotImplementedException();
            }
        }

        // Calcula a distância entre a posição do boneco de teste e a posição para a qual ele deve ser movido,
        // antes e depois do comando avançar ser executado.
        private void CalcularDistancias()
        {
            distanciaInicial = Vector2.Distance(destino, origem);

            Vector2 novaPosicao = bonecoDeTeste.transform.position;
            distanciaAtual = Vector2.Distance(destino, novaPosicao);
        }
    }
}
