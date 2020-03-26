using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    GameObject obj;
    private void Awake()
    {
       //在程序启动初 随机位置创建五个立方体
        for (int i = 0; i < 5; i++)
        {
            obj = GameObject.CreatePrimitive(PrimitiveType.Cube);//生成立方体
            obj.transform.position = new Vector3(Random.Range(-5, 5), Random.Range(0, 2), Random.Range(-5, 5));//随机设置立方体位置
            obj.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));//随机设置立方体颜色
        }
    }
    int j = 0;
    //每隔2s再随机创建一个物体，并将镜头对准新物体
    private void FixedUpdate()
    {
        
        for (j=0;j<5;j++)
        {
            obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obj.transform.position = new Vector3(Random.Range(-5, 5), Random.Range(0, 2), Random.Range(-5, 5));
            obj.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            GameObject.Find("Main Camera").transform.LookAt(new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z));//使相机对准新生成的物体
            int i = Random.Range(0, 4);
            switch (i)
            {
                case 0:obj.transform.Translate(new Vector3(-5f, 0f, 0f));break;
                case 1:obj.transform.localScale *=4;break;
                case 2:obj.transform.localScale *= 0.15f;break;
                case 3:obj.GetComponent<Rigidbody>(); break;
            }
        }
    }
    //显示物体的名称 位置 和 边长
    private void OnGUI()
    {
        GUI.Label(new Rect(Screen.width - 150, 10, 100, 200), "名称：Cube" + j);
        GUI.Label(new Rect(Screen.width - 150, 25, 100, 200), "位置：(" + obj.transform.position.x + "," + obj.transform.position.y + "," + obj.transform.position.z + ")");
        GUI.Label(new Rect(Screen.width - 150, 40, 100, 200), "边长：1");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
