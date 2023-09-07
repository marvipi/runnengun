using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Atores
{
    /// <summary>
    /// Representa uma operação que move um objeto no mundo do jogo.
    /// </summary>
    public interface IMovimento : IComando
    {
        /// <summary>
        /// Move um objeto de jogo adiante.
        /// </summary>
        /// <param name="comandavel"> O objeto que será movido. </param>
        /// <param name="delta"> A quantidade de movimento e o sentido em que o objeto será movido. </param>
        public void Executar(Comandavel comandavel, float delta);

        /// <summary>
        /// Desfaz o último movimento aplicado a um objeto.
        /// </summary>
        /// <param name="comandavel"> O objeto que foi movido na última execução. </param>
        /// <param name="delta"> A quantidade de movimento e o sentido em que o objeto foi movido na última execução. </param>
        public void Reverter(Comandavel comandavel, float delta);
    }
}
