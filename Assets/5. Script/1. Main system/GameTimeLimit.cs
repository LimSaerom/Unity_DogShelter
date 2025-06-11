using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimeLimit : MonoBehaviour
{
    public float timeLimit;           //���ѽð� ���۰�(�̴ϰ��Ӻ��� ���� �ð��� ������ public ����)
    Text timeText;             // UI �ؽ�Ʈ ������Ʈ

    void Start()
    {
        timeText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLimit -= Time.deltaTime;

        int timeLimitInt = Mathf.CeilToInt(timeLimit); // �Ҽ��� ���ϸ� �ø��Ͽ� ������ ��ȯ
        timeText.text = "TimeLimit : " + timeLimitInt.ToString(); // �Ҽ��� ���ϸ� ������ ������ ��ȯ �� ���

        if (timeLimitInt <= 0)
        {
            timeText.text = "0";
            //���ѽð��� ������ �������� ��µǴ� ���� �߻��Ͽ� ���������� 0 ǥ��
        }
        if (timeLimitInt <= 0)
        {
            timeLimit = 0;           //���ѽð��� ������ �������� ��µǴ� ���� �߻��Ͽ� ���������� 0 ǥ��
            timeText.text = "���ѽð� �ʰ�";
            //���ѽð��� ������ �������� ��µǴ� ���� �߻��Ͽ� ���������� 0 ǥ��
        }

    }
}
