using UnityEngine;

/// <summary>
/// Gerencia a interatividade de uma fogueira, permitindo que o jogador
/// acenda ou apague o fogo ao entrar na área de colisão (Trigger).
/// Controla a emissão de luz, partículas visuais e efeitos sonoros.
/// </summary>
public class FogueiraInterativa : MonoBehaviour
{
    [Header("Componentes Visuais")]
    [Tooltip("Luz associada à fogueira para iluminar o ambiente.")]
    public Light luzDaFogueira;
    [Tooltip("Sistema de partículas que simula as chamas e a fumaça.")]
    public ParticleSystem fogoParticulas;
    
    [Header("Componentes de Áudio")]
    [Tooltip("Fonte de áudio que reproduz o som do fogo crepitando.")]
    public AudioSource somDaFogueira;

    // Armazena o estado atual da fogueira (true para acesa, false para apagada).
    private bool fogueiraAcesa = false;

    /// <summary>
    /// Detecta quando um objeto entra na área do colisor configurado como "Is Trigger".
    /// </summary>
    /// <param name="outro">O componente Collider do objeto invasor.</param>
    void OnTriggerEnter(Collider outro)
    {
        // Verifica através da Tag se o objeto que ativou o gatilho é o jogador.
        if (outro.CompareTag("Player"))
        {
            // Inverte o estado da fogueira a cada interação (liga se estava desligada e vice-versa).
            fogueiraAcesa = !fogueiraAcesa;

            if (fogueiraAcesa)
            {
                // Ativa os componentes visuais e sonoros com verificações de segurança (null checks).
                if (luzDaFogueira != null) luzDaFogueira.gameObject.SetActive(true);
                
                if (fogoParticulas != null)
                {
                    fogoParticulas.gameObject.SetActive(true);
                    fogoParticulas.Play();
                }
                
                if (somDaFogueira != null) somDaFogueira.Play(); 
            }
            else
            {
                // Desativa a emissão de luz.
                if (luzDaFogueira != null) luzDaFogueira.gameObject.SetActive(false);
                
                // Interrompe a emissão de novas partículas.
                // Nota: Usar apenas Stop() permite que as partículas existentes desapareçam gradualmente de forma mais realista.
                if (fogoParticulas != null) fogoParticulas.Stop();
                
                // Interrompe a reprodução do áudio.
                if (somDaFogueira != null) somDaFogueira.Stop(); 
            }
        }
    }
}