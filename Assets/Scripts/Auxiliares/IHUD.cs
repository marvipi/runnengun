using TMPro;

namespace Auxiliares
{
    /// <summary>
    /// Permite que um Canvas exiba o estado de um jogador.
    /// </summary>
    public interface IHUD
    {
        /// <summary>
        /// O formato que o label que exibe as vidas deve ter.
        /// </summary>
        public const string FORMATO_VIDAS = "{0}";

        /// <summary>
        /// O formato que o label que exibe da pontuação deve ter.
        /// </summary>

        public const string FORMATO_PONTUACAO = "${0}";

        /// <summary>
        /// Indica qual elemento do HUD mostra as vidas de um jogador.
        /// </summary>
        public string TagLabelVidas { get; }

        /// <summary>
        /// Indica qual elemento do HUD mostra a pontuação de um jogador.
        /// </summary>
        public string TagLabelPontuacao { get; }

        /// <summary>
        /// O elemento da interface que mostra as vidas de um jogador.
        /// </summary>
        public TextMeshProUGUI LabelVidas { get; }

        /// <summary>
        /// O elemento da interface que mostra a pontuação de um jogador.
        /// </summary>
        public TextMeshProUGUI LabelPontuacao { get; }

        /// <summary>
        /// Exibe uma quantidade de vidas na interface de usuário.
        /// </summary>
        /// <param name="qtdVidas"> A quantidade de vidas para exibir. </param>
        public void Atualizar(byte qtdVidas);

        /// <summary>
        /// Exibe uma quantidade de pontos na interface de usuário.
        /// </summary>
        /// <param name="qtdPontos"> A quantidade de pontos para exibir. </param>
        public void Atualizar(uint qtdPontos);
    }
}
