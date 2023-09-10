using System;
using UnityEngine;

namespace Atores
{
    /// <summary>
    /// Representa quantas vezes um jogador pode morrer até que ele seja removido do jogo.
    /// </summary>
    /// <remarks>
    /// Mecânicas de vida:
    /// <list type="bullet">
    ///     <item> <description>
    ///         Um jogador ganha uma vida a cada 1000 pontos ganhos.
    ///     </description></item>
    ///     <item> <description>
    ///         Um jogador morre quando a quantidade de vidas chegar a 0.
    ///     </description></item>
    ///     <item> <description>
    ///         Um jogador pode ter de 0 a 9 vidas.
    ///     </description></item>
    ///     <item> <description>
    ///         Todo jogador inicia o jogo com 3 vidas.
    ///     </description></item>
    /// </list>
    /// </remarks>
    public class Vidas : MonoBehaviour
    {
        /// <summary>
        /// A quantidade mínima de vidas que um jogador pode ter.
        /// </summary>
        public const byte MIN_VIDAS = 0;

        /// <summary>
        /// A quantidade máxima de vidas que um jogador pode ter.
        /// </summary>
        public const byte MAX_VIDAS = 9;

        /// <summary>
        /// A quantidade de vidas que um jogador tem após ser instanciado.
        /// </summary>
        public const byte QTD_VIDAS_INICIAL = 3;

        private byte qtdVidas = QTD_VIDAS_INICIAL;

        /// <summary>
        /// A quantidade de vidas de um jogador, em um intervalo de 0 a 9.
        /// </summary>
        public byte QtdVidas
        {
            get => qtdVidas;
            private set
            {
                qtdVidas = value;
                qtdVidasAlteradas?.Invoke();
            }
        }

        /// <summary>
        /// Sinaliza que as vidas chegaram a 0.
        /// </summary>
        public event Action morrer;

        /// <summary>
        /// Sinaliza que as vidas foram alteradas.
        /// </summary>
        public event Action qtdVidasAlteradas;

        /// <summary>
        /// Incrementa a quantidade de vidas.
        /// </summary>
        public void Ganhar()
        {
            if (QtdVidas >= MAX_VIDAS)
            {
                return;
            }
            QtdVidas++;
        }

        /// <summary>
        /// Decrementa a quantidade de vidas.
        /// </summary>
        public void Perder()
        {
            if (QtdVidas == MIN_VIDAS)
            {
                morrer?.Invoke();
            }
            else
            {
                QtdVidas--;
            }
        }
    }
}
