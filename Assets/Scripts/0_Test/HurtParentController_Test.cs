using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HurtColliderData
{
    public GameObject AttackParent { get; set; }
    public List<Collider2D> HurtParent { get; set; }


    public HurtColliderData(GameObject attackParent)
    {
        AttackParent = attackParent;
        HurtParent = new List<Collider2D>();
    }
}

public class HurtParentController_Test : MonoBehaviour
{
    [SerializeField] public GameObject hitEffectPrefab;
    [SerializeField] public GameObject attackParent;
    public List<HurtColliderData> HurtColliderDataList { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        HurtColliderDataList = new List<HurtColliderData>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
