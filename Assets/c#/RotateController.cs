using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    public Rigidbody2D lrb;
    public Rigidbody2D rrb;
    public Rigidbody2D body;
    public Transform lt;
    public Transform rt;

    public float height;
    public float speed;
    public float stiltSpeed;

    public bool canMove = false;

    private bool rs = true;
   


    public Rigidbody2D stilt
    {
        get
        {
            if (rs)
            {
                return rrb;
            }
            else
            {
                return lrb;
            }
        }
    }

    public Rigidbody2D stilt2
    {
        get
        {
            if (!rs)
            {
                return rrb;
            }
            else
            {
                return lrb;
            }
        }
    }

    public Transform Bot1
    {
        get
        {
            if (rs)
            {
                return rt;
            }
            else
            {
                return lt;
            }
        }
    }
    public Transform Bot2
    {
        get
        {
            if (rs)
            {
                return lt;
            }
            else
            {
                return rt;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void FixedUpdate()
    {
        //body.transform.position += Vector3.right * Time.fixedDeltaTime;
        //stilt.transform.Rotate(Vector3.forward * 10);
        //stilt.transform.RotateAround(Bot1.position, Vector3.forward, 1);
        //transform.RotateAround(stilt2.position, Vector3.back, 1);
        if (canMove)
        {
            Vector3 temp = Vector3.forward * Time.deltaTime * speed * stiltSpeed;

            

            stilt.transform.RotateAround(Bot1.position, Vector3.forward, temp.z * 90);
            //stilt.transform.Rotate(Vector3.forward * temp.z * 90);


            //body.transform.position += Vector3.up * speed * Time.fixedDeltaTime;
            //body.transform.Rotate(Vector3.forward * temp.z * 40);
            transform.RotateAround(stilt2.transform.GetChild(1).transform.position, Vector3.back, temp.z * 45);
            //transform.RotateAround(stilt2.position, Vector3.back, temp.z * 45);
            stilt.transform.position += Vector3.up * 4 * Time.fixedDeltaTime;

            //Vector3 temp2 = (stilt.transform.position + stilt2.transform.position) / 2;
            //temp2.y = body.transform.position.y;

            //body.transform.position = temp2;
            //Vector3 temp2 = (stilt.transform.position + stilt2.transform.position) / 2;
            //temp2.y = body.transform.position.y;

            //body.transform.position = temp2;

            //stilt.transform.position += stilt.transform.up * height * Time.fixedDeltaTime;


        }
        //float distance = Vector3.Distance(lL.transform.position, rL.transform.position);

        //if (distance > 3)
        //{
        //    StartCoroutine(levelController.Lose());
        //}

        //Vector3 temp3 = projection.transform.position;
        //temp3.z = Bot1.position.z;
        //projection.transform.position = temp3;

    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            canMove = true;
            //StartCoroutine(MoveStilts());
            rs = rrb.transform.position.x < lrb.transform.position.x;
            
            //projection.SetActive(true);

            //Vector3 temp = Bot1.transform.position ;
            //temp.y = projection.transform.position.y;

            //projection.transform.position =  temp;
        }
        else if (canMove == false || Input.GetMouseButtonUp(0))
        {
            canMove = false;

            //float distance = Vector3.Distance(Bot1.position, Bot2.position);

            //if (distance > 3 || distance < 0.85)
            //{
            //    StartCoroutine(levelController.Lose());
            //}
            //projection.SetActive(false);
        }
    }

    private IEnumerator MoveStilts()
    {
        for (int i = 0; i < 15; i++)
        {
            //Debug.Log("epoch " + height);
            //Debug.Log("before " + stilt.transform.up);

            //Debug.Log("residue: " + stilt.transform.up * height * Time.fixedDeltaTime);
            stilt.transform.position += stilt.transform.up * height * Time.fixedDeltaTime;
            stilt.transform.position += Vector3.up * height * Time.fixedDeltaTime;
            //Debug.Log("after " + stilt.transform.position);
            //Debug.Log("*******************");

            yield return new WaitForFixedUpdate();

        }

    }
}
