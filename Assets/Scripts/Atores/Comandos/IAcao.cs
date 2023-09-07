namespace Atores
{
    /// <summary>
    /// Representa uma operação que sempre tem o mesmo efeito, independente do <see cref="IComandante"/> que o invocou.
    /// </summary>
    public interface IAcao : IComando
    {
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
