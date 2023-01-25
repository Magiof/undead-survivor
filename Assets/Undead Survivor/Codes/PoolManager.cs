using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // .. 프리펩들을 보관할 변수
    public GameObject[] prefeps;

    // .. 풀 담당을 하는 리스트
    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefeps.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        // ... 선택한 풀의 놀고 있는(==비활성화된) 게임오브젝트 접근
        foreach (GameObject item in pools[index])
        {
            // ... 발견하면 select에 할당
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }
        // ... 못찾았으면?
        if (!select)
        {
            // ... 생성 후 select에 할당
            select = Instantiate(prefeps[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}
