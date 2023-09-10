using TMPro;
using UnityEngine;

namespace Auxiliares
{
    /// <summary>
    /// Permite que a interface de usuário reflita o estado interno do jogador 1.
    /// </summary>
    public class HUDJogador1 : MonoBehaviour, IHUD
    {
        public TextMeshProUGUI LabelVidas { get; private set; }
        public TextMeshProUGUI LabelPontuacao { get; private set; }

        [SerializeField]
        [Tooltip("A tag que indica qual elemento do canvas exibe as vidas do jogador 1")]
        private string tagLabelVidas = "VidasJogador1";
        public string TagLabelVidas { get => tagLabelVidas; private set => tagLabelVidas = value; }

        [SerializeField]
        [Tooltip("A tag que indica qual elemento do canvas exibe a pontuação do jogador 1")]
        private string tagLabelPontuacao = "PontuacaoJogador1";
        public string TagLabelPontuacao { get => tagLabelPontuacao; private set => tagLabelPontuacao = value; }

        private void Start()
        {
            Inicializar();
        }

        // Inicializa os componentes do HUD para que eles possam ser atualizados.
        private void Inicializar()
        {
            LabelVidas = EncontrarLabel(TagLabelVidas);
            if (LabelVidas is null)
            {
                throw new System.NotSupportedException("O HUD deve conter um label com a tag " + TagLabelVidas + ".");
            }

            LabelPontuacao = EncontrarLabel(TagLabelPontuacao);
            if (LabelPontuacao is null)
            {
                throw new System.NotSupportedException("O HUD deve conter um label com a tag " + TagLabelPontuacao + ".");
            }
        }

        private TextMeshProUGUI EncontrarLabel(string tag)
        {
            foreach (Transform filho in gameObject.transform)
            {
                if (filho.CompareTag(tag))
                {
                    return filho.GetComponent<TextMeshProUGUI>();
                }
            }
            return null;
        }

        /// <summary>
        /// Atualiza a interface de usuário com a quantidade de vidas do jogador.
        /// </summary>
        /// <param name="qtdVidas"> A quantidade de vidas do jogador. </param>
        public void Atualizar(byte qtdVidas)
        {
            LabelVidas.text = string.Format(IHUD.FORMATO_VIDAS, qtdVidas);
        }

        /// <summary>
        /// Atualiza a interface de usuário com a pontuação do jogador.
        /// </summary>
        /// <param name="qtdPontos"> A quantidade de pontos que um jogador tem. </param>
        public void Atualizar(uint qtdPontos)
        {
            LabelPontuacao.text = string.Format(IHUD.FORMATO_PONTUACAO, qtdPontos);
        }
    }
}
