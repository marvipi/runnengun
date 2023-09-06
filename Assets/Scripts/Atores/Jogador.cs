using Comportamentos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Atores
{
    /// <summary>
    /// Representa um objeto de jogo que pode ser controlado pela pessoa que está jogando.
    /// <para>
    ///     Cada jogador tem:
    ///     <list type="bullet">
    ///     <item><description> De 0 a 3 vidas. </description></item>
    ///     <item><description> De 0 a Uint32.MaxValue pontos. </description></item>
    ///     </list>
    /// </para>
    /// <para>
    ///     Mecânicas do jogador:
    ///     <list type="bullet">
    ///     <item><description> Morre quando colide com inimigos. </description></item>
    ///     <item><description> Game over quando vidas chegarem a 0. </description></item>
    ///     <item><description> Ganha uma vida a cada mil pontos atingidos. </description></item>
    ///     <item><description> Ganha pontos matando inimigos. </description></item>
    ///     </list>
    /// </para>
    /// </summary>
    public abstract class Jogador : Comandavel
    {
        // TODO
    }
}
