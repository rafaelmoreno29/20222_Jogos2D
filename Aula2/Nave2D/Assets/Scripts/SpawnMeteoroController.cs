using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteoroController : MonoBehaviour
{
    [SerializeField]
    GameObject MeteoroPrefab;
    [SerializeField]
    float segundosPrimeiraVez;
    [SerializeField]
    float segundosDemaisVezes;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CriarMeteoro", segundosPrimeiraVez, segundosDemaisVezes); 
    }
    private void CriarMeteoro()
    {
        Instantiate(MeteoroPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
