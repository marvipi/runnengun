using UnityEngine;

namespace Atores
{
    /// <summary>
    /// Uma operação que altera o sentido do sprite de um objeto.
    /// </summary>
    public class Virar : MonoBehaviour, IAcao
    {
        public uint QtdRepeticoes { get; private set; }

        /// <summary>
        /// Inverte o sentido do sprite de um objeto de jogo comandável.
        /// </summary>
        /// <param name="comandavel"> O objeto de jogo que será virado. </param>
        /// <remarks> Pressupõe que <paramref name="comandavel"/> tem um componente <see cref="SpriteRenderer"/>. </remarks>
        public void Executar(Comandavel comandavel)
        {
            InverterSprite(comandavel.gameObject);
            QtdRepeticoes++;
        }

        /// <summary>
        /// Reverte o sentido do sprite de um objeto de jogo comandável, retornando-o para o estado anterior à última
        /// execução.
        /// </summary>
        /// <param name="comandavel"> O objeto de jogo que foi virado durante a última execução. </param>
        /// <remarks> Pressupõe que <paramref name="comandavel"/> tem um componente <see cref="SpriteRenderer"/>. </remarks>
        public void Reverter(Comandavel comandavel)
        {
            InverterSprite(comandavel.gameObject);
            QtdRepeticoes--;
        }

        // Inverte o sentido do sprite de um objeto de jogo.
        private void InverterSprite(GameObject comandavel)
        {
            var spriteRenderer = comandavel.GetComponent<SpriteRenderer>();
            spriteRenderer.flipY = !spriteRenderer.flipY;
        }
    }
}
