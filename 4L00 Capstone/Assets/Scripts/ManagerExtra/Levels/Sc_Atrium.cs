using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Atrium : MonoBehaviour
{
    [SerializeField]
    private GameObject[] artistStatments;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DisactivatingStatments());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RoomStatement(int level)
    {
        if (level == 2)
        {
            artistStatments[0].SetActive(true);
        }
        else if (level == 3)
        {

        }
    }

    IEnumerator DisactivatingStatments()
    {
        for(int i = 0; i < artistStatments.Length; i++)
        {
            artistStatments[i].SetActive(false);
        }
        yield return null;
    }
}
