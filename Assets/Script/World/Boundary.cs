using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject boundary;
    private float sizeX;
    private float sizeY;
   
    private GameObject boundaryTop;
    private GameObject boundaryBottom;
    private GameObject boundaryRight;
    private GameObject boundaryLeft;


    void Start()
    {
        // 프리팹 생성 후 오브젝트 배열에 지정
        sizeX = GetComponentInParent<World>().width;
        sizeY = GetComponentInParent<World>().height;

        boundaryTop = Instantiate(boundary, new Vector2(sizeX / 2, sizeY), Quaternion.Euler(0, 0, 0));
        boundaryTop.transform.parent = this.transform;
        boundaryTop.GetComponent<BoxCollider2D>().size  = new Vector2(sizeX,1);

        boundaryBottom = Instantiate(boundary, new Vector2(sizeX / 2, 0), Quaternion.Euler(0, 0, 0));
        boundaryBottom.transform.parent = this.transform;
        boundaryBottom.GetComponent<BoxCollider2D>().size = new Vector2(sizeX, 1);

        boundaryRight = Instantiate(boundary, new Vector2(sizeX , sizeY/2), Quaternion.Euler(0, 0, 90));
        boundaryRight.transform.parent = this.transform;
        boundaryRight.GetComponent<BoxCollider2D>().size = new Vector2(sizeY, 1);

        boundaryLeft = Instantiate(boundary, new Vector2(0, sizeY/2), Quaternion.Euler(0, 0, 90));
        boundaryLeft.transform.parent = this.transform;
        boundaryLeft.GetComponent<BoxCollider2D>().size = new Vector2(sizeY, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
