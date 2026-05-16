using UnityEngine;

/// <summary>
/// Gerencia o ciclo de dia e noite no cenário, controlando a iluminação,
/// o material do céu (skybox) e a trilha sonora ambiente.
/// A transição ocorre quando o jogador entra no gatilho (Trigger) associado a este script.
/// </summary>
public class ControladorTempo : MonoBehaviour
{
    [Header("Iluminação do Cenário")]
    [Tooltip("Objeto que representa a luz direcional do Sol.")]
    public GameObject luzDoSol;
    [Tooltip("Objeto que representa a luz direcional da Lua.")]
    public GameObject luzDaLua;
    
    [Header("Os Céus (Skyboxes)")]
    [Tooltip("Material de Skybox usado durante o dia.")]
    public Material ceuDeDia;
    [Tooltip("Material de Skybox usado durante a noite.")]
    public Material ceuDeNoite;

    [Header("Áudio Ambiente")]
    [Tooltip("Fonte de áudio responsável por tocar a música ambiente.")]
    public AudioSource caixaDeSom;
    [Tooltip("Música de fundo tocada durante o dia.")]
    public AudioClip musicaDia;
    [Tooltip("Música de fundo tocada durante a noite.")]
    public AudioClip musicaNoite;

    // Controla o estado atual do ciclo (verdadeiro se for noite, falso se for dia).
    private bool estaDeNoite = false;

    void Start()
    {
        // Inicializa o ambiente com as configurações de "Dia" por padrão.
        // Realiza verificações de nulidade (null checks) para evitar erros caso algum componente não tenha sido atribuído no Inspector.
        if (luzDoSol != null) luzDoSol.SetActive(true);
        if (luzDaLua != null) luzDaLua.SetActive(false);
        
        // Configura o Skybox inicial acessando as configurações de renderização global da Unity.
        if (ceuDeDia != null) RenderSettings.skybox = ceuDeDia;

        if(caixaDeSom != null && musicaDia != null)
        {
            caixaDeSom.clip = musicaDia;
            caixaDeSom.Play();
        }
    }

    /// <summary>
    /// Detecta a entrada de objetos no colisor configurado como "Is Trigger".
    /// </summary>
    /// <param name="outro">O componente Collider do objeto que entrou na área.</param>
    void OnTriggerEnter(Collider outro)
    {
        // Verifica através da Tag se o objeto colidindo é de fato o jogador.
        if (outro.CompareTag("Player"))
        {
            // Inverte o estado atual do tempo. Se era dia (false), vira noite (true), e vice-versa.
            estaDeNoite = !estaDeNoite;

            if (estaDeNoite)
            {
                AtivarNoite();
            }
            else
            {
                AtivarDia();
            }
        }
    }

    /// <summary>
    /// Aplica todas as configurações visuais e sonoras correspondentes ao período da Noite.
    /// </summary>
    void AtivarNoite()
    {
        // Alterna o estado de ativação das luzes direcionais.
        if (luzDoSol != null) luzDoSol.SetActive(false);
        if (luzDaLua != null) luzDaLua.SetActive(true);
        
        // Substitui o material de renderização global do céu para o Skybox noturno.
        if (ceuDeNoite != null) RenderSettings.skybox = ceuDeNoite;

        if(caixaDeSom != null && musicaNoite != null)
        {
            // Atualiza o clipe de áudio para a trilha noturna e reinicia a reprodução.
            caixaDeSom.clip = musicaNoite;
            caixaDeSom.Play(); 
        }
    }

    /// <summary>
    /// Aplica todas as configurações visuais e sonoras correspondentes ao período do Dia.
    /// </summary>
    void AtivarDia()
    {
        // Alterna o estado de ativação das luzes direcionais.
        if (luzDoSol != null) luzDoSol.SetActive(true);
        if (luzDaLua != null) luzDaLua.SetActive(false);
        
        // Substitui o material de renderização global do céu para o Skybox diurno.
        if (ceuDeDia != null) RenderSettings.skybox = ceuDeDia;

        if(caixaDeSom != null && musicaDia != null)
        {
            // Atualiza o clipe de áudio para a trilha diurna e reinicia a reprodução.
            caixaDeSom.clip = musicaDia;
            caixaDeSom.Play(); 
        }
    }
}