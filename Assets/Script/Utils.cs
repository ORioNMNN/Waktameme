using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static int[] RandomNumbers(int maxCount, int n)
    {
        int[] defaults  = new int[maxCount]; // 0~maxCount���� ������� �����ϴ� �迭
        int[] results   = new int[n];        // ��� ������ �����ϴ� �迭

        // �迭 ��ü�� 0���� maxCount�� ���� ������� ����
        for (int i = 0; i < maxCount; ++i)
        {
            defaults[i] = i;
        }

        // �ʿ��� n���� ���� ���� 
        for ( int i = 0; i < n; ++ i)
        {
            int index = Random.Range(0, maxCount);

            results[i]          = defaults[index];
            defaults[index]     = defaults[maxCount - 1];

            maxCount--;
        }

        return results;

    }
}
