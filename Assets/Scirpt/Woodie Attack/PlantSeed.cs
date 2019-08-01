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
    public float height_offset = -0.5f ;
    public Animator animator;
    void Start()
    {
        pc = gameObject.GetComponentInParent(typeof(PlayerController2)) as PlayerController2;
        nb_seeds = seeds.Length;

        //UI initialization
        SeedUI_text.text = "种子：";// + seeds[selected_seed].name;
        SelectSeed();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 plant_posision = transform.position +new Vector3(0, height_offset, 0)+ transform.forward * range;

        if (KeyMappingManager.instance.seed_switch)
        {
            /*
            if (selected_seed >= nb_seeds - 1)
                selected_seed = 0;
            else
                selected_seed++;

            SeedUI_text.text = "种子：" + seeds[selected_seed].name;

            
            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }

            transform.GetChild(selected_seed).gameObject.SetActive(true);*/
            SelectNextSeed();
        }



        if (KeyMappingManager.instance.item_use && pc.IsGrounded() && pc.canMove)
        {
            animator.SetTrigger("Nock");
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

    void SelectSeed()
    {
        int i = 0;
        //Debug.Log("here");
        foreach (Transform item in transform)
        {
            if (i == selected_seed && PlayerManager.instance.ItemList[i+2].Active)
            {
                item.gameObject.SetActive(true);
                Debug.Log(seeds[selected_seed].name);
                SeedUI_text.text = "种子：" + seeds[selected_seed].name;
            }
            else if (i == selected_seed && !PlayerManager.instance.ItemList[i + 2].Active)
            {
                SelectNextSeed();
            }
            else
            {
                item.gameObject.SetActive(false);
            }
            i++;
        }
    }

    private void SelectNextSeed()
    {
        if (selected_seed >= nb_seeds - 1)
            selected_seed = 0;
        else
            selected_seed++;
        SelectSeed();

    }
}
