using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class LoopBackground : MonoBehaviour
{

    internal const float BACKGROUND_WIDTH = 15;
    internal static List<Transform> bgPics;

    void Start()
    {
        bgPics = new List<Transform>();
        foreach (Transform t in transform)
        {
            bgPics.Add(t);
        }
    }


    void Update()
    {
        if (Camera.main.transform.position.x >
            bgPics.FirstOrDefault<Transform>().position.x + BACKGROUND_WIDTH)
        {
            Transform back = bgPics.FirstOrDefault<Transform>();
            back.position = new Vector3
                (back.position.x + BACKGROUND_WIDTH * 2, back.position.y, back.position.z);
            bgPics.Remove(back);
            bgPics.Add(back);
        }
    }



    internal static void SetInitialPosition()
    {
        float _x = 0;
        foreach (Transform bg in bgPics)
        {
            bg.transform.position =
                new Vector3
                (
                    _x,
                    bg.transform.position.y,
                    bg.transform.position.z
                    );
            _x = _x + BACKGROUND_WIDTH;
        }
    }
}


