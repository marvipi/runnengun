using UnityEngine;

namespace Comportamentos
{
    /// <summary>
    /// Permite que objetos se removam do jogo.
    /// </summary>
    public interface IRemovedor : IComandante
    {
        /// <summary>
        /// Um comando que remove objetos do jogo.
        /// </summary>
        public IComando ComandoRemoverSe { get; }

        /// <summary>
        /// Remove este objeto do jogo.
        /// </summary>
        public void RemoverSe();
    }
}
