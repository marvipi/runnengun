using UnityEngine;

namespace Comportamentos
{
    /// <summary>
    /// Remove um objeto e todos os filhos dele do jogo, impedindo que eles interajam com os outros objetos.
    /// </summary>
    public class Remover : MonoBehaviour, IComando
    {
        public uint QtdRepeticoes { get; private set; }

        /// <summary>
        /// Remove o objeto de jogo passado como argumento e todos os filhos dele.
        /// </summary>
        public void Executar(GameObject gameObject)
        {
            if (!gameObject.activeInHierarchy)
            {
                return;
            }
            gameObject.SetActive(false);
            QtdRepeticoes += 1;
        }

        /// <summary>
        /// Adiciona o objeto passado como argumento de volta ao jogo
        /// </summary>
        public void Reverter(GameObject gameObject)
        {
            if (gameObject.activeInHierarchy || QtdRepeticoes == 0)
            {
                return;
            }
            gameObject.SetActive(true);
            foreach (Transform filho in gameObject.transform)
            {
                filho.gameObject.SetActive(true);
            }
            QtdRepeticoes -= 1;
        }
    }
}
