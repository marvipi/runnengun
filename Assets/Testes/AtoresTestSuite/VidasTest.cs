using System.Collections;
using Atores;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace AtoresTestSuite
{
    public class VidasTest
    {
        GameObject vidas;
        Vidas componenteVidas;

        bool sinalMorrerEnviado;
        bool sinalQtdVidasAlteradaEnviado;

        [SetUp]
        public void Setup()
        {
            vidas = new GameObject("Vidas");
            componenteVidas = vidas.AddComponent<Vidas>();
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(vidas);
        }

        [UnityTest]
        public IEnumerator Ganhar_QtdVidasMenorQueAMaxima_IncrementaQtdVidas()
        {
            componenteVidas.Ganhar();
            yield return null;

            Assert.AreEqual(Vidas.QTD_VIDAS_INICIAL + 1, componenteVidas.QtdVidas);
        }

        [UnityTest]
        public IEnumerator Ganhar_QtdVidasIgualAMaxima_NaoIncrementaQtdVidas()
        {
            for (int i = Vidas.QTD_VIDAS_INICIAL; i < Vidas.MAX_VIDAS; i++)
            {
                componenteVidas.Ganhar();
                yield return null;
            }

            componenteVidas.Ganhar();
            yield return null;

            Assert.AreEqual(Vidas.MAX_VIDAS, componenteVidas.QtdVidas);
        }

        [UnityTest]
        public IEnumerator Ganhar_QtdVidasMenorQueAMaxima_EnviaOSinalQtdVidasAlterada()
        {
            RegistrarSinalQtdVidasAlterada();

            componenteVidas.Ganhar();
            yield return null;

            Assert.True(sinalQtdVidasAlteradaEnviado);

            DesregistrarSinalQtdVidasAlterada();
        }

        [UnityTest]
        public IEnumerator Ganhar_QtdVidasIgualAMaxima_NaoEnviaOSinalQtdVidasAlterada()
        {
            for (int i = Vidas.QTD_VIDAS_INICIAL; i < Vidas.MAX_VIDAS; i++)
            {
                componenteVidas.Ganhar();
                yield return null;
            }
            RegistrarSinalQtdVidasAlterada();

            componenteVidas.Ganhar();
            yield return null;

            Assert.False(sinalQtdVidasAlteradaEnviado);

            DesregistrarSinalQtdVidasAlterada();

        }

        [UnityTest]
        public IEnumerator Perder_QtdVidasMaiorQueAMinima_DecrementaQtdVidas()
        {
            componenteVidas.Perder();
            yield return null;

            Assert.AreEqual(Vidas.QTD_VIDAS_INICIAL - 1, componenteVidas.QtdVidas);
        }

        [UnityTest]
        public IEnumerator Perder_QtdVidasIgualAMinima_NaoDecrementaQtdVidas()
        {
            for (int i = Vidas.QTD_VIDAS_INICIAL; i > Vidas.MIN_VIDAS; i--)
            {
                componenteVidas.Perder();
                yield return null;
            }

            componenteVidas.Perder();
            yield return null;

            Assert.Zero(componenteVidas.QtdVidas);
        }

        [UnityTest]
        public IEnumerator Perder_QtdVidasIgualAMinima_EnviaOSinalMorrer()
        {
            for (int i = Vidas.QTD_VIDAS_INICIAL; i > Vidas.MIN_VIDAS; i--)
            {
                componenteVidas.Perder();
                yield return null;
            }
            RegistrarSinalMorrer();

            componenteVidas.Perder();
            yield return null;

            Assert.True(sinalMorrerEnviado);

            DesregistrarSinalMorrer();
        }

        [UnityTest]
        public IEnumerator Perder_QtdVidasMaiorQueAMinima_NaoEnviaOSinalMorrer()
        {
            RegistrarSinalMorrer();

            componenteVidas.Perder();
            yield return null;

            Assert.False(sinalMorrerEnviado);

            DesregistrarSinalMorrer();
        }

        [UnityTest]
        public IEnumerator Perder_QtdVidasMaiorQueAMinima_EnviaOSinalQtdVidasAlterada()
        {
            RegistrarSinalQtdVidasAlterada();

            componenteVidas.Perder();
            yield return null;

            Assert.True(sinalQtdVidasAlteradaEnviado);

            DesregistrarSinalQtdVidasAlterada();
        }

        [UnityTest]
        public IEnumerator Perder_QtdVidasIgualAMinima_NaoEnviaOSinalQtdVidasAlterada()
        {
            for (int i = Vidas.QTD_VIDAS_INICIAL; i > Vidas.MIN_VIDAS; i--)
            {
                componenteVidas.Perder();
                yield return null;
            }
            RegistrarSinalQtdVidasAlterada();

            componenteVidas.Perder();
            yield return null;

            Assert.False(sinalQtdVidasAlteradaEnviado);

            DesregistrarSinalQtdVidasAlterada();
        }

        private void RegistrarSinalQtdVidasAlterada()
        {
            componenteVidas.qtdVidasAlteradas += OnQtdVidasAlterada;
        }

        private void DesregistrarSinalQtdVidasAlterada()
        {
            componenteVidas.qtdVidasAlteradas -= OnQtdVidasAlterada;
            sinalQtdVidasAlteradaEnviado = false;
        }

        private void OnQtdVidasAlterada()
        {
            sinalQtdVidasAlteradaEnviado = true;
        }

        private void RegistrarSinalMorrer()
        {
            componenteVidas.morrer += OnMorrer;
        }

        private void DesregistrarSinalMorrer()
        {
            componenteVidas.morrer -= OnMorrer;
            sinalMorrerEnviado = false;
        }

        private void OnMorrer()
        {
            sinalMorrerEnviado = true;
        }
    }
}
