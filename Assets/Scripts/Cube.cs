using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    public float spread = 5f;
    public float shake = 0.01f;
    public float life = 5f;
    public bool alive = true;

    private float markTime = 0f;

    void Start() {
        init();
    }

    void Update() {
        if (Time.realtimeSinceStartup > markTime + life) {
            alive = false;
        }

        if (alive) { 
            transform.Translate(Random.Range(-shake, shake), Random.Range(-shake, shake), Random.Range(-shake, shake));
        }
    }

    public void init() {
        markTime = Time.realtimeSinceStartup;
        life = Random.Range(life / 2f, life * 2f);
        transform.position = new Vector3(Random.Range(-spread, spread), Random.Range(-spread, spread), Random.Range(-spread, spread));
    }

}
