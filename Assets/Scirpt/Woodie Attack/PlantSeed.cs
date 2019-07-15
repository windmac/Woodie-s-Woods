using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantSeed : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject seed;
    public GameObject[] seeds;
    public float range = 0.8f;
    private PlayerController2 pc;
    public float stop_time = 0.1f;
    public int selected_seed = 0;
    public int nb_seeds;
    public Text SeedUI_text;

    void Start()
    {
        pc = gameObject.GetComponentInParent(typeof(PlayerController2)) as PlayerController2;
        nb_seeds = seeds.Length;

        //UI initialization
        SeedUI_text.text = "种子：" + seeds[selected_seed].name;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 plant_posision = new Vector3(transform.position.x, 0, transform.position.z) + transform.forward * range;

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (selected_seed >= nb_seeds - 1)
                selected_seed = 0;
            else
                selected_seed++;

            SeedUI_text.text = "种子：" + seeds[selected_seed].name;

            
            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }

            transform.GetChild(selected_seed).gameObject.SetActive(true);
        }



        if (Input.GetKeyDown(KeyCode.C) && pc.IsGrounded())
        {

            StartCoroutine(Coroutine());
            GameObject clone;
            clone = Instantiate(seeds[selected_seed], plant_posision, transform.rotation) as GameObject;

        }
    }

    IEnumerator Coroutine()
    {
        pc.canMove = false;
        yield return new WaitForSeconds(stop_time);
        pc.canMove = true;

    }
}
