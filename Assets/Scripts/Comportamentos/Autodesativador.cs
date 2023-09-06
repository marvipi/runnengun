using System.Collections.Generic;
using UnityEngine;

namespace Comportamentos
{
    /// <summary>
    /// Permite que um objeto de jogo remova a árvore de objetos à qual ele pertence.
    /// </summary>
    public class Autodesativador : Removedor
    {
        private void Start()
        {
            Inicializar();
        }

        private protected override void Inicializar()
        {
            PaiObjeto = transform.parent.gameObject;
            PaiComandavel = PaiObjeto.GetComponent<Comandavel>();
            ComandoRemover = gameObject.AddComponent<Remover>();
        }

        /// <summary>
        /// Remove a árvore de objeto à qual este objeto pertence, delimitada pelo seu objeto pai mais próximo.
        /// </summary>
        public override void Remover()
        {
            // TODO Registar comando no PaiComandavel
            ComandoRemover.Executar(PaiObjeto);
        }

        /// <summary>
        /// Coloca a árvore de objetos deste objeto de volta no jogo, delimitada pelo seu objeto pai mais próximo.
        /// </summary>
        public void Reverter()
        {
            // TODO Alterar o registro no PaiComandavel
            ComandoRemover.Reverter(PaiObjeto);
        }
    }
}
