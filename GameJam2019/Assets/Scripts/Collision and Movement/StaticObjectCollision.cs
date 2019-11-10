
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class StaticObjectCollision : MonoBehaviour
{
    public Vector2 rayCount;
    public LayerMask collisionMask;

    private Vector2 raySpacing;
    private RaycastOrigins raycastOrigins;

    private const float skinWidth = 0.15f;

    private BoxCollider2D coll;
    public CollisionInfo collisions;

    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        CalculateRaySpacing();
        UpdateRaycastOrigins();
    }

    void Update()
    {
        UpdateRaycastOrigins();
        collisions.Reset();
        HorizontalCollisions();
        VerticalCollisions();
    }

    private void UpdateRaycastOrigins()
    {
        Bounds bounds = coll.bounds;
        bounds.Expand(skinWidth * -2);

        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    private void CalculateRaySpacing()
    {
        Bounds bounds = coll.bounds;
        bounds.Expand(skinWidth * -2);

        rayCount.x = Mathf.Clamp(rayCount.x, 2, int.MaxValue);
        rayCount.y = Mathf.Clamp(rayCount.y, 2, int.MaxValue);

        raySpacing.x = bounds.size.y / (rayCount.x - 1);
        raySpacing.y = bounds.size.x / (rayCount.y - 1);
    }

    public struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }

    public void HorizontalCollisions()
    {
        float directionX = -1;
        float rayLength = skinWidth;

        for (int i = 0; i < rayCount.x; i++)
        {
            Vector2 rayOrigin = directionX == -1 ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
            rayOrigin += Vector2.up * (raySpacing.x * i);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);

            Debug.DrawRay(rayOrigin, Vector2.right * directionX * rayLength, Color.cyan);

            if (hit)
            {
                collisions.left = true;
            }
        }

        directionX = 1;

        for (int i = 0; i < rayCount.x; i++)
        {
            Vector2 rayOrigin = directionX == -1 ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
            rayOrigin += Vector2.up * (raySpacing.x * i);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);

            Debug.DrawRay(rayOrigin, Vector2.right * directionX * rayLength, Color.cyan);

            if (hit)
            {
                collisions.right = true;
            }
        }
    }

    public void VerticalCollisions()
    {
        float directionY = -1;
        float rayLength = skinWidth;

        for (int i = 0; i < rayCount.y; i++)
        {
            Vector2 rayOrigin = directionY == -1 ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
            rayOrigin += Vector2.right * (raySpacing.y * i);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);

            Debug.DrawRay(rayOrigin, Vector2.up * directionY * rayLength, Color.cyan);

            if (hit)
            {
                collisions.below = true;
            }
        }

        directionY = 1;

        for (int i = 0; i < rayCount.y; i++)
        {
            Vector2 rayOrigin = directionY == -1 ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
            rayOrigin += Vector2.right * (raySpacing.y * i);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);

            Debug.DrawRay(rayOrigin, Vector2.up * directionY * rayLength, Color.cyan);

            if (hit)
            {
                collisions.above = true;
            }
        }
    }

    public struct CollisionInfo
    {
        public bool left, right;
        public bool above, below;

        public void Reset()
        {
            left = false;
            right = false;
            above = false;
            below = false;
        }
    }
}