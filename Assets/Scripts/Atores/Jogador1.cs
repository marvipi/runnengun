using Auxiliares;
using System.Collections;
using UnityEngine;

namespace Atores
{
    /// <summary>
    /// Representa o protagonista do jogo.
    /// </summary>
    public class Jogador1 : Jogador
    {
        private void Start()
        {
            Vidas = gameObject.AddComponent<Vidas>();
            Pontuacao = gameObject.AddComponent<Pontuacao>();

            StartCoroutine(InicializarHUD());
        }

        private IEnumerator InicializarHUD()
        {
            HUD = FindAnyObjectByType<HUDJogador1>();

            yield return new WaitUntil(() => HUD is not null);

            HUD.Atualizar(Vidas.QtdVidas);
            HUD.Atualizar(Pontuacao.QtdPontos);
        }

        public override void Pontuar(uint qtdPontos)
        {
            throw new System.NotImplementedException();
        }

        private protected override void OnMorrer()
        {
            throw new System.NotImplementedException();
        }

        private protected override void OnPontuacaoAlterada()
        {
            throw new System.NotImplementedException();
        }

        private protected override void OnQtdVidasAlterada()
        {
            throw new System.NotImplementedException();
        }

        private protected override void OnVidaGanha()
        {
            throw new System.NotImplementedException();
        }
    }
}
