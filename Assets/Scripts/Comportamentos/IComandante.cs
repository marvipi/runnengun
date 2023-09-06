using System.Collections.Generic;
using UnityEngine;

namespace Comportamentos
{
    /// <summary>
    /// Permite que um objeto de jogo envie e reverta comandos para o seu pai imediato.
    /// </summary>
    public interface IComandante
    {
        /// <summary>
        /// O objeto pai mais próximo deste objeto na hierarquia da cena.
        /// </summary>
        public GameObject PaiObjeto { get; }

        /// <summary>
        /// Um componente IComandavel que faz parte do <see cref="PaiObjeto"/>.
        /// </summary>
        public Comandavel PaiComandavel { get; }
    }
}
