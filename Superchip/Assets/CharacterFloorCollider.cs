using UnityEngine;
using System.Collections;

public class CharacterFloorCollider : MonoBehaviour {

    public Character character;
    public float correctionY;
    private float maxSpaceToFall = 0.25f;
    public float distance;

    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        Vector3 pos = character.transform.localPosition;
        if (hit.collider != null)
        {
            distance = Mathf.Abs(hit.point.y - transform.position.y);

            if (distance == 0)
            {
                pos.y += correctionY;
                character.transform.localPosition = pos;
                character.OnGround();
            }
            if (distance > maxSpaceToFall)
                Fall();
        }
        else
            Fall();

    }
    void Fall()
    {
        character.OnAir();
    }
}
