using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class postprocessingController : MonoBehaviour
{
    [Header ("Basic Variables")]
    public GameObject activeCamera;
    public GameObject player;
    public Volume postProcessingVolume;

    [Header ("Options")]
    public bool DepthofFieldActive = true;
    public bool FilmGrainActive = false;

    [Header ("Depth of Field Controller")]
    public float defaultFocalLength = 65;
    public float distanceToFocus;

    //Private Variables
    private DepthOfField dof;
    private Vignette vignetteBlur;


    
    // Start is called before the first frame update
    void Start()
    {
        postProcessingVolume.profile.TryGet(out dof);
        postProcessingVolume.profile.TryGet(out vignetteBlur);
    }

    // Update is called once per frame
    void Update()
    {
        
        //Calculate Depth of Field
        if (DepthofFieldActive == true)
        {
            //Focal Distance
            distanceToFocus = Vector3.Distance(activeCamera.transform.position, player.transform.position);
            dof.focusDistance.value = distanceToFocus;

            //Focal Length
            if (distanceToFocus>10)
            {
            dof.focalLength.value = (distanceToFocus * 10f)-20f;
            }
        }

        
    }
}
