using UnityEngine;

namespace Atores
{
    /// <summary>
    /// Uma operação que move um objeto de jogo comandável em um determinado eixo.
    /// </summary>
    public class Avancar : MonoBehaviour, IMovimento
    {
        public uint QtdRepeticoes { get; private set; }

        /// <summary>
        /// Move o objeto comandável no eixo passado como argumento.
        /// </summary>
        /// <param name="comandavel"> O objeto que será movido. </param>
        /// <param name="eixo"> O eixo no qual o objeto será movido. </param>
        /// <param name="delta"> A quantidade de movimento e o sentido em que o objeto será movido. </param>
        /// <remarks> Pressupõe que o objeto de jogo tem um componente Rigidbody2D. </remarks>
        public void Executar(Comandavel comandavel, Eixo eixo, float delta)
        {
            Mover(comandavel.GetComponent<Rigidbody2D>(), eixo, delta);
            QtdRepeticoes++;
        }

        /// <summary>
        /// Reverte o último movimento realizado em um objeto.
        /// </summary>
        /// <remarks>
        /// Pressupõe que este <paramref name="delta"/> é o inverso do <paramref name="delta"/> da última execução.
        /// </remarks>
        /// <param name="comandavel"> O objeto que foi movido na última execução. </param>
        /// <param name="eixo"> O eixo no qual o objeto foi movido na última execução. </param>
        /// <param name="delta"> A quantidade de movimento e o sentido em que o objeto será movido. </param>
        /// <remarks> Pressupõe que o objeto de jogo tem um componente Rigidbody2D. </remarks>
        public void Reverter(Comandavel comandavel, Eixo eixo, float delta)
        {
            Mover(comandavel.GetComponent<Rigidbody2D>(), eixo, delta);
            QtdRepeticoes--;
        }

        // Move o rigidbody no dado eixo.
        private void Mover(Rigidbody2D rigidbody2D, Eixo eixo, float delta)
        {
            var transformDoComandavel = rigidbody2D.transform;
            Vector2 origem = transformDoComandavel.position;
            Vector2 destino;

            switch (eixo)
            {
                case Eixo.Horizontal:
                    destino = new Vector2(origem.x + delta, origem.y);
                    break;
                case Eixo.Vertical:
                    throw new System.NotImplementedException();
                case Eixo.Diagonal:
                    throw new System.NotImplementedException();
                default:
                    throw new System.NotSupportedException();
            }

            rigidbody2D.MovePosition(destino);
        }
    }
}
