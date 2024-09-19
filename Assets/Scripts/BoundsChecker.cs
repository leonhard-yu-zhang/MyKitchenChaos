using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class BoundsChecker : MonoBehaviour
{
    void OnDrawGizmos()
    {
        // Get the Renderer component
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            // Visualize the Renderer bounds
            Gizmos.color = Color.blue; // Use green for the renderer's bounds
            Gizmos.DrawWireCube(renderer.bounds.center, renderer.bounds.size);
        }

        // Get the Collider component
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            // Visualize the Collider bounds
            Gizmos.color = Color.green; // Use red for the collider's bounds
            Gizmos.DrawWireCube(collider.bounds.center, collider.bounds.size);
        }


        // Check for overlaps and visualize intersection
        if (renderer != null && collider != null)
        {
            Bounds intersection = new Bounds();

            if (renderer.bounds.Intersects(collider.bounds))
            {
                intersection = BoundsIntersect(renderer.bounds, collider.bounds);
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireCube(intersection.center, intersection.size);
                Debug.Log("Bounds are overlapping!");
            }
            else
            {
                Debug.Log("Bounds are not overlapping.");
            }
        }
    }

    private Bounds BoundsIntersect(Bounds a, Bounds b)
    {
/*      min: The minimum corner of the box(bottom-left - back)
        max: The maximum corner of the box(top-right - front)
        The intersection box's minimum corner is the maximum of the 
        two boxes' minimum corners.
        The intersection box's maximum corner is the minimum of the 
        two boxes' maximum corners.

 */
        Vector3 min = Vector3.Max(a.min, b.min);
        Vector3 max = Vector3.Min(a.max, b.max);
        return new Bounds((min + max) / 2, max - min);
    }
}