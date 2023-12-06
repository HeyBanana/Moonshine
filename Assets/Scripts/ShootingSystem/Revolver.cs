using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Revolver : Gun

{
   



    public override void Reload()
    {
        reason = 5 - magazine;
        magazine = 5;
        int result = maxMagazine - reason;
        maxMagazine = result;
    }
}
