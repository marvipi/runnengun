using System.Collections.Generic;
using UnityEngine;

namespace Comportamentos
{
    /// <summary>
    /// Permite que um objeto de jogo execute e reverta todos os comandos atribuidos a ele.
    /// </summary>
    public interface IComandavel
    {
        /// <summary>
        /// Contém os últimos comandos executados por este objeto.
        /// </summary>
        public Stack<IComando> HistoricoDeComandos { get; }

        /// <summary>
        /// Reverte os últimos comandos executados por este objeto.
        /// </summary>
        public void Reverter();
    }
}
