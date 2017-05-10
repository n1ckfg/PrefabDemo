using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public enum GameState { CUBES, SPHERE }
    public GameState gameState = GameState.CUBES;

    public float spread = 5f;
    public float shake = 0.01f;
    public float life = 5f;
    public Cube cubePrefab;
    public Sphere spherePrefab;
    public Particles particlePrefab;
    public int numCubes = 20;

    private List<Cube> cubes = new List<Cube>();
    private Sphere sphere;

    private void Start() {
        createCubes();
    }
	
	private void Update() {
        if (gameState == GameState.CUBES) {
            checkCubes();
        }
	}

    private void createCubes() {
        for (int i = 0; i < numCubes; i++) {
            Cube cube = Instantiate(cubePrefab).GetComponent<Cube>();
            cube.spread = spread;
            cube.shake = shake;
            cube.life = life;
            cube.init();
            cubes.Add(cube);
        }
    }

    private void checkCubes() {
        for (int i = 0; i < cubes.Count; i++) {
            if (!cubes[i].alive) {
                Particles ps = Instantiate(particlePrefab).GetComponent<Particles>();
                ps.gameObject.transform.position = cubes[i].gameObject.transform.position;
                Destroy(cubes[i].gameObject);
                cubes.RemoveAt(i);
            }
        }
        if (cubes.Count == 0) {
            gameState = GameState.SPHERE;
           Instantiate(spherePrefab);
        }
    }

}
