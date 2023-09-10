using Auxiliares;
using UnityEngine;

namespace Atores
{
    /// <summary>
    /// Representa um objeto de jogo que pode ser controlado pela pessoa que está jogando.
    /// <para>
    ///     Cada jogador tem:
    ///     <list type="bullet">
    ///     <item><description> De 0 a 9 vidas. </description></item>
    ///     <item><description> 3 vidas no inicio do jogo. </description></item>
    ///     <item><description> De 0 a uint.MaxValue pontos. </description></item>
    ///     <item><description> 0 pontos no inicio do jogo. </description></item>
    ///     </list>
    /// </para>
    /// <para>
    ///     Mecânicas do jogador:
    ///     <list type="bullet">
    ///     <item><description> Morre quando colide com inimigos. </description></item>
    ///     <item><description> Game over quando vidas chegarem a 0. </description></item>
    ///     <item><description> Ganha uma vida a cada mil pontos atingidos. </description></item>
    ///     <item><description> Ganha pontos matando inimigos. </description></item>
    ///     </list>
    /// </para>
    /// </summary>
    public abstract class Jogador : Comandavel
    {
        /// <summary>
        /// A quantidade de vidas que este jogador possui.
        /// </summary>
        private protected Vidas Vidas { get; set; }

        /// <summary>
        /// A quantidade de pontos que este jogador possui.
        /// </summary>
        private protected Pontuacao Pontuacao { get; set; }

        /// <summary>
        /// O canvas exibe as vidas e pontuação deste jogador.
        /// </summary>
        public IHUD HUD { get; private protected set; }

        /// <summary>
        /// Aumenta a pontuação do jogador pela quantidade de pontos passada como argumento.
        /// </summary>
        /// <param name="qtdPontos"> A quantidade de pontos que o jogador ganhou. </param>
        public abstract void Pontuar(uint qtdPontos);

        /// <summary>
        /// Define o que o jogador deve fazer quando ele morrer.
        /// </summary>
        private protected abstract void OnMorrer();

        /// <summary>
        /// Define o que o jogador deve fazer quando a quantidade de vidas que ele tem for alterada.
        /// </summary>
        private protected abstract void OnQtdVidasAlterada();

        /// <summary>
        /// Define o que o jogador deve fazer quando ele ganhar uma vida.
        /// </summary>
        private protected abstract void OnVidaGanha();

        /// <summary>
        /// Define o que o jogador deve fazer quando ele pontuar.
        /// </summary>
        private protected abstract void OnPontuacaoAlterada();
    }
}
