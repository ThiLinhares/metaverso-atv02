<h1 align="center">🏕️ Meu_Acampamento: Experiência VR Interativa</h1>

<p align="center">
  <img src="https://img.shields.io/badge/Unity-6-000000?style=for-the-badge&logo=unity&logoColor=white" alt="Unity 6" />
  <img src="https://img.shields.io/badge/URP-Pipeline-blue?style=for-the-badge" alt="URP" />
  <img src="https://img.shields.io/badge/Meta_XR-SDK-0467DF?style=for-the-badge&logo=meta&logoColor=white" alt="Meta XR" />
  <img src="https://img.shields.io/badge/Plataforma-Android%20%7C%20Quest-3DDC84?style=for-the-badge&logo=android&logoColor=white" alt="Android" />
</p>

> **Portfólio Técnico - Engenharia de Software & XR**  
> Projeto desenvolvido como requisito final e demonstração de proficiência em desenvolvimento imersivo e boas práticas de estruturação de projeto na Unity.

---

## 📋 1. Informações Acadêmicas

| Dado | Detalhe |
| :--- | :--- |
| **Estudante** | Thiago Linhares |
| **Curso** | Residência em TIC 29 - Web 3.0 |
| **Módulo** | Fundamentos do Metaverso: Criando sua Primeira Experiência VR Interativa |

## 🌌 2. Contexto do Metaverso & Proposta

- **Nome da Cena:** `Meu_Acampamento`
- **Tema:** Simulação e Área de Treinamento de Sobrevivência/Entretenimento no Metaverso.
- **Descrição:** Um cenário tridimensional imersivo de alta fidelidade e otimizado para dispositivos standalone (Meta Quest). O ambiente representa um acampamento florestal estruturado com barracas, fogueiras interativas, vegetação densa, rochas, cercados e áreas delimitadas para navegação restrita e focada.

## ⚙️ 3. Configuração Técnica e Setup XR

O projeto adota padrões de mercado para o desenvolvimento de Realidade Virtual:

*   **Engine:** Unity 6 utilizando o **Universal Render Pipeline (URP)** para balancear performance e qualidade visual em hardware móvel.
*   **SDK VR:** Meta XR SDK integrado e configurado nativamente para a plataforma **Android** (Target principal: Meta Quest).
*   **Gerenciamento:** *XR Plugin Management* ativado, garantindo compatibilidade multiplataforma nativa.
*   **Locomoção:** Implementação baseada no *First Person Controller*, refatorado e calibrado para garantir testes ágeis no Unity Editor (PC) e movimentação confortável em ambiente imersivo.

## 🗂️ 4. Arquitetura e Hierarquia da Cena

A cena foi estruturada com foco em **Clean Architecture** e **Manutenibilidade**, utilizando *containers* lógicos (GameObjects vazios) para evitar o acúmulo e desorganização de *assets* na raiz da hierarquia, permitindo escalabilidade a nível industrial:

```text
Hierarchy (Cena: Meu_Acampamento)
├── ── GERENCIADORES ──               # Scripts de controle de fluxo, instâncias e áudio global
├── ── ILUMINAÇÃO & SETUP ──          # Sol_Principal (Directional Light) e Global Volume (URP)
├── Ambiente_acampamento              # [Container Principal do Cenário]
│   ├── Terreno_e_Agua                # Geometria do solo e shaders de fluídos
│   ├── Vegetacao_e_rochas            # Flora, pedras e props naturais (Batching Ativo)
│   ├── Props_Acampamento             # Interagíveis, barracas e fogueiras
│   └── Barreiras_Invisiveis          # Colisores primitivos para contenção do jogador (Level Design)
└── PlayerCapsule                     # Instância do Jogador (Câmeras XR e Locomotion Controls)
```

## 🐛 5. Root Cause Analysis (RCA) e Desafios Técnicos

Durante o ciclo de desenvolvimento, processos contínuos de *Quality Assurance (QA)* identificaram anomalias técnicas que foram prontamente analisadas e mitigadas:

| Categoria | Sintoma (Desafio Encontrado) | Causa Raiz (Análise - RCA) | Solução e Fix Aplicado |
| :--- | :--- | :--- | :--- |
| **Renderização & Iluminação** | *Color Bleeding:* As sombras do cenário apresentavam um vazamento excessivo de cor azul artificial, afetando a imersão. | O material padrão do Skybox estava saturando a iluminação indireta (Ambient Light) via Environment Lighting. | A fonte de *Environment Lighting* foi alterada de *Skybox* para *Color* (com tom cinza/neutro). O *Intensity Multiplier* foi reduzido para `0.5` e o GameObject `Sol_Principal` foi ajustado para um tom quente (âmbar) com intensidade `2.0` e *Soft Shadows*. |
| **Mecânica & UX Física** | Quebra de level design: O personagem conseguia pular os cercados da área de treinamento de sobrevivência. | O *First Person Controller* nativo possuía a física de pulo habilitada via parâmetros globais, para uso genérico em testes. | Intervenção via Inspector no componente do jogador, isolando a mecânica ao reconfigurar a variável `Jump Height` estritamente para `0`, ancorando a navegação no solo. |
| **Versionamento (Git / CI)** | Falha no primeiro *push* após commit local (Erro: `[rejected] main -> main (fetch first)`). | Divergência de histórico. O repositório remoto foi inicializado com um README distinto da árvore (ecosistema local) gerada pelo Unity. | Resolução arquitetural via CLI (`git bash`), forçando a fusão de árvores utilizando a flag `git pull origin main --allow-unrelated-histories`, seguido do acerto de index e novo `push`. |

## 🚀 6. Como Executar o Projeto Localmente

> ⚠️ **Prática de Clean Repository (Importante):** Este repositório está instrumentado com um `.gitignore` rigoroso para Unity. Isso significa que pastas pesadas de build e cache (como `Library/` e `Temp/`) não estão versionadas. A Unity reconstruirá a pasta `Library` automaticamente no seu primeiro acesso local. Esse processo inicial pode levar alguns minutos.

1. Certifique-se de ter a **Unity 6** instalada através do **Unity Hub**.
2. Clone o repositório em seu ambiente local:
   ```bash
   git clone https://github.com/ThiLinhares/metaverso-atv02
   ```
3. Abra o Unity Hub, clique em **Add** (Adicionar) e selecione a pasta recém-clonada.
4. Uma vez que o projeto carregar, navegue até o Project Browser e abra a cena principal na pasta `Assets/Scenes/`.
5. *(Opcional)* Conecte seu headset Meta Quest utilizando Link Cable ou Air Link para visualizar em VR em tempo real.
6. Clique no botão **Play** ▶️ no topo do Unity Editor para iniciar a experiência.

---
*Projetado e desenvolvido por Thiago Linhares.*