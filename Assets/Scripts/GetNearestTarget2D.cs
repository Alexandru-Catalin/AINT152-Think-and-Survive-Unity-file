using System.Linq;
using UnityEngine;
using UnityEngine.Events;

// this script will detect all targets within the range specified and store them in the hits array
// it will look in the hits array for the nearest target, comparing their positions using Vector3.sqrMagnitude
// it will send out the custom event "GetNearestTargetEvent" with the nearest transform
// when the gameobject is selected in the inspector, the "OnDrawGizmosSelected" method will draw a debug sphere showing the range in the scene

// USAGE
// attach a method to the "GetNearestTargetEvent" in the inspector to get the nearest transform
// NOTE: make sure the method attached has a "Transform" parameter
// call the "GetNearestTarget" method from another script during the game to find the nearest target

// EXAMPLE - a turret
// attach a script with a method on the turret to get the target (of type Transform), like "LookForTarget(Transform target)"
// if the "LookForTarget" finds a target (target != null), shoot it!
// set a timer in the turret script to use the "GetNearestTarget" method every few seconds so we can get a fresh target

// first, we create a custom event to send the nearest target to another script
// this is so we can do other things like apply damage, turn to face target etc
// https://docs.unity3d.com/ScriptReference/Events.UnityEvent_1.html
[System.Serializable]
public class GetNearestTargetEvent : UnityEvent<Transform> { }

public class GetNearestTarget2D : MonoBehaviour 
{
	// this is the range the circlecast will run at
    // the OnDrawGizmosSelected method below will draw a sphere in the inspector showing us the size of the range in game
    public float range = 1;

	// the script will only detect colliders on the layer specified here
	// you can detect on multiple layers in the inspector
	// https://docs.unity3d.com/ScriptReference/LayerMask.html
    public LayerMask mask;
	
	// this is the custom event that will send the nearest target transform
	// link this event in the inspector to another class to apply damage, look at target etc
	// WARNING! this may return a null transform if there are no targets, make sure code handling this event can deal with that
	public GetNearestTargetEvent onGetClosestEnemy;

	// this array will store all of the targets found from the circlecast
	// from this array we will find the nearest transform to us
	// https://docs.unity3d.com/ScriptReference/RaycastHit2D.html
	RaycastHit2D[] hits;

	// call this method from another class to find the nearest target
	// WARNING! it will call the onGetClosestEnemy custom event whether it finds a transform or not, so the result may be null!
	public void GetNearestTarget()
	{
		// this performs a circlecast on all 2D colliders in the range specified
		// it will only return hits on colliders with the layer matching the mask property
		// https://docs.unity3d.com/ScriptReference/Physics2D.CircleCastAll.html
		hits = Physics2D.CircleCastAll(transform.position, range, Vector3.up, 0, mask);
		
		// this sends the custom event 
		// the code uses the System.Linq library to sort through the hits array using OrderBy, comparing their positions
		// the code is in a "Lambda" expression (yes, that's where Valve got it from) - these are quite advanced but very handy tools!
		// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions
		// note the position comparisons use sqrMagnitude to find the nearest transform
		// https://docs.unity3d.com/ScriptReference/Vector3-sqrMagnitude.html
		onGetClosestEnemy.Invoke(hits.OrderBy(t => (t.transform.position - transform.position).sqrMagnitude).FirstOrDefault().transform);
	}


	// this method allows you do do things like draw in the scene view when this gameobject is selected
    // we will draw a sphere the same size as our range to show the size of the spherecast
	// https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnDrawGizmosSelected.html
    void OnDrawGizmosSelected()
    {
        // Display the detection range when selected
        // set our colour to red
		// https://docs.unity3d.com/ScriptReference/Gizmos-color.html
        Gizmos.color = Color.red;

        // draw a sphere the same size as the range in the scene view
		// https://docs.unity3d.com/ScriptReference/Gizmos.DrawWireSphere.html
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
