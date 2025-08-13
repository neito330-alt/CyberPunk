using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtController : MonoBehaviour
{
    // Start is called before the first frame update

    private List<HurtColliderData> _hurtColliderDataList;

    private List<HurtColliderData> HurtColliderDataList
    {
        get
        {
            return _hurtColliderDataList;
        }
    }

    [SerializeField] private GameObject attackParent;

    void Start()
    {
        _hurtColliderDataList = transform.parent.GetComponent<HurtParentController_Test>().HurtColliderDataList;
        attackParent = transform.parent.GetComponent<HurtParentController_Test>().attackParent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.gameObject != attackParent)
        {
            foreach (var hurtColliderData in HurtColliderDataList)
            {
                if (hurtColliderData.AttackParent == attackParent)
                {
                    hurtColliderData.HurtParent.Add(GetComponent<Collider2D>());
                    return;
                }
            }
            HurtColliderDataList.Add(new HurtColliderData(collision.transform.parent.gameObject)
            {
                HurtParent = new List<Collider2D> { GetComponent<Collider2D>() }
            });

            UnityEngine.Object.Instantiate(
                transform.parent.GetComponent<HurtParentController_Test>().hitEffectPrefab,
                transform.position+new Vector3(Random.Range(-0.5f,0.5f),Random.Range(-0.5f,0.5f),0),
                Quaternion.identity
            );
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.parent.gameObject != attackParent)
        {
            foreach (var hurtColliderData in HurtColliderDataList)
            {
                if (hurtColliderData.AttackParent == attackParent)
                {
                    hurtColliderData.HurtParent.Remove(GetComponent<Collider2D>());
                    if (hurtColliderData.HurtParent.Count == 0)
                    {
                        HurtColliderDataList.Remove(hurtColliderData);
                    }
                    return;
                }
            }
        }
    }
}
