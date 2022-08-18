using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExemploMovimentacao : MonoBehaviour
{
    //[SerializeField]
    //KeyCode direita;
    //[SerializeField]
    //KeyCode esquerda;
    [SerializeField]
    float MoveSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) 
                                                    * MoveSpeed * Time.deltaTime);


        //if (Input.GetKey(direita))
        //{
        //    Debug.Log("Direita foi pressionado.");
        //}
        //if (Input.GetKey(esquerda))
        //{
        //    Debug.Log("Esquerda foi pressionado.");
        //}
    }
}
