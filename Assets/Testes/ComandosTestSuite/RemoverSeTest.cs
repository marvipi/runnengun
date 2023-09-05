using Comportamentos;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace ComportamentosTestSuite
{
    public class RemoverSeTest
    {
        GameObject removerSe;
        IComando componenteRemoverSe;
        GameObject bonecoDeTeste;

        [SetUp]
        public void Setup()
        {
            removerSe = new GameObject("RemoverSe");
            componenteRemoverSe = removerSe.AddComponent<RemoverSe>();
            bonecoDeTeste = new GameObject("Boneco de teste");
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(removerSe);
            Object.Destroy(bonecoDeTeste);
        }

        [UnityTest]
        public IEnumerator Executar_ObjetoAtivoSemFilhos_DesativaOObjeto()
        {
            yield return Executar();

            Assert.False(bonecoDeTeste.activeInHierarchy);
        }

        [UnityTest]
        public IEnumerator Executar_ObjetoAtivoSemFilhos_IncrementaQtdRepeticoes()
        {
            yield return Executar();

            Assert.AreEqual(1, componenteRemoverSe.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Executar_ObjetoInativoSemFilhos_NaoIncrementaQtdRepeticoes()
        {
            bonecoDeTeste.SetActive(false);

            yield return Executar();

            Assert.Zero(componenteRemoverSe.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Executar_TodosOsFilhosAtivos_DesativaTodosOsFilhos()
        {
            InstanciarFilhos();

            yield return Executar();

            AssertTodosFilhosDesativados();
        }

        [UnityTest]
        public IEnumerator Executar_TodosOsFilhosAtivos_QtdFilhosNaoAfetaQtdRepeticoes()
        {
            var qtdExecucoes = 0;

            InstanciarFilhos(4); // 4 filhos
            yield return Executar();
            qtdExecucoes++;
            Assert.AreEqual(qtdExecucoes, componenteRemoverSe.QtdRepeticoes);

            bonecoDeTeste.SetActive(true);

            InstanciarFilhos(5); // 9 filhos
            yield return Executar();
            qtdExecucoes++;
            Assert.AreEqual(qtdExecucoes, componenteRemoverSe.QtdRepeticoes);

            bonecoDeTeste.SetActive(true);

            InstanciarFilhos(6); // 15 filhos
            yield return Executar();
            qtdExecucoes++;
            Assert.AreEqual(qtdExecucoes, componenteRemoverSe.QtdRepeticoes);
        }


        [UnityTest]
        public IEnumerator Executar_PrimeiroFilhoInativo_DesativaTodosOsFilhos()
        {
            InstanciarFilhos();
            DesativarPrimeiroFilho();

            yield return Executar();

            AssertTodosFilhosDesativados();
        }


        [UnityTest]
        public IEnumerator Executar_FilhoDoMeioInativo_DesativaTodosOsFilhos()
        {
            InstanciarFilhos();
            DesativarFilhoDoMeio();

            yield return Executar();

            AssertTodosFilhosDesativados();
        }

        [UnityTest]
        public IEnumerator Executar_UltimoFilhoInativo_DesativaTodosOsFilhos()
        {
            InstanciarFilhos();
            DesativarUltimoFilho();

            yield return Executar();

            AssertTodosFilhosDesativados();
        }

        [UnityTest]
        public IEnumerator Reverter_ObjetoAtivoSemFilhos_ReativaOObjeto()
        {
            yield return ExecutarEReverter();

            Assert.True(bonecoDeTeste.activeInHierarchy);
        }

        [UnityTest]
        public IEnumerator Reverter_ObjetoAtivoSemFilhos_DecrementaQtdRepeticoes()
        {
            yield return ExecutarEReverter();

            Assert.Zero(componenteRemoverSe.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Reverter_ObjetoAtivoSemFilhos_NaoReverteSeQtdRepeticoesFor0()
        {
            yield return Reverter();

            Assert.Zero(componenteRemoverSe.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Reverter_ObjetoInativoSemFilhos_NaoReverteObjetoAtivo()
        {
            yield return Executar();

            bonecoDeTeste.SetActive(true);

            yield return Reverter();

            Assert.AreEqual(1, componenteRemoverSe.QtdRepeticoes);
        }

        [UnityTest]
        public IEnumerator Reverter_PrimeiroFilhoInativo_AtivaTodosOsFilhos()
        {
            InstanciarFilhos();
            DesativarPrimeiroFilho();

            yield return ExecutarEReverter();

            AssertTodosOsFilhosAtivos();
        }

        [UnityTest]
        public IEnumerator Reverter_FilhoDoMeioInativo_AtivaTodosOsFilhos()
        {
            InstanciarFilhos();
            DesativarFilhoDoMeio();

            yield return ExecutarEReverter();

            AssertTodosOsFilhosAtivos();
        }

        [UnityTest]
        public IEnumerator Reverter_UltimoFilhoInativo_AtivaTodosOsFilhos()
        {
            InstanciarFilhos();
            DesativarUltimoFilho();

            yield return ExecutarEReverter();

            AssertTodosOsFilhosAtivos();
        }

        [UnityTest]
        public IEnumerator Reverter_TodosOsFilhosAtivos_QtdFilhosNaoAfetaAQtdRepeticoes()
        {
            var qtdExecucoes = 0;
            var qtdReversoes = 0;

            InstanciarFilhos(2); // 2 filhos
            yield return Executar();
            qtdExecucoes++;

            bonecoDeTeste.SetActive(true);

            InstanciarFilhos(9); // 11 filhos
            yield return Executar();
            qtdExecucoes++;

            bonecoDeTeste.SetActive(true);

            InstanciarFilhos(7); // 18 filhos
            yield return Executar();
            qtdExecucoes++;


            System.Func<int> qtdRepeticoesEsperada = () => qtdExecucoes - qtdReversoes;
            yield return Reverter();
            qtdReversoes++;
            Assert.AreEqual(qtdRepeticoesEsperada.Invoke(), componenteRemoverSe.QtdRepeticoes);

            bonecoDeTeste.SetActive(false);

            yield return Reverter();
            qtdReversoes++;
            Assert.AreEqual(qtdRepeticoesEsperada.Invoke(), componenteRemoverSe.QtdRepeticoes);

            bonecoDeTeste.SetActive(false);

            yield return Reverter();
            qtdReversoes++;
            Assert.AreEqual(qtdRepeticoesEsperada.Invoke(), componenteRemoverSe.QtdRepeticoes);
        }

        private IEnumerator ExecutarEReverter()
        {
            yield return Executar();
            yield return Reverter();
        }

        private IEnumerator Executar()
        {
            componenteRemoverSe.Executar(bonecoDeTeste);
            yield return null;
        }

        private IEnumerator Reverter()
        {
            componenteRemoverSe.Reverter(bonecoDeTeste);
            yield return null;
        }

        private void AssertTodosOsFilhosAtivos()
        {
            foreach (Transform filho in bonecoDeTeste.transform)
            {
                Assert.True(filho.gameObject.activeInHierarchy);
            }
        }

        private void AssertTodosFilhosDesativados()
        {
            foreach (Transform filho in bonecoDeTeste.transform)
            {
                Assert.False(filho.gameObject.activeInHierarchy);
            }
        }

        // Instancia três objetos de jogo e os coloca como filhos do boneco de teste.
        // Para testar todos os pontos de variância, é necessário que o boneco de teste tenha, pelo menos, três filhos.
        private void InstanciarFilhos()
        {
            InstanciarFilhos(3);
        }

        // Instancia objetos de jogo e os coloca como filhos do boneco de teste.
        private void InstanciarFilhos(uint qtdDeFilhos)
        {
            GameObject filhoDeTeste;
            string nomeDoFilho;
            for (int i = 0; i < qtdDeFilhos; i++)
            {
                nomeDoFilho = string.Format("Filho de teste (0)", i);
                filhoDeTeste = new GameObject(nomeDoFilho);
                filhoDeTeste.transform.SetParent(bonecoDeTeste.transform);
            }
        }

        // Pressupõe que o boneco de teste tem pelo menos um filho.
        private void DesativarPrimeiroFilho()
        {
            var indicePrimeiroFilho = 0;
            DesativarFilho(indicePrimeiroFilho);
        }

        // Pressupõe que o boneco de teste tem pelo menos três filhos.
        private void DesativarFilhoDoMeio()
        {
            var indiceFilhoDoMeio = bonecoDeTeste.transform.childCount / 2;
            DesativarFilho(indiceFilhoDoMeio);
        }

        // Pressupõe que o boneco de teste tem pelo menos um filho.
        private void DesativarUltimoFilho()
        {
            var indiceUltimoFilho = bonecoDeTeste.transform.childCount - 1;
            DesativarFilho(indiceUltimoFilho);
        }

        // Desativa o filho do boneco de teste localizado no indice passado como argumento.
        private void DesativarFilho(int indice)
        {
            var filho = bonecoDeTeste.transform.GetChild(indice);
            filho.gameObject.SetActive(false);
        }
    }
}

