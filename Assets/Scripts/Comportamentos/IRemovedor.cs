using UnityEngine;

namespace Comportamentos
{
    /// <summary>
    /// Representa um comportamento que remove objetos do jogo.
    /// </summary>
    public interface IRemovedor : IComandante
    {
        /// <summary>
        /// Um comando que remove objetos do jogo.
        /// </summary>
        public IComando ComandoRemover { get; }

        /// <summary>
        /// Remove um objeto do jogo.
        /// </summary>
        public void Remover();
    }
}
