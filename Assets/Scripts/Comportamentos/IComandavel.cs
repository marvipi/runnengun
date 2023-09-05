using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Comportamentos
{
    /// <summary>
    /// Permite que comandos sejam executados e registrados neste objeto.
    /// </summary>
    public interface IComandavel
    {
        /// <summary>
        /// Os últimos comandos executados neste objeto.
        /// </summary>
        public Stack<IComando> HistoricoDeComandos { get; }

        /// <summary>
        /// Registra que um comando foi executado neste objeto.
        /// </summary>
        /// <param name="comando"> Um comando que acaba de ser executado neste objeto. </param>
        public void Registrar(IComando comando);
    }
}
