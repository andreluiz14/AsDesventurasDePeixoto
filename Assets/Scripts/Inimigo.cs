
using UnityEngine;

[RequireComponent(typeof(TopDownCharacterMotor))]
public class Inimigo : MonoBehaviour
{

    enum Estado
    {
        Patrulha, Perseguicao
    }

    private Vector2 alvo;
    private Vector2 ultimoAlvo;
    private Estado estadoAtual;

    [SerializeField]
    private float raioVisao;
    [SerializeField]
    private float anguloVisao = 120f;

    [SerializeField]
    private LayerMask layerAreaVisao;

    [SerializeField]
    private float velocidadeMovimento;

    [SerializeField]
    private float distanciaMinima;

    private TopDownCharacterMotor motor;
    private PathSeeker seeker;

    [SerializeField]
    private GameObject seekLight;

    private void Start()
    {
        motor = GetComponent<TopDownCharacterMotor>();
        seeker = GetComponent<PathSeeker>();
        estadoAtual = Estado.Patrulha;
        seekLight.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        ProcurarJogador();
        switch (estadoAtual)
        {
            case Estado.Patrulha:
                Patrulhar();
                break;
            case Estado.Perseguicao:
                Perseguir();
                break;
        }

    }

    // N�o sabe onde o player est�; vaga por a�
    private void Patrulhar()
    {
        motor.SetRunning(false);
        if (seeker.reachedEndOfPath)
        {
            alvo = (Vector2)transform.position + new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
            seeker.SetTarget(alvo);
        }
    }

    // Sabe onde o player est�/esteve; vai at� a posi��o
    private void Perseguir()
    {
        motor.SetRunning(true);
        Vector2 posicaoAlvo = this.alvo;
        Vector2 posicaoAtual = this.transform.position;

        float distancia = Vector2.Distance(posicaoAtual, posicaoAlvo);

        // Chegou at� a ultima posi��o do player e n�o o achou, volta a patrulhar
        if (seeker.reachedEndOfPath)
        {
            estadoAtual = Estado.Patrulha;
            seekLight.SetActive(false);
        }
    }

    public void AlertaPlayer(Transform player)
    {
        estadoAtual = Estado.Perseguicao;
        alvo = player.position;
        seeker.SetTarget(alvo);
        seekLight.SetActive(true);
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Vector3 leftRay = Quaternion.AngleAxis(-anguloVisao / 2, transform.forward) * transform.up;
            Vector3 rightRay = Quaternion.AngleAxis(anguloVisao / 2, transform.forward) * transform.up;
            Gizmos.DrawRay(transform.position, leftRay * raioVisao);
            Gizmos.DrawRay(transform.position, rightRay * raioVisao);
        }
    }


    private void ProcurarJogador()
    {
        Collider2D colisor = Physics2D.OverlapCircle(this.transform.position, this.raioVisao, this.layerAreaVisao);
        if (!colisor)
        {
            this.alvo = ultimoAlvo;
            return;
        }

        Vector2 posicaoAtual = this.transform.position;
        Vector2 posicaoAlvo = colisor.transform.position;
        Vector2 direcaoAlvo = posicaoAlvo - posicaoAtual;
        direcaoAlvo = direcaoAlvo.normalized;

        float angleToTarget = Vector2.Angle(this.transform.up, direcaoAlvo);
        if (angleToTarget > this.anguloVisao) return;

        RaycastHit2D hit = Physics2D.Raycast(posicaoAtual, direcaoAlvo);
        if (hit.transform && hit.transform.CompareTag("Player"))
        {
            estadoAtual = Estado.Perseguicao;
            this.alvo = hit.transform.position;
            seekLight.SetActive(true);
        }
        else
        {
            this.alvo = ultimoAlvo;
        }
        if (alvo != ultimoAlvo)
        {
            seeker.SetTarget(alvo);
            ultimoAlvo = this.alvo;
        }
    }
}