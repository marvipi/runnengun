using UnityEngine;

namespace Comportamentos
{
    /// <summary>
    /// Representa um comportamento que remove objetos do jogo.
    /// </summary>
    public abstract class Removedor : MonoBehaviour, IComandante
    {
        public GameObject PaiObjeto { get; private protected set; }
        public Comandavel PaiComandavel { get; private protected set; }

        /// <summary>
        /// Um comando que remove objetos do jogo.
        /// </summary>
        private protected IComando ComandoRemover { get; set; }

        /// <summary>
        /// Remove um objeto do jogo.
        /// </summary>
        public abstract void Remover();

        /// <summary>
        /// Inicializa todas as referências necessários para o funcionamento deste comportamento.
        /// </summary>
        private protected abstract void Inicializar();
    }
}
