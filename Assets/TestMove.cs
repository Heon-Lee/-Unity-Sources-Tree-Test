using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour {

    enum Dir
    {
        left,
        down,
        right,
        up
    }

    Dir nowDir;

    Transform tr;

	// Use this for initialization
	void Start () {
        nowDir = Dir.right;
        tr = GetComponent<Transform>();
        StartCoroutine(TestMoving());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void TestOne()
    {
        Debug.Log("커밋 테스트1");
    }

    void BranhTest()
    {
        Debug.Log("브랜치 테스트1");
    }

    IEnumerator TestMoving()
    {
        int count = 0;
        while(true)
        {
            if (count++ > 60)
            {
                switch (nowDir)
                {
                    case Dir.left:
                        nowDir = Dir.down;
                        break;
                    case Dir.down:
                        nowDir = Dir.right;
                        break;
                    case Dir.right:
                        nowDir = Dir.up;
                        break;
                    case Dir.up:
                        nowDir = Dir.left;
                        break;
                }
                count = 0;
            }

            switch(nowDir)
            {
                case Dir.left:
                    tr.position = new Vector3(tr.position.x - 0.1f, tr.position.y, tr.position.z);
                    break;
                case Dir.down:
                    tr.position = new Vector3(tr.position.x, tr.position.y, tr.position.z - 0.1f);
                    break;
                case Dir.right:
                    tr.position = new Vector3(tr.position.x + 0.1f, tr.position.y, tr.position.z);
                    break;
                case Dir.up:
                    tr.position = new Vector3(tr.position.x, tr.position.y, tr.position.z + 0.1f);
                    break;
            }

            yield return new WaitForFixedUpdate();
        }
    }
}
