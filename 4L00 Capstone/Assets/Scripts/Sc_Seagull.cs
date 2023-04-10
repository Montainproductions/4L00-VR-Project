using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc_Seagull : MonoBehaviour
{
    [SerializeField]
    private Transform[] travelLocations;
    private Transform[] chossenTravelLocations = new Transform[4];
    private Transform travelLocation;

    private int travelLocationPosition;

    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        travelLocationPosition = 0;
        StartCoroutine(ChooseTravelLocations());
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(travelLocation.position, gameObject.transform.position) < 1)
        {
            NextPosition();
        }
        else
        {
            gameObject.transform.position += travelLocation.position * speed * Time.deltaTime;
        }
    }

    public void NextPosition()
    {
        if (travelLocationPosition >= chossenTravelLocations.Length)
        {
            travelLocationPosition = 0;
        }else
        {
            travelLocationPosition++;
        }

        travelLocation = chossenTravelLocations[travelLocationPosition];
    }

    IEnumerator ChooseTravelLocations()
    {
        int chosenLocationPos = 0;
        for(int i = 0; i < travelLocations.Length; i++)
        {
            float locationChossen = Random.Range(0.0f, 1.0f);
            if (chossenTravelLocations[chosenLocationPos] != null && locationChossen > 0.5f)
            {
                chossenTravelLocations[chosenLocationPos] = travelLocations[i];
                chosenLocationPos++;
            }
        }
        StartCoroutine(StartTimer());
        yield return null;
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(4);
        StartCoroutine(ChooseTravelLocations());
        yield return null;
    }
}
