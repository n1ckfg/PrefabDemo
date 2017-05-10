using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour {

    public ParticleSystem ps;

    private void Start() {
        if (!ps.isPlaying) ps.Play();
    }

    void Update() {
        if (ps.isStopped) {
            Destroy(gameObject);
        }		
	}

}
