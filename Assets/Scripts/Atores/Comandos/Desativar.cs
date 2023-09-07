using UnityEngine;

namespace Atores
{
    /// <summary>
    /// Remove um objeto e todos os filhos dele do jogo, impedindo que eles interajam com os outros objetos.
    /// </summary>
    public class Desativar : MonoBehaviour, IComando
    {
        public uint QtdRepeticoes { get; private set; }

        /// <summary>
        /// Remove o objeto de jogo passado como argumento e todos os filhos dele.
        /// </summary>
        public void Executar(Comandavel comandavel)
        {
            var objetoComandavel = comandavel.gameObject;
            if (!objetoComandavel.activeInHierarchy)
            {
                return;
            }
            objetoComandavel.SetActive(false);
            QtdRepeticoes += 1;
        }

        /// <summary>
        /// Adiciona o objeto passado como argumento de volta ao jogo
        /// </summary>
        public void Reverter(Comandavel comandavel)
        {
            var objetoComandavel = comandavel.gameObject;
            if (objetoComandavel.activeInHierarchy || QtdRepeticoes == 0)
            {
                return;
            }
            objetoComandavel.SetActive(true);
            foreach (Transform filho in objetoComandavel.transform)
            {
                filho.gameObject.SetActive(true);
            }
            QtdRepeticoes -= 1;
        }
    }
}
