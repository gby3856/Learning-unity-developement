using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void LButton()
    {
        transform.Translate(-3,0,0);
    }

    public void RButton()
    {
        transform.Translate(3, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        //���� ȭ��Ű ������ ��
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-3,0,0); //�������� 3 �����δ�
        }

        //������ ȭ��Ű ������ ��
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(3,0,0);
        }
    }
}
