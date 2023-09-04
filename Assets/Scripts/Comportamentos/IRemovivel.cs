using UnityEngine;

namespace Comportamentos
{
    /// <summary>
    /// Permite que objetos se removam do jogo.
    /// </summary>
    public interface IRemovivel : IComandavel
    {
        /// <summary>
        /// A sequência de operações que este objeto executa para se remover do jogo.
        /// </summary>
        public IComando ComandoRemoverSe { get; }

        /// <summary>
        /// Remove este objeto do jogo.
        /// </summary>
        public void RemoverSe();
    }
}
