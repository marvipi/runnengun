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
    }
}
