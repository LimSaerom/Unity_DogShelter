using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ChangeScene : MonoBehaviour
{
    public string SceneName;


    public void ChangeScen()         //스크립트 이름이랑 동일해서 함수명을 수정함
    {
        //Invoke 함수 문법 Invoke("함수명",지연시간); 즉, 함수가 생성되어야 사용 가능
        Invoke("LoadNextScene", 0.5f);        //버튼 클릭 후 0.5초가 경과한 시점에 씬 전환
    }

    void LoadNextScene()
    {
        GameObject Btn = GameObject.Find("EndBtn");   //UI로 생성해둔 EndBtn 버튼을 찾아서 Btn에 대입

        //1. Btn 변수에 EndBtn을 제대로 찾아 대입했는지 확인
        //2. Btn 변수가 Button을 컴포넌트로 가지고 있는지 확인 → Button을 가지고 있어야 UI기능을 사용 가능
        if (Btn != null && Btn.GetComponent<Button>() != null)          //EndBtn을 찾은 경우
        {
            if (Btn == gameObject)          //Btn변수와 EndBtn이름이 동일한 경우 = 해당 스크립트가 컴포넌트 된 게임오브젝트와 동일한가를 확인
            {
                Application.Quit();                         //게임종료를 구현하는 함수
                Debug.Log("게임종료 구동 확인");            //유니티내부에서 정상 구동하는지 확인을 위함

                return;            //게임을 종료했으니 함수를 빠져나오도록 return값 부여
            }

        }
        SceneManager.LoadScene(SceneName);
    }

}
