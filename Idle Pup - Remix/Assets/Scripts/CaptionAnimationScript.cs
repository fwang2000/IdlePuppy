using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptionAnimationScript : MonoBehaviour
{

    List<Animator> _animators;
    // Start is called before the first frame update
    void Start()
    {
        _animators = new List<Animator>(GetComponentsInChildren<Animator>());
        StartCoroutine(doAnimation());
        
    }

    IEnumerator doAnimation()
    {
        while (true)
        {
            foreach (var animator in _animators)
            {
                animator.SetTrigger("doAnim");
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(1f);
        }

    }
}
