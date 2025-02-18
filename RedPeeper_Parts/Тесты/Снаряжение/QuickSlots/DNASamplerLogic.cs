using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

internal class DNASamplerLogic : PlayerTool
{
    public override void Awake()
    {
        base.Awake();
    }
    public override bool OnRightHandDown()
    {
        if (Player.main.IsBleederAttached())
        {
            return true;
        }
        ErrorMessage.AddMessage("Shitfuck");
        return true;
    }
    public override string animToolName
    {
        get
        {
            return TechType.Scanner.AsString(true);
        }
    }
    private void LateUpdate ()
    {
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
    }
    public override void OnHolster()
    {
        base.OnHolster();
    }
}