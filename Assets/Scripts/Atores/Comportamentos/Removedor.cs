using UnityEngine;

namespace Atores
{
    /// <summary>
    /// Representa um comportamento que remove objetos do jogo.
    /// </summary>
    public abstract class Removedor : MonoBehaviour, IComandante
    {
        public Comandavel Pai { get; private protected set; }

        /// <summary>
        /// Um comando que remove objetos do jogo.
        /// </summary>
        private protected IAcao ComandoRemover { get; set; }

        /// <summary>
        /// Inicializa todas as referências necessárias para o funcionamento deste comportamento.
        /// </summary>
        private protected abstract void Inicializar();

        /// <summary>
        /// Remove um objeto do jogo.
        /// </summary>
        public abstract void Remover();
    }
}
