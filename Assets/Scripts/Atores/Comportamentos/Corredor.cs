using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Atores
{
    /// <summary>
    /// Representa um elemento do jogo que se move horizontalmente.
    /// </summary>
    /// <remarks>
    /// Para que um corredor funcione corretamente, é necessário que o objeto pai imediato tenha cada um dos seguintes
    /// componentes:
    /// <list type="bullet">
    /// <item> <description> Rigidbody2D. </description></item>
    /// <item> <description> SpriteRenderer. </description></item>
    /// </list>
    /// </remarks>
    public class Corredor : Movedor
    {
        private void Start()
        {
            Inicializar();
        }

        private void Inicializar()
        {
            Pai = transform.parent.GetComponent<Comandavel>();
            comandoAvancar = gameObject.AddComponent<Avancar>();
            comandoVirar = gameObject.AddComponent<Virar>();
        }

        public override void Avancar()
        {
            comandoAvancar.Executar(Pai, Eixo.Horizontal, Velocidade);
        }

        public override void Virar()
        {
            comandoVirar.Executar(Pai);
        }
    }
}
