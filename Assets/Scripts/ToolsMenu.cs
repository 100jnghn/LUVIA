using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsMenu : MonoBehaviour
{
    public bool isActive;

    void Start()
    {
        isActive = false;
    }

    void Update()
    {
        
    }

    // �� ������ �ν��ؼ� Tool�޴� OPEN
    public void selectedByHandPose()
    {
        isActive = !isActive;
        gameObject.SetActive(isActive);
    }

    // Tool�޴� CLOSE
    public void unselectedByHandPose()
    {
        //gameObject.SetActive(false);
    }
}
