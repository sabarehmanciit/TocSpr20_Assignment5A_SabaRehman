using System.Collections;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float sphereRadius;
    public GameObject spawn;

    public float spanWait;
    public float spanMostWait;
    public float spanLeastWait;
    public int startWait;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(WaitSpanner());
    }

    // Update is called once per frame
    void Update()
    {
        spanWait = Random.Range(spanLeastWait, spanMostWait);
    }


    private IEnumerator WaitSpanner()
    {
        yield return new WaitForSeconds(startWait);

        for (var i = 0; i < 10; i++)
        {
            var randomString = "";

            var characters = new string[] { "x", "s", "3" };
            var stringLength = Random.Range(9, 15);

            var divisor = stringLength % 2 == 0 ? 2 : 1;

            for (var j = 0; j < stringLength / divisor; j++)
            {
                randomString += characters[Random.Range(0, characters.Length)];
            }

            if (divisor == 2)
                randomString += new string(randomString.Reverse().ToArray());


            var spanPosition = new Vector3(Random.Range(-15f, 15f), Random.Range(0f, 15f), Random.Range(-15f, 15f));
            if (!Physics.CheckSphere(spanPosition, sphereRadius))
            {

                var cube = Instantiate(spawn, spanPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                cube.name = string.Format("cube{0}", i);
                var textMesh = cube.GetComponentInChildren<TextMesh>();
                textMesh.transform.position = cube.transform.position + transform.TransformPoint(0, 1, 0);
                textMesh.text = randomString;
            }
            else
            {
                i--;
            }

        }

        yield return new WaitForSeconds(spanWait);
    }

}