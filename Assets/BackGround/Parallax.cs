using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        // ±³¾°»­Ïñ¤Îx×ù˜Ë
        startpos = transform.position.x;
        // ±³¾°»­Ïñ¤ÎxÝS·½Ïò¤Î·ù
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        // ŸoÏÞ¥¹¥¯¥í©`¥ë¤ËÊ¹ÓÃ¤¹¤ë¥Ñ¥é¥á©`¥¿©`
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        // ±³¾°¤ÎÒ•²î„¿¹û¤ËÊ¹ÓÃ¤¹¤ë¥Ñ¥é¥á©`¥¿©`
        float dist = (cam.transform.position.x * parallaxEffect);

        // Ò•²î„¿¹û¤òÓë¤¨¤ë„IÀí
        // ±³¾°»­Ïñ¤Îx×ù˜Ë¤òdist¤Î·ÖÒÆ„Ó¤µ¤»¤ë
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        // ŸoÏÞ¥¹¥¯¥í©`¥ë
        // »­ÃæÍâ¤Ë¤Ê¤Ã¤¿¤é±³¾°»­Ïñ¤òÒÆ„Ó¤µ¤»¤ë
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
