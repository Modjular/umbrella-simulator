using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella : MonoBehaviour
{
    public Renderer rend;
    public AudioSource audio;
    public float max_rot = 270f;
    public Color max_color = new Color(255,70,70);
    public Color min_color = new Color(255,70,255);

    // Start is called before the first frame update
    void Start()
    {
        rend = transform.Find("Hood").GetComponent<MeshRenderer>();
        rend.material.color = max_color;

        audio = transform.Find("Hood").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // EulerAngles are weird, so the 90 offsets it, to allow
        // a proper t-variable I can lerp with
        // t = "uprightness" from [0,1]
        float normed = Mathf.Abs(180f - Mathf.Abs(transform.eulerAngles.x - 90));
        float t = normed / 180f;

        rend.material.color = Color.Lerp(min_color, max_color, t);
        //Debug.Log("NORMED = " + normed + " --- t = " + t);
        audio.volume = 1 - t;
    }
}
