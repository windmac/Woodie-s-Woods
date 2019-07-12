using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensation : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target;
    public bool friend_or_enemy;
    public GameObject self;
    public string self_tag;
    public string other_tag;

    private Collider debug_other;
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

        self_tag = self.transform.tag;
        other_tag = other.transform.tag;
        debug_other = other;


       // Debug.Log(this.tag + " find " + other.transform.tag);

        if ((other.transform.tag == "Woodie"|| other.transform.tag == "Friend") && self.transform.tag == "Enemy")
         {
            // Debug.Log("Woodie Detected");
         /*   if(other.transform.tag == "Friend")
            {
                Debug.Log("Friend Detected");
            }*/

             target = other.transform;
         }

        if (other.transform.tag == "Enemy")
        {
          //  Debug.Log("Enemy Approching");
           // Debug.Log("Self tag " + self.transform.tag);
            if (self.transform.tag == "Friend")
            {
             //   Debug.Log("Friend shoot enemy");
                target = other.transform;
            }

        }
     }

    void OnDrawGizmosSelected()
    {
        if(debug_other!=null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(self.transform.position, debug_other.transform.position);
           
        }
       
    }
}
