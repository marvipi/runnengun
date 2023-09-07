using UnityEngine;

namespace Atores
{
    /// <summary>
    /// Representa uma operação reversível que pode ser executada em objetos de jogo comandáveis.
    /// </summary>
    public interface IComando
    {
        /// <summary>
        /// Indica quantas vezes este comando foi executado sucessivamente.
        /// </summary>
        public uint QtdRepeticoes { get; }

        /// <summary>
        /// Executa este comando no objeto de jogo comandável passado como argumento.
        /// </summary>
        public void Executar(Comandavel comandavel);

        /// <summary>
        /// Reverte as mudanças causadas pela última execução deste comando no objeto de jogo comandável passado como argumento.
        /// </summary>
        public void Reverter(Comandavel comandavel);
    }
}
