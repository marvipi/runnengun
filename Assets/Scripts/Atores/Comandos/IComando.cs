using UnityEngine;

namespace Atores
{
    /// <summary>
    /// Representa uma ação reversível que pode ser executada por objetos de jogo.
    /// </summary>
    public interface IComando
    {
        /// <summary>
        /// Indica quantas vezes este comando foi executado sucessivamente em um objeto de jogo.
        /// </summary>
        public uint QtdRepeticoes { get; }

        /// <summary>
        /// Executa este comando no objeto de jogo passado como argumento.
        /// </summary>
        public void Executar(Comandavel comandavel);

        /// <summary>
        /// Reverte as mudanças causadas pela última execução deste comando no objeto de jogo passado como argumento.
        /// </summary>
        public void Reverter(Comandavel comandavel);
    }
}
