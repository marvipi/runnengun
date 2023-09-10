namespace Atores
{
    /// <summary>
    /// Permite que um objeto de jogo remova a árvore de objetos à qual ele pertence.
    /// </summary>
    public class Desativador : Removedor
    {
        private void Start()
        {
            Inicializar();
        }

        private void Inicializar()
        {
            Pai = transform.parent.gameObject.GetComponent<Comandavel>();
            ComandoRemover = gameObject.AddComponent<Desativar>();
        }

        /// <summary>
        /// Remove a árvore de objeto à qual este objeto pertence, delimitada pelo seu objeto pai mais próximo.
        /// </summary>
        public override void Remover()
        {
            // TODO Registar comando no PaiComandavel
            ComandoRemover.Executar(Pai);
        }

        /// <summary>
        /// Coloca a árvore de objetos deste objeto de volta no jogo, delimitada pelo seu objeto pai mais próximo.
        /// </summary>
        public void Reverter()
        {
            // TODO Alterar o registro no PaiComandavel
            ComandoRemover.Reverter(Pai);
        }
    }
}
