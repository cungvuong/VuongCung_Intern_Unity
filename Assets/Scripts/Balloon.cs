using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balloon : MonoBehaviour
{
    public Transform border_Destroy;
    public ParticleSystem effect_Break_Ball;
    [HideInInspector] public static int score = 0;
    Animator ani_;
    bool one_Click = true;
    private float speed; 
    // Start is called before the first frame update
    private void Awake()
    {
    }
    void Start()
    {
        ani_ = gameObject.GetComponentInChildren<Animator>();
        speed = Random.Range(20f, 30f);
    }

    private void FixedUpdate()
    {
        if(gameObject.transform.position.y > border_Destroy.position.y)
            gameObject.SetActive(false);
        transform.Translate(new Vector3(0f, speed, 0f) * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        if (one_Click)
        {
            ani_.SetBool("Idle", false);
            StartCoroutine(Time_Set());
            score++;
            one_Click = false;
            Instantiate(effect_Break_Ball, gameObject.transform.position, Quaternion.identity);
        }
    }

    IEnumerator Time_Set()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
        one_Click = true;
    }
}
