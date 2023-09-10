using Auxiliares;
using NUnit.Framework;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;

namespace AuxiliaresTestSuite
{
    public class HUDJogador1Test
    {
        GameObject hud;
        IHUD componenteHud;

        GameObject labelVidas;
        TextMeshProUGUI tmpVidas;

        GameObject labelPontuacao;
        TextMeshProUGUI tmpPontuacao;

        [SetUp]
        public void Setup()
        {
            hud = new GameObject("HUD do jogador 1");
            componenteHud = hud.AddComponent<HUDJogador1>();

            labelVidas = new GameObject("Vidas do jogador 1");
            tmpVidas = labelVidas.AddComponent<TextMeshProUGUI>();

            labelPontuacao = new GameObject("Pontuacao do jogador 1");
            tmpPontuacao = labelPontuacao.AddComponent<TextMeshProUGUI>();

            labelVidas.tag = componenteHud.TagLabelVidas;
            labelPontuacao.tag = componenteHud.TagLabelPontuacao;

            labelVidas.transform.SetParent(hud.transform);
            labelPontuacao.transform.SetParent(hud.transform);
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(hud);
            Object.Destroy(labelVidas);
        }

        [UnityTest]
        public IEnumerator Inicializacao_JogoComecouAgora_InicializaTagLabelVidas()
        {
            yield return null;

            Assert.AreEqual(componenteHud.TagLabelVidas, labelVidas.tag);
        }

        [UnityTest]
        public IEnumerator Inicializacao_JogoComecouAgora_InicializaTagLabelPontuacao()
        {
            yield return null;

            Assert.AreEqual(componenteHud.TagLabelPontuacao, labelPontuacao.tag);
        }

        [UnityTest]
        public IEnumerator Inicializacao_JogoComecouAgora_ArmazenaUmReferenciaAOLabelVidas()
        {
            yield return null;

            Assert.AreSame(tmpVidas, componenteHud.LabelVidas);
        }

        [UnityTest]
        public IEnumerator Inicializacao_JogoComecouAgora_ArmazenaUmReferenciaAOLabelPontuacao()
        {
            yield return null;

            Assert.AreSame(tmpPontuacao, componenteHud.LabelPontuacao);
        }

        [UnityTest]
        public IEnumerator AtualizarVidas_JogoComecouAgora_MostraAsVidasNoHUD()
        {
            byte qtdVidas = 3;

            componenteHud.Atualizar(qtdVidas);
            yield return null;

            var textoEsperado = string.Format(IHUD.FORMATO_VIDAS, qtdVidas);
            Assert.AreEqual(textoEsperado, tmpVidas.text);
        }

        [UnityTest]
        public IEnumerator AtualizarPontuacao_JogoComecouAgora_MostraAPontuacaoNoHUD()
        {
            uint qtdPontos = 346;

            componenteHud.Atualizar(qtdPontos);
            yield return null;

            var textoEsperado = string.Format(IHUD.FORMATO_PONTUACAO, qtdPontos);
            Assert.AreEqual(textoEsperado, tmpPontuacao.text);
        }
    }
}
