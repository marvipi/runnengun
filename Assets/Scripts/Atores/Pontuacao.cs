using System;
using System.Collections;
using UnityEngine;

namespace Atores
{
    /// <summary>
    /// Representa a pontuação de um jogador.
    /// </summary>
    /// <remarks>
    /// Mecânicas da pontuação:
    /// <list type="bullet">
    ///     <item> <description>
    ///         Um jogador ganha pontos toda vez que ele ou um dos projéteis dele mata um inimigo.
    ///     </description> </item>
    ///     <item> <description>
    ///         Um jogador nunca perde pontos.
    ///     </description> </item>
    ///     <item> <description>
    ///         Um jogador ganha uma vida a cada 1000 pontos ganhos.
    ///     </description> </item>
    ///     <item> <description>
    ///         A pontuação pode ser de 0 a uint.MaxValue.
    ///     </description></item>
    ///     <item><description>
    ///         Todo jogador inicia o jogo com um pontuação de 0.
    ///     </description></item>
    /// </list>
    /// </remarks>
    public class Pontuacao : MonoBehaviour
    {
        /// <summary>
        /// A pontuação máxima que um jogador pode atingir.
        /// </summary>
        public const uint MAX_PONTUACAO = uint.MaxValue;

        /// <summary>
        /// O intervalo de pontos que dará uma nova vida ao jogador.
        /// </summary>
        public const uint INTERVALO_PARA_NOVA_VIDA = 1000;

        // A quantidade de pontos que dará uma nova vida ao jogador.
        private uint proximaVida = INTERVALO_PARA_NOVA_VIDA;

        private uint qtdPontos;

        /// <summary>
        /// A quantidade de pontos que um jogador tem.
        /// </summary>
        public uint QtdPontos
        {
            get => qtdPontos;
            private set
            {
                qtdPontos = value;
                pontuacaoAlterada?.Invoke();
                if (qtdPontos >= proximaVida)
                {
                    vidaGanha?.Invoke();
                    proximaVida += INTERVALO_PARA_NOVA_VIDA;
                }
            }
        }

        /// <summary>
        /// Sinaliza que um jogador acaba de ganhar uma vida.
        /// </summary>
        public event Action vidaGanha;

        /// <summary>
        /// Sinaliza que um jogador acaba de ganhar pontos.
        /// </summary>
        public event Action pontuacaoAlterada;

        /// <summary>
        /// Aumenta a quantidade de pontos de um jogador pela quantidade passada como argumento.
        /// </summary>
        /// <param name="qtdPontos"> A quantidade de pontos que o jogador ganhou. </param>
        public void Pontuar(uint qtdPontos)
        {
            if (QtdPontos == MAX_PONTUACAO)
            {
                return;
            }

            var pontuacaoMaximaSeraUltrapassada = MAX_PONTUACAO - QtdPontos < qtdPontos;
            if (pontuacaoMaximaSeraUltrapassada)
            {
                QtdPontos = MAX_PONTUACAO;
            } else
            {
                QtdPontos += qtdPontos;
            }
        }
    }
}
