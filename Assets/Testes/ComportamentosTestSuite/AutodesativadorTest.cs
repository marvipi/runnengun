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
        public IEnumerator Start_Inicializacao_ArmazenaReferenceAOPai()
        {
            yield return null;

            Assert.NotNull(componenteAutodesativador.Pai);
        }

        [UnityTest]
        public IEnumerator Start_Inicializacao_AdicionaUmComponenteRemover()
        {
            yield return null;

            Assert.NotNull(componenteAutodesativador);
        }

        [UnityTest]
        public IEnumerator Remover_Integracao_DesativaArvoreDeObjetosAQualOAutodesativadorPertence()
        {
            componenteAutodesativador.Remover();
            yield return null;

            Assert.False(bonecoDeTeste.activeInHierarchy);
        }

        [UnityTest]
        public IEnumerator Reverter_Integracao_AtivaArvoreDeObjetosAQualOAutodesativadorPertence()
        {
            componenteAutodesativador.Remover();
            yield return null;
            componenteAutodesativador.Reverter();
            yield return null;

            Assert.True(bonecoDeTeste.activeInHierarchy);
        }
    }
}

