using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 180f;
    public TextMeshProUGUI text;
    int score=0;
    public Joystick joystick;
    private Rigidbody rb;
    public Slider slider;
    public GameObject coin;
    public AudioSource audio;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        score=PlayerPrefs.GetInt("scorecoin");

    }

    void Update()
    {

        float verticalInput = joystick.Vertical;
        float horizontalInput = joystick.Horizontal;

     
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

  
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.3f);
        }




    }

   public void jump()
    {

        rb.AddForce(new Vector3(0, 10, 0),ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("coin"))
        {
            score = score+ 1;
            PlayerPrefs.SetInt("scorecoin",score);
            text.SetText(score.ToString());
            audio.Play();
            Destroy(other.gameObject);
            if (score==10)
            {
                SceneManager.LoadScene(2);
            }
            StartCoroutine(delay());
        }
        if (other.gameObject.tag.Equals("spike")){


            slider.value -= 10;
            Destroy(other.gameObject);

        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(3);
        Instantiate (coin,coin.transform.position+new Vector3(Random.Range(-8,8),0,Random.Range(-8,8)),coin.transform.rotation);
    }

}

