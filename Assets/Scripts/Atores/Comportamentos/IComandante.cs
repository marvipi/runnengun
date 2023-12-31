namespace Atores
{
    /// <summary>
    /// Permite que um objeto de jogo envie e reverta comandos para o seu pai imediato.
    /// </summary>
    public interface IComandante
    {
        /// <summary>
        /// O objeto pai mas próximo deste objeto na hierarquia da cena.
        /// </summary>
        public Comandavel Pai { get; }
    }
}
