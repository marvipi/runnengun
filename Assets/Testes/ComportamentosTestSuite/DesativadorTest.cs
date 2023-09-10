using Atores;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace ComportamentosTestSuite
{
    public class DesativadorTest
    {
        GameObject bonecoDeTeste;
        GameObject objetoDesativador;
        Desativador componenteDesativador;

        [SetUp]
        public void Setup()
        {
            bonecoDeTeste = new GameObject("Boneco de teste");
            bonecoDeTeste.AddComponent<Jogador1>();

            objetoDesativador = new GameObject("Desativador");
            objetoDesativador.AddComponent<Desativador>();
            objetoDesativador.transform.SetParent(bonecoDeTeste.transform);

            componenteDesativador = objetoDesativador.GetComponent<Desativador>();
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(bonecoDeTeste);
            Object.Destroy(objetoDesativador);
        }

        [UnityTest]
        public IEnumerator Inicializacao_ObjetoAcabaDeSerInstanciado_ArmazenaUmaReferenciaAOPai()
        {
            yield return null;

            Assert.NotNull(componenteDesativador.Pai);
        }

        [UnityTest]
        public IEnumerator Inicializacao_ObjetoAcabaDeSerInstanciado_AdicionaUmComponenteRemover()
        {
            yield return null;

            Assert.NotNull(componenteDesativador);
        }

        [UnityTest]
        public IEnumerator Remover_ComandavelPedeParaSerDesativado_DesativaArvoreDeObjetosAQualOAutodesativadorPertence()
        {
            componenteDesativador.Remover();
            yield return null;

            Assert.False(bonecoDeTeste.activeInHierarchy);
        }

        [UnityTest]
        public IEnumerator Reverter_ComandavelPedeParaSerAtivado_AtivaArvoreDeObjetosAQualOAutodesativadorPertence()
        {
            componenteDesativador.Remover();
            yield return null;
            componenteDesativador.Reverter();
            yield return null;

            Assert.True(bonecoDeTeste.activeInHierarchy);
        }
    }
}

