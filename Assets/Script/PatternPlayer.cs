using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternPlayer : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private GameObject[]   patterns;        // �����ϰ� �ִ� ��� ����
    private GameObject     currentPattern;  // ���� ������� ����
    private int[]          patternIndexs;   // ��ġ�� �ʴ� patterns.Length ������ ����
    private int            current = 0;     // patternIndexs �迭�� ����

    private void Awake()
    {
        patternIndexs = new int[patterns.Length];

        for (int i = 0; i < patternIndexs.Length; ++i)
        {
            patternIndexs[i] = i;
        }
    }

    private void Update()
    {
        if ( gameController.IsGamePlay == false ) return;

        // ���� ������� ������ ����Ǿ� ������Ʈ�� ��Ȱ��ȸ�Ǹ�
        if ( currentPattern.activeSelf == false )
        {
            // ���� ���� ����
            ChangePattern();

        }
    }

    public void GameStart()
    {
        ChangePattern();
    }

    public void GameOver()
    {
        // ���� ������� ���ϸ� ��Ȱ��ȭ
        currentPattern.SetActive(false);
    }

    public void ChangePattern()
    {
        // ���� ����(currentPattern) ����
        currentPattern = patterns[patternIndexs[current]];

        // ���� ���� Ȱ��ȭ
        currentPattern.SetActive(true);

        current++;

        // ������ �ѹ��� ��� �����ߴٸ� ���� ������ ��ġ�� �ʴ� ������ ���ڷ� ����
        if (current >= patternIndexs.Length)
        {
            patternIndexs = Utils.RandomNumbers(patternIndexs.Length, patternIndexs.Length);
            current = 0;

        }
    }






















    /*[SerializeField]
    private GameObject segubeam;
    [SerializeField]
    private GameObject segugo;


    public static int n = 1;

    private void Start()
    {
        segubeam.SetActive(false);
        segugo.SetActive(false);
        StartCoroutine(SpawnPattern());

        
    }

    private IEnumerator SpawnPattern()
    {
        while (true)
        {
            switch (n)
            {
                case 1:

                    segugo.SetActive(true);

                    segugo.GetComponent<Segugo>().ChangeState(BossState1.MoveToAppear);

                    yield return new WaitForSeconds(5.0f);

                    segugo.SetActive(false);

                    yield return new WaitForSeconds(1.0f);

                    segubeam.SetActive(true);

                    segubeam.GetComponent<Segubeam>().ChangeState(BossState.MoveToAppearPoint);

                    yield return new WaitForSeconds(12.0f);

                    segubeam.SetActive(false);

                    break;

                    




            }
        }
        
    

    }
    */
} 
