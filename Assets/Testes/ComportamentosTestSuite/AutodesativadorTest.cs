using Atores;
using Comportamentos;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace ComportamentosTestSuite
{
    public class AutodesativadorTest
    {
        GameObject bonecoDeTeste;
        GameObject objetoAutodesativador;
        Autodesativador componenteAutodesativador;

        [SetUp]
        public void Setup()
        {
            bonecoDeTeste = new GameObject("Boneco de teste");
            bonecoDeTeste.AddComponent<Jogador1>();

            objetoAutodesativador = new GameObject("Autodesativador");
            objetoAutodesativador.AddComponent<Autodesativador>();
            objetoAutodesativador.transform.SetParent(bonecoDeTeste.transform);

            componenteAutodesativador = objetoAutodesativador.GetComponent<Autodesativador>();
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(bonecoDeTeste);
            Object.Destroy(objetoAutodesativador);
        }

        [UnityTest]
        public IEnumerator Start_Inicializacao_ArmazenaReferenciaAOObjetoDeJogoPai()
        {
            yield return null;

            Assert.NotNull(componenteAutodesativador.PaiObjeto);
        }

        [UnityTest]
        public IEnumerator Start_Inicializacao_ArmazenaReferenceAOComponenteComandavelDoPai()
        {
            yield return null;

            Assert.NotNull(componenteAutodesativador.PaiComandavel);
        }

        [UnityTest]
        public IEnumerator Start_Inicializacao_AdicionaUmComponenteRemoverSe()
        {
            yield return null;

            Assert.NotNull(componenteAutodesativador);
        }

        [UnityTest]
        public IEnumerator RemoverSe_Integracao_DesativaArvoreDeObjetosAQualOAutodesativadorPertence()
        {
            yield return RemoverSe();

            Assert.False(bonecoDeTeste.activeInHierarchy);
        }

        [UnityTest]
        public IEnumerator Reverter_Integracao_AtivaArvoreDeObjetosAQualOAutodesativadorPertence()
        {
            yield return RemoverSe();
            componenteAutodesativador.Reverter();
            yield return null;

            Assert.True(bonecoDeTeste.activeInHierarchy);
        }

        private IEnumerator RemoverSe()
        {
            componenteAutodesativador.RemoverSe();
            yield return null;
        }
    }
}

