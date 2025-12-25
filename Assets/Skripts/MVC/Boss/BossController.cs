using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : Controller
{
    private BossMowement bossMowement;


    protected override void Awake()
    {
        base.Awake();
        model = new BossModel(stats);
        model.HealthChanged += view.OnHealthChanged;
        bossMowement = GetComponent<BossMowement>();
    }

    private void Update()
    {
        
    }
}
