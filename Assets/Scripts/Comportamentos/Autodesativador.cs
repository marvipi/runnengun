using System.Collections.Generic;
using UnityEngine;

namespace Comportamentos
{
    /// <summary>
    /// Permite que um objeto de jogo remova a árvore de objetos à qual ele pertence.
    /// </summary>
    public class Autodesativador : MonoBehaviour, IRemovivel
    {
        public Stack<IComando> HistoricoDeComandos { get; private set; }
        public IComando ComandoRemoverSe { get; private set; }

        private void Start()
        {
            Inicializar();
        }

        // Prepara este objeto para receber comandos.
        private void Inicializar()
        {
            HistoricoDeComandos = new Stack<IComando>();
            ComandoRemoverSe = gameObject.AddComponent<RemoverSe>();
        }

        /// <summary>
        /// Remove a árvore de objeto à qual este objeto pertence, delimitada pelo seu objeto pai mais próximo.
        /// </summary>
        public void RemoverSe()
        {
            ComandoRemoverSe.Executar(transform.parent.gameObject);
        }

        /// <summary>
        /// Coloca a árvore de objetos deste objeto de volta no jogo, delimitada pelo seu objeto pai mais próximo.
        /// </summary>
        public void Reverter()
        {
            ComandoRemoverSe.Reverter(transform.parent.gameObject);
        }


    }
}
