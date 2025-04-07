using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class ArrowController : MonoBehaviour
{
    GameObject player;
    GameObject director;
    float dropSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.player = GameObject.Find("player_0");
    }

    // Update is called once per frame
    void Update()
    {
        dropSpeed += -0.1f * GameDirector.Instance.CalculateGameSpeed(); //���ӵ��Ϳ��� ���� �ӵ��� ������ �� �ֵ��� �Ѵ�

        //�����Ӹ��� ������� ���Ͻ�Ų��.
        transform.Translate(0, dropSpeed, 0);

        //ȭ�� ������ ������ ������Ʈ�� �ı���Ų��
        if(transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        if (player == null)
        {
            return;
        }

        //�浹����
        Vector2 p1 = transform.position;//ȭ���� �߽� ��ǥ
        Vector2 p2 = this.player.transform.position;//�÷��̾��� �߽� ��ǥ
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;//ȭ���� ������
        float r2 = 1.0f;//�÷��̾��� ������

        if(d<r1 + r2)
        {
            director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();

            Destroy (gameObject);
        }
    }
}
