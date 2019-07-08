using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensation : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target;
    public bool friend_or_enemy;
    public GameObject self;
    public string str;

    /*   void OnTriggerEnter(Collider other)
       {
          // Debug.Log("other tag " + other.tag);
          str = other.tag;
          if ((other.tag == "Woodie"|| other.tag == "Friend") && self.tag == "Enemy")
          {
              Debug.Log("Woodie Detected");
              target = other.transform;
          }

          if (self.tag == "Friend")
          {
              Debug.Log("Friend");
              if (other.tag == "Enemy")
              {
                  Debug.Log("Friend shoot enemy");
              }

          }
       }*/
    /*
   void OnTriggerExit()
   {
       //target = null;
   }
   */
     void OnTriggerStay(Collider other)
     {
          str = other.transform.tag;

        
         if ((other.tag == "Woodie"|| other.tag == "Friend") && self.tag == "Enemy")
         {
            // Debug.Log("Woodie Detected");
            if(other.tag == "Friend")
            {
                Debug.Log("Friend Detected");
            }

             target = other.transform;
         }

        if (other.tag == "Enemy")
        {
            Debug.Log("Enemy Approching");
            Debug.Log("Self tag " + self.tag);
            if (self.tag == "Friend")
            {
                Debug.Log("Friend shoot enemy");
                target = other.transform;
            }

        }
        



     }
}
