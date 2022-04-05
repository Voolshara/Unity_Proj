using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor_creation : MonoBehaviour
{   
    public Transform obj1;
    public Transform obj2;
    public float x_offset = 5.00f;
    public float z_offset = 5.00f;
    public int x_num = 10;
    public int z_num = 10;
    public bool is_work = false;
    // Start is called before the first frame update
    void Start()
    {   
        if(is_work){
            int flag = 1;    
            for (int j = 0; j < z_num; j++){
                for (int i = 0; i < x_num; i+=2)
                {   
                    if(flag > 0){
                        Instantiate(obj1, new Vector3(i * x_offset, 0, j * z_offset), Quaternion.identity);
                        Instantiate(obj2, new Vector3((i + 1) * x_offset, 0, j * z_offset), Quaternion.identity);
                    }
                    else{
                        Instantiate(obj2, new Vector3(i * x_offset, 0, j * z_offset), Quaternion.identity);
                        Instantiate(obj1, new Vector3((i + 1) * x_offset, 0, j * z_offset), Quaternion.identity);
                    }
                }
                flag *= -1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
