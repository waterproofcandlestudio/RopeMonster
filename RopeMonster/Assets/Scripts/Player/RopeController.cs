using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour
{
    [Tooltip("Object the rope is conected to")]
    [SerializeField]
    private Transform connectedObject;

    [Tooltip("The object that is hanging from the rope")]
    [SerializeField]
    private Transform hangingObject;

    [SerializeField]
    private int numbreRopeSections = 15;

    [SerializeField]
    private float ropeSectionLength = 0.5f;

    [SerializeField]
    private float ropeWidth = 0.2f;

    [SerializeField]
    private float gravity = 9.81f;

    private LineRenderer lineRenderer;

    private List<RopeSection> ropeSections = new List<RopeSection>();

    public struct RopeSection
    {
        public Vector3 position;
        public Vector3 oldPosition;

        public RopeSection(Vector3 _position)
        {
            this.position = _position;
            this.oldPosition = _position;
        }
    }

    private void Start()
    {
        //Get the line renderer
        lineRenderer = GetComponent<LineRenderer>();

        gravity *= -1;

        Vector3 ropeSectionPosition = connectedObject.position;

        for (int i = 0; i < numbreRopeSections; i++)
        {
            //Add a new section to the rope
            ropeSections.Add(new RopeSection(ropeSectionPosition));

            //Displace the new section a little bit lower
            ropeSectionPosition.y -= ropeSectionLength;
        }
    }

    private void Update()
    {
        DisplayRope();

        //Move the hanging object to the last rope section
        hangingObject.position = ropeSections[^1].position;

        //Make it look at the antepenultimo to make it rotate with it
        //hangingObject.LookAt(ropeSections[ropeSections.Count - 2].position);
    }

    private void FixedUpdate()
    {
        UpdateRopeSimulation();
    }

    private void UpdateRopeSimulation()
    {
        Vector3 gravityVec = new Vector3(0f, gravity, 0f);

        float t = Time.fixedDeltaTime;

        //Move the first section of the rope to where the rope is connected to
        RopeSection firstRopeSection = ropeSections[0];

        firstRopeSection.position = connectedObject.position;

        ropeSections[0] = firstRopeSection;

        for (int i = 1; i < ropeSections.Count; i++)
        {
            RopeSection currentRopeSection = ropeSections[i];

            //Get the velocity of the rope section checking position
            Vector3 vel = currentRopeSection.position - currentRopeSection.oldPosition;

            //Update the old position
            currentRopeSection.oldPosition = currentRopeSection.position;

            //Find the new position
            currentRopeSection.position += vel;

            //Add the gravity
            currentRopeSection.position += gravityVec * t;

            //Add it back to the array after all the checks
            ropeSections[i] = currentRopeSection;
        }

        for (int i = 0; i < numbreRopeSections; i++)
        {
            ImplementMaximumStrengh();
        }
    }

    private void ImplementMaximumStrengh()
    {
        for (int i = 0; i < ropeSections.Count - 1; i++)
        {
            RopeSection topSection = ropeSections[i];

            RopeSection bottomSection = ropeSections[i + 1];

            //Distances between positions
            float dist = (topSection.position - bottomSection.position).magnitude;

            float distError = Mathf.Abs(dist - ropeSectionLength);

            Vector3 changeDir = Vector3.zero;

            if (dist > ropeSectionLength)
            {
                changeDir = (topSection.position - bottomSection.position).normalized;
            }
            else if (dist > ropeSectionLength)
            {
                changeDir = (bottomSection.position - topSection.position).normalized;
            }

            Vector3 change = changeDir * distError;

            if (i != 0)
            {
                bottomSection.position += change * 0.5f;

                ropeSections[i + 1] = bottomSection;

                topSection.position -= change * 0.5f;

                ropeSections[i] = topSection;
            }
            else
            {
                bottomSection.position += change;

                ropeSections[i + 1] = bottomSection;
            }
        }
    }

    private void DisplayRope()
    {
        lineRenderer.startWidth = ropeWidth;
        lineRenderer.endWidth = ropeWidth;

        Vector3[] positions = new Vector3[ropeSections.Count];

        for (int i = 0; i < ropeSections.Count; i++)
        {
            positions[i] = ropeSections[i].position;
        }

        lineRenderer.positionCount = positions.Length;

        lineRenderer.SetPositions(positions);
    }
}