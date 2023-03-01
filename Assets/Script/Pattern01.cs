using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Process { Phase01,  Phase02, Phase03, Phase04, Phase05, }
public class Pattern01 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] warningImages; // 경고 이미지
    [SerializeField]
    private GameObject[] gosegu; // 플레이어 오브젝트
    [SerializeField]
    private GameObject ground;
    [SerializeField]
    private AudioSource[] arrayAudio;
    private Movement2D movement2D;

    private Process process = Process.Phase01;

    [SerializeField]
    private LineRendererAtoB visuallizerLineLeft;
    [SerializeField]
    private LineRendererAtoB visuallizerLineRight;

    [SerializeField]
    private Transform ownerLeft;
    [SerializeField]
    private Transform ownerRight;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float attackrate = 1;
    [SerializeField]
    private int maxFireCount = 5;

    private int loveCount = 2;
    private int count = 0;
    private int shootcount = 17;
    public float speed = 5;
    public Vector2[] vecArrayA;
    public Vector2[] vecArrayB;
    private int a;

    private void Awake()
    {
        vecArrayA = new Vector2[]
        {
            new Vector2(gosegu[5].transform.position.x, 2.9f),
            new Vector2(gosegu[6].transform.position.x, 2.9f),
            new Vector2(gosegu[7].transform.position.x, 2.9f),
            new Vector2(gosegu[8].transform.position.x, 2.9f)
        };

        vecArrayB = new Vector2[]
        {
            new Vector2(gosegu[5].transform.position.x, gosegu[5].transform.position.y),
            new Vector2(gosegu[6].transform.position.x, gosegu[6].transform.position.y),
            new Vector2(gosegu[7].transform.position.x, gosegu[7].transform.position.y),
            new Vector2(gosegu[8].transform.position.x, gosegu[8].transform.position.y)
        };

        gosegu[5].SetActive(false);
        gosegu[6].SetActive(false);
        gosegu[7].SetActive(false);
        gosegu[8].SetActive(false);

        movement2D = GetComponent<Movement2D>();
        gosegu[1].SetActive(true);

    }

    private void OnEnable()
    {
        StartCoroutine(nameof(Phase05));

    }

    private void OnDisable()
    {
        //다음 사용을 위해 플레이어 오브젝트 상태를 초기화 
        for (int i = 0; i < gosegu.Length; ++i)
        {
            gosegu[i].SetActive(false);
            gosegu[i].GetComponent<MovingEntity>();
        }

        StopCoroutine(nameof(Process));
    }

    public void ChangeState(Process newState)
    {

        StopCoroutine(process.ToString());

        process = newState;

        StartCoroutine(process.ToString());
    }

    private IEnumerator Phase01()
    {
        warningImages[0].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        warningImages[0].SetActive(false);

        gosegu[0].GetComponent<Movement2D>().MoveTo(new Vector2(0, 1));
        while (true)
        {
            if (gosegu[0].GetComponent<Transform>().position.y > -0.918f)
            {
                gosegu[0].GetComponent<Movement2D>().MoveTo(new Vector2(0, 0));
                ChangeState(Process.Phase02);
            }
            yield return null;

        }
    }

    private IEnumerator Phase02()
    {
        yield return new WaitForSeconds(1);

        int count = 0;
        while ( count < maxFireCount)
        {
            arrayAudio[1].Play();
            CircleFire();

            count++;

            yield return new WaitForSeconds(attackrate);
        }

        ChangeState(Process.Phase03);

        gosegu[0].SetActive(false);
        
    }

    private IEnumerator Phase03()
    {
        warningImages[2].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        arrayAudio[0].Play();
        warningImages[2].SetActive(false);

        gosegu[2].GetComponent<Movement2D>().MoveTo(Vector3.right);

        while (true)
        {
            if (gosegu[2].GetComponent<Transform>().position.x >= -5)
            {
                gosegu[2].GetComponent<Movement2D>().MoveTo(Vector3.zero);
                ChangeState(Process.Phase04);
            }
            yield return null;
        }
    }

    private IEnumerator Phase04()
    {

        yield return new WaitForSeconds(1.5f);
        warningImages[3].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        warningImages[3].SetActive(false);
        StartCoroutine(nameof(Moto));
        yield return new WaitForSeconds(2.5f);
        warningImages[3].SetActive(true);
        yield return new WaitForSeconds(0.3f);
        warningImages[3].SetActive(false);
        StartCoroutine(nameof(Moto));
        yield return new WaitForSeconds(2f);

    }

    private IEnumerator Phase05()

    {
        while (ground.transform.rotation.y >= -0.5f)
        {
            ground.transform.Rotate(0, -Time.deltaTime * 30, 0);
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        arrayAudio[2].Play();
        gosegu[5].SetActive(true);
        StartCoroutine(nameof(L));
        yield return new WaitForSeconds(0.3f);
        gosegu[6].SetActive(true);
        StartCoroutine(nameof(O));
        yield return new WaitForSeconds(0.3f);
        gosegu[7].SetActive(true);
        StartCoroutine(nameof(V));
        yield return new WaitForSeconds(0.3f);
        gosegu[8].SetActive(true);
        StartCoroutine(nameof(E));
        yield return new WaitForSeconds(2f);




        int[] n = Utils.RandomNumbers(4, 4);
        while (a < 500)
        {
            gosegu[5].transform.position = Vector2.MoveTowards(gosegu[5].transform.position, vecArrayA[n[0]], 10 * Time.deltaTime);
            gosegu[6].transform.position = Vector2.MoveTowards(gosegu[6].transform.position, vecArrayA[n[1]], 10 * Time.deltaTime);
            gosegu[7].transform.position = Vector2.MoveTowards(gosegu[7].transform.position, vecArrayA[n[2]], 10 * Time.deltaTime);
            gosegu[8].transform.position = Vector2.MoveTowards(gosegu[8].transform.position, vecArrayA[n[3]], 10 * Time.deltaTime);
            yield return null;
            a++;
        }
        a = 0;

        while (a < 200)
        {
            gosegu[5].transform.position = Vector2.MoveTowards(gosegu[5].transform.position, vecArrayB[n[0]], 10 * Time.deltaTime);
            gosegu[6].transform.position = Vector2.MoveTowards(gosegu[6].transform.position, vecArrayB[n[1]], 10 * Time.deltaTime);
            gosegu[7].transform.position = Vector2.MoveTowards(gosegu[7].transform.position, vecArrayB[n[2]], 10 * Time.deltaTime);
            gosegu[8].transform.position = Vector2.MoveTowards(gosegu[8].transform.position, vecArrayB[n[3]], 10 * Time.deltaTime);
            yield return null;
            a++;
        }

        arrayAudio[2].Play();
        StartCoroutine(nameof(L));
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(nameof(O));
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(nameof(V));
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(nameof(E));
        yield return new WaitForSeconds(0.3f);

        n = Utils.RandomNumbers(4, 4);
        ;
        while (a < 500)
        {
            gosegu[5].transform.position = Vector2.MoveTowards(gosegu[5].transform.position, vecArrayA[n[0]], 10 * Time.deltaTime);
            gosegu[6].transform.position = Vector2.MoveTowards(gosegu[6].transform.position, vecArrayA[n[1]], 10 * Time.deltaTime);
            gosegu[7].transform.position = Vector2.MoveTowards(gosegu[7].transform.position, vecArrayA[n[2]], 10 * Time.deltaTime);
            gosegu[8].transform.position = Vector2.MoveTowards(gosegu[8].transform.position, vecArrayA[n[3]], 10 * Time.deltaTime);
            yield return null;
            a++;
        }
        a = 0;

        while (a < 200)
        {
            gosegu[5].transform.position = Vector2.MoveTowards(gosegu[5].transform.position, vecArrayB[n[0]], 10 * Time.deltaTime);
            gosegu[6].transform.position = Vector2.MoveTowards(gosegu[6].transform.position, vecArrayB[n[1]], 10 * Time.deltaTime);
            gosegu[7].transform.position = Vector2.MoveTowards(gosegu[7].transform.position, vecArrayB[n[2]], 10 * Time.deltaTime);
            gosegu[8].transform.position = Vector2.MoveTowards(gosegu[8].transform.position, vecArrayB[n[3]], 10 * Time.deltaTime);
            yield return null;
            a++;
        }

        arrayAudio[2].Play();
        StartCoroutine(nameof(L));
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(nameof(O));
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(nameof(V));
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(nameof(E));
        yield return new WaitForSeconds(0.3f);

        while (ground.transform.rotation.y <= 0)
        {
            ground.transform.Rotate(0, Time.deltaTime * 30, 0);
            yield return null;
        }

        ChangeState(Process.Phase01);
    }

    private void CircleFire()
    {

        float intervalAngle = 360 / shootcount;

        for(int i = 0; i < shootcount; ++i)
        {
            GameObject clone = Instantiate(gosegu[1], gosegu[0].transform.position, Quaternion.identity);

            Rigidbody2D rigid = clone.GetComponent<Rigidbody2D>();

            Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 2 * i / shootcount), Mathf.Sin(Mathf.PI * 2 * i / shootcount));

            rigid.AddForce(dirVec.normalized * 5, ForceMode2D.Impulse);

            Vector3 rotVec = Vector3.forward * 360 * i / shootcount + Vector3.forward * 90;
            clone.transform.Rotate(rotVec);

        }

        shootcount--;
    }

    private IEnumerator L()
    {


        while (gosegu[5].transform.position.y >= -3.3f)
        {
            gosegu[5].GetComponent<Movement2D>().MoveTo(new Vector2(0, -1));
            yield return null;
        }

        while (gosegu[5].transform.position.y <= 2.9f)
        {
            gosegu[5].GetComponent<Movement2D>().MoveTo(new Vector2(0, 1));
            yield return null;
        }

        gosegu[5].GetComponent<Movement2D>().MoveTo(new Vector2(0, 0));

    }

    private IEnumerator O()
    {


        while (gosegu[6].transform.position.y >= -3.3f)
        {
            gosegu[6].GetComponent<Movement2D>().MoveTo(new Vector2(0, -1));
            yield return null;
        }

        while (gosegu[6].transform.position.y <= 2.9f)
        {
            gosegu[6].GetComponent<Movement2D>().MoveTo(new Vector2(0, 1));
            yield return null;
        }

        gosegu[6].GetComponent<Movement2D>().MoveTo(new Vector2(0, 0));

    }

    private IEnumerator V()
    {


        while (gosegu[7].transform.position.y >= -3.3f)
        {
            gosegu[7].GetComponent<Movement2D>().MoveTo(new Vector2(0, -1));
            yield return null;
        }

        while (gosegu[7].transform.position.y <= 2.9f)
        {
            gosegu[7].GetComponent<Movement2D>().MoveTo(new Vector2(0, 1));
            yield return null;
        }

        gosegu[7].GetComponent<Movement2D>().MoveTo(new Vector2(0, 0));

    }

    private IEnumerator E()
    {


        while (gosegu[8].transform.position.y >= -3.3f)
        {
            gosegu[8].GetComponent<Movement2D>().MoveTo(new Vector2(0, -1));
            yield return null;
        }

        while (gosegu[8].transform.position.y <= 2.9f)
        {
            gosegu[8].GetComponent<Movement2D>().MoveTo(new Vector2(0, 1));
            yield return null;
        }

        gosegu[8].GetComponent<Movement2D>().MoveTo(new Vector2(0, 0));

    }

    private IEnumerator Moto()
    {
        Vector2 LeftEye = new Vector2(-3.56f, -0.43f);
        Vector2 RightEye = new Vector2(-5.73f, -0.43f);
        Vector2 target = Vector2.zero;
        gosegu[3].GetComponent<Movement2D>().MoveTo(new Vector2(0, 1));
        while(gosegu[3].GetComponent<Transform>().position.y <= -3)
        {
            gosegu[3].GetComponent<Movement2D>().MoveTo(new Vector2(0, 1)); // y -30까지 위로
            yield return null;
        }

        gosegu[3].GetComponent<Movement2D>().MoveTo(new Vector2(0, 0)); // 잠시 멈추고 0.1초 대기
        yield return new WaitForSeconds(0.1f);

        while(gosegu[3].GetComponent<Transform>().position.y >= -6.5)
        {
            gosegu[3].GetComponent<Movement2D>().MoveTo(new Vector2(0, -1));
            yield return null;
        }

        gosegu[3].GetComponent<Movement2D>().MoveTo(new Vector2(0, 0));
        

        /*while (true)
        {
            if (gosegu[3].GetComponent<Transform>().position.y >= -3)
            {
                gosegu[3].GetComponent<Movement2D>().MoveTo(new Vector2(0, 0));
                yield return new WaitForSeconds(0.1f);

                gosegu[3].GetComponent<Movement2D>().MoveTo(new Vector2(0, -1));


                target.x = player.transform.position.x;
                target.y = player.transform.position.y;

                Vector2 directionLeft = (target - (Vector2)ownerLeft.position);
                Vector2 directionRight = (target - (Vector2)ownerRight.position);

                visuallizerLineLeft.Play(ownerLeft.position, target);
                visuallizerLineRight.Play(ownerRight.position, target);

                yield return new WaitForSeconds(0.1f);
                visuallizerLineLeft.Stop();
                visuallizerLineRight.Stop();
            }

            if (gosegu[3].GetComponent<Transform>().position.y < -6)
            {
                gosegu[3].GetComponent<Movement2D>().MoveTo(new Vector2(0, 0));
                ChangeState(Process.Phase05);
            }
            count++;
            yield return null;
        }*/

    }

}