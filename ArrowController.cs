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
        dropSpeed += -0.1f * GameDirector.Instance.CalculateGameSpeed(); //게임디렉터에서 낙하 속도를 조절할 수 있도록 한다

        //프레임마다 등속으로 낙하시킨다.
        transform.Translate(0, dropSpeed, 0);

        //화면 밖으로 나가면 오브젝트를 파괴시킨다
        if(transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        if (player == null)
        {
            return;
        }

        //충돌판정
        Vector2 p1 = transform.position;//화살의 중심 좌표
        Vector2 p2 = this.player.transform.position;//플레이어의 중심 좌표
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;//화살의 반지름
        float r2 = 1.0f;//플레이어의 반지름

        if(d<r1 + r2)
        {
            director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();

            Destroy (gameObject);
        }
    }
}
