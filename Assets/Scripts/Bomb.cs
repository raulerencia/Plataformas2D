using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag.Equals("Jugador")){
            anim.SetBool("explosion", true);
            StartCoroutine("Destruir");
        }
    }
    
    IEnumerator Destruir(){
        yield return new WaitForSeconds(0.27f);
        Destroy(this.gameObject);
    }
}
