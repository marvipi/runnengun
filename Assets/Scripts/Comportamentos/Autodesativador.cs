using System.Collections.Generic;
using UnityEngine;

namespace Comportamentos
{
    /// <summary>
    /// Permite que um objeto de jogo remova a árvore de objetos à qual ele pertence.
    /// </summary>
    public class Autodesativador : MonoBehaviour, IRemovedor
    {
        public GameObject PaiObjeto { get; private set; }
        public IComandavel PaiComandavel { get; private set; }
        public IComando ComandoRemoverSe { get; private set; }


        private void Start()
        {
            Inicializar();
        }

        // Prepara este objeto para enviar e reverter comandos.
        private void Inicializar()
        {
            PaiObjeto = transform.parent.gameObject;
            PaiComandavel = PaiObjeto.GetComponent<IComandavel>();
            ComandoRemoverSe = gameObject.AddComponent<RemoverSe>();
        }

        /// <summary>
        /// Remove a árvore de objeto à qual este objeto pertence, delimitada pelo seu objeto pai mais próximo.
        /// </summary>
        public void RemoverSe()
        {
            // TODO Registar comando no PaiComandavel
            ComandoRemoverSe.Executar(PaiObjeto);
        }

        /// <summary>
        /// Coloca a árvore de objetos deste objeto de volta no jogo, delimitada pelo seu objeto pai mais próximo.
        /// </summary>
        public void Reverter()
        {
            // TODO Alterar o registro no PaiComandavel
            ComandoRemoverSe.Reverter(PaiObjeto);
        }
    }
}
