using UnityEngine;

/// <summary>
/// Exibe e oculta um painel (como um balão de diálogo ou mensagem de boas-vindas)
/// quando o jogador entra ou sai da área do gatilho (Trigger).
/// </summary>
public class PainelInterativo : MonoBehaviour
{
    [Header("Interface de Usuário (UI)")]
    [Tooltip("Objeto que contém a mensagem ou painel a ser exibido (ex: Canvas ou Sprite).")]
    public GameObject balaoDeBoasVindas;

    void Start()
    {
        // Garante que a mensagem comece escondida quando o jogo iniciar,
        // utilizando null check para evitar erros se o objeto não for referenciado.
        if (balaoDeBoasVindas != null) balaoDeBoasVindas.SetActive(false);
    }

    /// <summary>
    /// Acionado quando um objeto entra no gatilho.
    /// </summary>
    /// <param name="outro">Collider do objeto que entrou.</param>
    void OnTriggerEnter(Collider outro)
    {
        // Verifica se quem pisou na área foi o jogador
        if (outro.CompareTag("Player"))
        {
            // Exibe a mensagem de forma segura
            if (balaoDeBoasVindas != null) balaoDeBoasVindas.SetActive(true);
        }
    }

    /// <summary>
    /// Acionado quando um objeto sai do gatilho.
    /// </summary>
    /// <param name="outro">Collider do objeto que saiu.</param>
    void OnTriggerExit(Collider outro)
    {
        // Verifica se quem saiu da área foi o jogador
        if (outro.CompareTag("Player"))
        {
            // Oculta a mensagem de forma segura
            if (balaoDeBoasVindas != null) balaoDeBoasVindas.SetActive(false);
        }
    }
}