using UnityEngine;

public class Ball : MonoBehaviour
{
   public float speed = 5;
   private Vector2 direction = Vector2.one;

   private void Update()
    {
        Move();

        BounceTopAndBottom();

    }

    private void BounceTopAndBottom()
    {
        float screenTop = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        float screenBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;

        Vector3 position = transform.position;

        if (direction.y > 0 && position.y >= (screenTop - 0.25f))
        {
            direction.y = -1;
        }
        else if (direction.y < 0 && position.y <= (screenBottom + 0.25f))
        {
            direction.y = 1;
        }
    }

    private void Move()
    {
        Vector3 movement = direction * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}
