using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class MeshesCombiner : MonoBehaviour
{
    [SerializeField] private bool _hasCollider = false;

    private void Start()
    {
        Vector3 oldPos = transform.position;
        Quaternion oldRot = transform.rotation;
        
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        
        var meshFilters = GetComponentsInChildren<MeshFilter>();
        var combine = new CombineInstance[meshFilters.Length];
        
        for (int i = 0; i < meshFilters.Length; i++)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
        }
       
        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        transform.GetComponent<MeshFilter>().mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        transform.gameObject.SetActive(true);

        transform.position = oldPos;
        transform.rotation = oldRot;

        if (_hasCollider)
        {
            //gameObject.GetComponent<MeshCollider>().sharedMesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
            if (gameObject.TryGetComponent<MeshCollider>(out MeshCollider meshCollider))
            {
                meshCollider.sharedMesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
            } 
            else
            {
                Debug.Log("No mesh collider");
            }
        }
            
    }
  
}
