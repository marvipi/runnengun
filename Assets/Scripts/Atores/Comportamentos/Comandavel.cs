using System.Collections.Generic;
using UnityEngine;

namespace Atores
{
    /// <summary>
    /// Permite que comandos sejam executados, registrados e revertidos neste objeto.
    /// </summary>
    public abstract class Comandavel : MonoBehaviour
    {
        /// <summary>
        /// Os últimos comandos executados neste objeto.
        /// </summary>
        private Stack<IComando> HistoricoDeComandos { get; set; }

        private protected void InicializarHistoricoDeComandos() => HistoricoDeComandos = new();

        /// <summary>
        /// Registra que um comando foi executado neste objeto.
        /// </summary>
        /// <param name="comando"> Um comando que acaba de ser executado neste objeto. </param>
        public void Registrar(IComando comando)
        {
            throw new System.NotImplementedException();
        }

        private protected IComando UltimoComandoExecutado()
        {
            throw new System.NotImplementedException();
        }

        private protected void ReverterTodosComandos()
        {
            throw new System.NotImplementedException();
        }
    }
}
