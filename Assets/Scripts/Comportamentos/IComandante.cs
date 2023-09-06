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
        /// O objeto pai mas próximo deste objeto.
        /// </summary>
        public Comandavel Pai { get; }
    }
}
