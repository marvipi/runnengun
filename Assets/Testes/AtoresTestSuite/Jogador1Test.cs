using Atores;
using Auxiliares;
using NUnit.Framework;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;

namespace AtoresTestSuite
{
    public class Jogador1Test
    {
        GameObject jogador1;
        Jogador1 componenteJogador1;
        Vidas vidas;
        Pontuacao pontuacao;

        GameObject HUD;
        IHUD hudJogador1;
        GameObject labelVidas;
        GameObject labelPontuacao;

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(jogador1);
        }

        [UnityTest]
        public IEnumerator Inicializacao_JogoComecouAgora_ArmazenaReferenciaAVidas()
        {
            InicializarJogador();
            yield return null;

            InicializarVidasEPontuacao();
            yield return null;

            Assert.NotNull(vidas);
        }

        [UnityTest]
        public IEnumerator Inicializacao_JogoComecouAgora_ArmazenaReferenciaAPontuacao()
        {
            InicializarJogador();
            yield return null;

            InicializarVidasEPontuacao();
            yield return null;

            Assert.NotNull(pontuacao);
        }

        [UnityTest]
        public IEnumerator Inicializacao_JogoComecouAgora_ArmazenaReferenciaAOHUD()
        {
            InicializarHUD();
            InicializarJogador();

            yield return new WaitUntil(() => componenteJogador1.HUD is not null);

            Assert.AreSame(hudJogador1, componenteJogador1.HUD);

            DestruirHUD();
        }

        [UnityTest]
        public IEnumerator Inicializacao_JogoComecouAgora_ExibeAsVidasNoHUD()
        {
            InicializarHUD();
            InicializarJogador();
            yield return null;

            InicializarVidasEPontuacao();
            yield return null;

            var vidasEsperada = string.Format(IHUD.FORMATO_VIDAS, vidas.QtdVidas);
            Assert.AreEqual(vidasEsperada, hudJogador1.LabelVidas.text);

            DestruirHUD();
        }

        [UnityTest]
        public IEnumerator Inicializacao_JogoComecouAgora_ExibeAPontuacaoNoHUD()
        {
            InicializarHUD();
            InicializarJogador();
            yield return null;

            InicializarVidasEPontuacao();
            yield return null;

            var pontuacaoEsperada = string.Format(IHUD.FORMATO_PONTUACAO, pontuacao.QtdPontos);
            Assert.AreEqual(pontuacaoEsperada, hudJogador1.LabelPontuacao.text);

            DestruirHUD();
        }

        private void InicializarJogador()
        {
            jogador1 = new GameObject("Jogador 1");
            componenteJogador1 = jogador1.AddComponent<Jogador1>();
        }

        private void InicializarVidasEPontuacao()
        {
            vidas = jogador1.GetComponent<Vidas>();
            pontuacao = jogador1.GetComponent<Pontuacao>();
        }

        // O HUD deve ser inicializado antes do jogador para que este possa guardar uma referência a ele
        private void InicializarHUD()
        {
            HUD = new GameObject("HUD");
            hudJogador1 = HUD.AddComponent<HUDJogador1>();

            labelVidas = new GameObject("Vidas do jogador 1");
            labelVidas.AddComponent<TextMeshProUGUI>();
            labelVidas.tag = hudJogador1.TagLabelVidas;

            labelPontuacao = new GameObject("Pontuacao do jogador 1");
            labelPontuacao.AddComponent<TextMeshProUGUI>();
            labelPontuacao.tag = hudJogador1.TagLabelPontuacao;

            labelVidas.transform.SetParent(HUD.transform);
            labelPontuacao.transform.SetParent(HUD.transform);
        }

        private void DestruirHUD() => Object.Destroy(HUD);
    }
}
