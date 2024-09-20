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
        // ���������x����
        startpos = transform.position.x;
        // ���������x�S����η�
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        // �o�ޥ�����`���ʹ�ä���ѥ��`���`
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        // ������ҕ�����ʹ�ä���ѥ��`���`
        float dist = (cam.transform.position.x * parallaxEffect);

        // ҕ������뤨��I��
        // ���������x���ˤ�dist�η��ƄӤ�����
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        // �o�ޥ�����`��
        // ������ˤʤä��鱳��������ƄӤ�����
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
