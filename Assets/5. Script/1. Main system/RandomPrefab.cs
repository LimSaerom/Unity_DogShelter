using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPrefab : MonoBehaviour
{
    public GameObject newPrefab;
    public float intervalSec = 2.0f;
    float timer;

    private void Start()
    {
        InvokeRepeating("CreatePrefab", intervalSec, intervalSec);             //시작과 최초생성간격, 생성간격
        
    }


    /********** 시간이 지나면 Prefab 생성속도 UP **********/
    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 10f)
        {
            intervalSec -= 0.2f;
            Debug.Log("10초 경과, 생성속도 조정" + intervalSec);
            timer = 0.0f;            //타이머초기화
        }


        if (intervalSec == 0.5f)
        {
            CreatePrefab();
        }
        
    }

    void CreatePrefab()
    {

        Vector3 area = GetComponent<SpriteRenderer>().bounds.size;
        Vector3 newPos = transform.position;

        newPos.x = newPos.x + Random.Range(-area.x / 2, area.x / 2);
        newPos.y = newPos.y + Random.Range(-area.y / 2, area.y / 2);

        newPos.z = -5;

        GameObject newGameObject = Instantiate(newPrefab);
        newGameObject.transform.position = newPos;
    }
}
