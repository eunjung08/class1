using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed;
    public float radius;
    public LayerMask targetLayer;
    public Vector3 MoveVector
    {
        get
        {
            return new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized; //normalized - 어떤방향으로 가는 크기를 똑같게 해줌/Raw 힘차이
        }
    }
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rigid.velocity = MoveVector * speed;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            getNPCs();
        }
    }

    public void getNPCs()
    { 
        RaycastHit2D[] hits = Physics2D.CapsuleCastAll(transform.position, Vector2.one * radius, 0, 0, Vector2.up, 0, targetLayer);
        for(int i = 0; i < hits.Length; i++)
        {
            if(hits[i] != null)
            {
                if (hits[i].transform.TryGetComponent(out NPC npc))
                {
                    Debug.Log(npc.chat);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
