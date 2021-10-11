using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spawn_Balloon : MonoBehaviour
{
    public Image point_Left;
    public Image point_Right;
    public Image point_Image;
    public Camera cam;
    public GameObject balloon;
    bool spawn_Check = true;
    public Text text_Score;

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (spawn_Check)
        {
            StartCoroutine(Spawn_Balloon_Time());
        }
        text_Score.text = Balloon.score.ToString();
    }

    IEnumerator Spawn_Balloon_Time (){
        float x_Range = Random.Range(point_Left.GetComponent<RectTransform>().position.x, point_Right.GetComponent<RectTransform>().position.x);
        GameObject ball = ObjectPool.instance.GetpooledObject();
        if(Mathf.Abs(x_Range - point_Left.GetComponent<RectTransform>().position.x) < 6f)
        {
            if(x_Range > 0)
            {
                x_Range -= 5f;
            }else if(x_Range < 0)
            {
                x_Range += 5f;
            }
        }
        Vector3 pos = point_Left.GetComponent<RectTransform>().position;
        pos.x = x_Range;
        //Instantiate(ball, pos, Quaternion.identity);ba
        if(ball!= null)
        {
            ball.transform.position = pos;
            ball.SetActive(true);
        }
        
        spawn_Check = false;
        yield return new WaitForSeconds(0.6f);
        spawn_Check = true;
    }
}
