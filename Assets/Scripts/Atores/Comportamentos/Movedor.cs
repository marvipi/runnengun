using UnityEngine;

namespace Atores
{
    /// <summary>
    /// Representa um elemento do jogo que se move.
    /// </summary>
    /// <remarks>
    /// Para que um movedor funcione corretamente é necessário que o objeto pai imediato tenha um Rigidbody2D.
    /// </remarks>
    public abstract class Movedor : MonoBehaviour, IComandante
    {
        public Comandavel Pai { get; private protected set; }

        [field: SerializeField]
        [field: Tooltip("A velocidade com a qual um objeto de jogo se movimenta.")]
        public float Velocidade { get; private protected set; }

        /// <summary>
        /// Um comando que move um objeto adiante.
        /// </summary>
        private protected IMovimento comandoAvancar { get; set; }

        /// <summary>
        /// Um comando que altera o sentido do sprite de um objeto.
        /// </summary>
        private protected IAcao comandoVirar { get; set; }

        /// <summary>
        /// Move o objeto pai mais próximo adiante.
        /// </summary>
        public abstract void Avancar();

        /// <summary>
        /// Altera o sentido em que o objeto pai mais próximo é movido.
        /// </summary>
        public abstract void Virar();
    }
}
