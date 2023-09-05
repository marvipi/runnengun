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
        /// Registra a execução de um comando.
        /// </summary>
        /// <param name="comando"> O comando que deve ser registrado. </param>
        public void RegistarExecucao(IComando comando);
    }
}
