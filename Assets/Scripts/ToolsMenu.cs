using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsMenu : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // �� ������ �ν��ؼ� Tool�޴� OPEN
    public void selectedByHandPose()
    {
        gameObject.SetActive(true);
    }

    // Tool�޴� CLOSE
    public void unselectedByHandPose()
    {
        gameObject.SetActive(false);
    }
}
