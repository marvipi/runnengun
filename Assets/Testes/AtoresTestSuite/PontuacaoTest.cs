using Atores;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace AtoresTestSuite
{
    public class PontuacaoTest
    {
        GameObject pontuacao;
        Pontuacao componentePontuacao;

        bool sinalVidaGanhaEnviado;
        bool sinalPontuacaoAlteradaEnviado;

        [SetUp]
        public void Setup()
        {
            pontuacao = new GameObject("Pontuação");
            componentePontuacao = pontuacao.AddComponent<Pontuacao>();
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(pontuacao);
        }

        [UnityTest]
        public IEnumerator Pontuar_PontuacaoMenorQueAMaxima_AumentaAPontuacao()
        {
            uint qtdPontosInicial = 0;
            uint qtdPontos = 234;

            componentePontuacao.Pontuar(qtdPontos);
            yield return null;

            Assert.AreEqual(qtdPontosInicial + qtdPontos, componentePontuacao.QtdPontos);
        }

        [UnityTest]
        public IEnumerator Pontuar_PontuacaoMenorQueAMaxima_EnviaOSinalPontuacaoAlterada()
        {
            uint qtdPontos = 90;
            RegistrarSinalPontuacaoAlterada();

            componentePontuacao.Pontuar(qtdPontos);
            yield return null;

            Assert.True(sinalPontuacaoAlteradaEnviado);

            DesregistrarSinalPontuacaoAlterada();
        }

        [UnityTest]
        public IEnumerator Pontuar_PontuacaoMenorQueAMaximaEQtdPontosIgualAoIntervaloParaNovaVida_EnviaOSinalVidaGanha()
        {
            uint qtdPontos = Pontuacao.INTERVALO_PARA_NOVA_VIDA;
            RegistrarSinalVidaGanha();

            componentePontuacao.Pontuar(qtdPontos);
            yield return null;

            Assert.True(sinalVidaGanhaEnviado);

            DesregistrarSinalVidaGanha();
        }

        [UnityTest]
        public IEnumerator Pontuar_PontuacaoMenorQueAMaximaEQtdPontosUltrapassaOIntervaloParaNovaVida_EnviarOSinalVidaGanha()
        {
            uint divisor = 2;

            uint qtdPontosInicial = Pontuacao.INTERVALO_PARA_NOVA_VIDA / divisor;
            componentePontuacao.Pontuar(qtdPontosInicial);
            yield return null;

            RegistrarSinalVidaGanha();

            uint qtdPontos = Pontuacao.INTERVALO_PARA_NOVA_VIDA * divisor;
            componentePontuacao.Pontuar(qtdPontos);
            yield return null;

            Assert.True(sinalVidaGanhaEnviado);

            DesregistrarSinalVidaGanha();
        }

        [UnityTest]
        public IEnumerator Pontuar_PontuacaoMaximaAtingida_NaoAumentaAPontuacao()
        {
            componentePontuacao.Pontuar(Pontuacao.MAX_PONTUACAO);
            yield return null;

            componentePontuacao.Pontuar(1);
            yield return null;

            Assert.AreEqual(Pontuacao.MAX_PONTUACAO, componentePontuacao.QtdPontos);
        }

        [UnityTest]
        public IEnumerator Pontuar_PontuacaoMenorQueAMaxima_NaoUltrapassaAPontuacaoMaxima()
        {
            uint qtdPontos = 5;
            uint pontuacaoInicial = Pontuacao.MAX_PONTUACAO - (qtdPontos - 1);

            componentePontuacao.Pontuar(pontuacaoInicial);
            yield return null;

            componentePontuacao.Pontuar(qtdPontos);
            yield return null;

            Assert.AreEqual(Pontuacao.MAX_PONTUACAO, componentePontuacao.QtdPontos);
        }

        [UnityTest]
        public IEnumerator Pontuar_PontuacaoMaximaAtingida_NaoEnviaOSinalVidaGanha()
        {
            componentePontuacao.Pontuar(Pontuacao.MAX_PONTUACAO);
            yield return null;

            RegistrarSinalVidaGanha();

            componentePontuacao.Pontuar(1);
            yield return null;

            Assert.False(sinalVidaGanhaEnviado);

            DesregistrarSinalVidaGanha();
        }

        [UnityTest]
        public IEnumerator Pontuar_PontuacaoMaximaAtingida_NaoEnviaOSinalPontuacaoAlterada()
        {
            componentePontuacao.Pontuar(Pontuacao.MAX_PONTUACAO);
            yield return null;

            RegistrarSinalPontuacaoAlterada();

            componentePontuacao.Pontuar(1);
            yield return null;

            Assert.False(sinalVidaGanhaEnviado);

            DesregistrarSinalPontuacaoAlterada();
        }

        // Registra o método OnVidaGanha como ouvinte do sinal vidaGanha.
        private void RegistrarSinalVidaGanha()
        {
            componentePontuacao.vidaGanha += OnVidaGanha;
        }

        // Remove o método OnVidaGanha dos ouvintes do sinal vidaGanha e prepara o ambiente para o próximo teste.
        private void DesregistrarSinalVidaGanha()
        {
            componentePontuacao.vidaGanha -= OnVidaGanha;
            sinalVidaGanhaEnviado = false;
        }

        // Registra que o sinal vidaGanha foi enviado pela pontuação.
        private void OnVidaGanha()
        {
            sinalVidaGanhaEnviado = true;
        }

        // Registra o método OnPontuacaoAlterada como ouvinte do sinal pontuacaoAlterada.
        private void RegistrarSinalPontuacaoAlterada()
        {
            componentePontuacao.pontuacaoAlterada += OnPontuacaoAlterada;
        }

        // Remove o método OnPontuacaoAlterada dos ouvintes do sinal pontuacaoAlterada e prepara o ambiente para o
        // próximo teste.
        private void DesregistrarSinalPontuacaoAlterada()
        {
            componentePontuacao.pontuacaoAlterada -= OnPontuacaoAlterada;
            sinalPontuacaoAlteradaEnviado = false;
        }

        // Registra que o sinal pontuacaoAlterada foi enviado pela pontuação.
        private void OnPontuacaoAlterada()
        {
            sinalPontuacaoAlteradaEnviado = true;
        }
    }
}
