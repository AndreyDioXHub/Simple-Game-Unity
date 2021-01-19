using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Power;
    [SerializeField]
    private GameObject _enemy;
    private float _speed;
    private bool _blockDamage = true;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if(other.tag == "Tile" && _blockDamage == false)
        {
            EventManager.instance.OnHiHitMe();
            var myNewEnemy1 = Instantiate(_enemy, transform.position, Quaternion.AngleAxis(Random.Range(transform.eulerAngles.y, transform.eulerAngles.y + 45), transform.up));//AngleAxis(Random.Range(0, 45), Vector3.up)); ;; ;
            var myNewEnemy2 = Instantiate(_enemy, transform.position, Quaternion.AngleAxis(Random.Range(transform.eulerAngles.y - 45, transform.eulerAngles.y), transform.up));
            myNewEnemy1.GetComponent<Enemy>().Power = Power - 1;
            myNewEnemy2.GetComponent<Enemy>().Power = Power - 1;
            Destroy(gameObject);
            Destroy(other.transform.gameObject);
        }

        if(other.tag == "Player")
        {
            EventManager.instance.OnEndGame();
        }

        if (other.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (Power <= 0)
        {
            Destroy(gameObject);
        }
        _speed = (Power+1)/2;
        transform.localScale = new Vector3(Power, transform.localScale.y, Power);
        StartCoroutine(ExampleCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        _blockDamage = false;
    }
}
