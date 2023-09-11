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

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(hud);
        }

        [Test]
        public void Inicializacao_HUDNaoTemOLabelVidas_LevanteUmExcecao()
        {
            try
            {
                InicializarHUD();
            } catch (System.NotSupportedException ex)
            {
                StringAssert.AreEqualIgnoringCase("O HUD deve ter um label com a tag " + componenteHud.TagLabelVidas + ".", ex.Message);
            }  
        }

        [Test]
        public void Inicializacao_HUDNaoTemLabelPontuacao_LevantaUmaExcecao()
        {
            try
            {
                InicializarHUD();
            } catch (System.NotSupportedException ex)
            {
                StringAssert.AreEqualIgnoringCase("O HUD deve ter um label com a tag " + componenteHud.TagLabelPontuacao + ".", ex.Message);
            }
        }

        [UnityTest]
        public IEnumerator Inicializacao_JogoComecouAgora_InicializaTagLabelVidas()
        {
            InicializarHUDCompleto();

            yield return null;

            Assert.AreEqual(componenteHud.TagLabelVidas, labelVidas.tag);
        }

        [UnityTest]
        public IEnumerator Inicializacao_JogoComecouAgora_InicializaTagLabelPontuacao()
        {
            InicializarHUDCompleto();

            yield return null;

            Assert.AreEqual(componenteHud.TagLabelPontuacao, labelPontuacao.tag);
        }

        [UnityTest]
        public IEnumerator Inicializacao_JogoComecouAgora_ArmazenaUmReferenciaAOLabelVidas()
        {
            InicializarHUDCompleto();

            yield return null;

            Assert.AreSame(tmpVidas, componenteHud.LabelVidas);
        }

        [UnityTest]
        public IEnumerator Inicializacao_JogoComecouAgora_ArmazenaUmReferenciaAOLabelPontuacao()
        {
            InicializarHUDCompleto();

            yield return null;

            Assert.AreSame(tmpPontuacao, componenteHud.LabelPontuacao);
        }

        [UnityTest]
        public IEnumerator AtualizarVidas_JogoComecouAgora_MostraAsVidasNoHUD([Values(0,3,9)] byte qtdVidas)
        {
            InicializarHUDCompleto();
            yield return null;

            componenteHud.Atualizar(qtdVidas);
            yield return null;

            var textoEsperado = string.Format(IHUD.FORMATO_VIDAS, qtdVidas);
            Assert.AreEqual(textoEsperado, tmpVidas.text);
        }

        [UnityTest]
        public IEnumerator AtualizarPontuacao_JogoComecouAgora_MostraAPontuacaoNoHUD([Values((uint) 0, (uint) 98475, uint.MaxValue)] uint qtdPontos)
        {
            InicializarHUDCompleto();
            yield return null;

            componenteHud.Atualizar(qtdPontos);
            yield return null;

            var textoEsperado = string.Format(IHUD.FORMATO_PONTUACAO, qtdPontos);
            Assert.AreEqual(textoEsperado, tmpPontuacao.text);
        }

        // Pressupõe que alguém vai consertar os erros pelo editor, se a inicalização levatar exceções.
        private void InicializarHUDCompleto()
        {
            InicializarHUD();
            InicializarLabelVidas();
            InicializarLabelPontuacao();
        }

        private void InicializarHUD()
        {
            hud = new GameObject("HUD do jogador 1");
            componenteHud = hud.AddComponent<HUDJogador1>();
        }

        private void InicializarLabelVidas()
        {
            labelVidas = new GameObject("Vidas do jogador 1");
            tmpVidas = labelVidas.AddComponent<TextMeshProUGUI>();
            labelVidas.tag = componenteHud.TagLabelVidas;
            labelVidas.transform.SetParent(hud.transform);
        }

        private void InicializarLabelPontuacao()
        {
            labelPontuacao = new GameObject("Pontuacao do jogador 1");
            tmpPontuacao = labelPontuacao.AddComponent<TextMeshProUGUI>();
            labelPontuacao.tag = componenteHud.TagLabelPontuacao;
            labelPontuacao.transform.SetParent(hud.transform);
        }
    }
}
