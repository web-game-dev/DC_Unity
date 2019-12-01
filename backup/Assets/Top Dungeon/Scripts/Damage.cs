using UnityEngine;

public struct Damage
{
    /* Damage structure, it is used to carry information
     * when the damaging object "fires", think about a arrow
     * shot from a bow, this arrow needs to remember from which
     * bow it got shot from, how much damage that bow had.. etc
     */

    public Vector3 origin;
    public int damageAmount;
    public float pushForce;
}
