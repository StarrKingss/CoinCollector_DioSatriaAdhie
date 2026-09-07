using UnityEngine;

public class FlexZombie : Enemy
{
   public bool flag = true;

   public override void Serang()
   {
      Debug.Log("FlagZombie Gigit");
   }
}