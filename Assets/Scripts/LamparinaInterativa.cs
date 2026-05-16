using UnityEngine;

/// <summary>
/// Controla a interatividade de uma lamparina, permitindo que o jogador
/// a acenda ou apague ao entrar na área de gatilho (Trigger).
/// </summary>
public class LamparinaInterativa : MonoBehaviour
{
    [Header("Componentes Visuais")]
    [Tooltip("Objeto de luz associado à lamparina.")]
    public Light luzDaLamparina;
    
    // Armazena o estado atual da lamparina (true para acesa, false para apagada).
    private bool lamparinaAcesa = false;

    /// <summary>
    /// Detecta a entrada de objetos no colisor (Trigger) da lamparina.
    /// </summary>
    /// <param name="outro">O componente Collider do objeto que entrou na área.</param>
    void OnTriggerEnter(Collider outro)
    {
        // Verifica se o objeto colidindo possui a Tag "Player".
        if (outro.CompareTag("Player"))
        {
            // Inverte o estado da lamparina a cada vez que o jogador interage
            lamparinaAcesa = !lamparinaAcesa;

            if (lamparinaAcesa)
            {
                // Liga a luz, com verificação de segurança (null check)
                if (luzDaLamparina != null) luzDaLamparina.gameObject.SetActive(true);
            }
            else
            {
                // Desliga a luz, com verificação de segurança (null check)
                if (luzDaLamparina != null) luzDaLamparina.gameObject.SetActive(false);
            }
        }
    }
}