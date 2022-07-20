using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListCubesController : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private List<GameObject> _listCubes;
    private float _height;
    
    //[SerializeField] private TextMeshProUGUI _counterTxt;
    //[SerializeField] private int _valueCoin;

    private void Start()
    {
        _listCubes = new List<GameObject>();
        _listCubes.Add(transform.GetChild(0).gameObject);
        _height = _listCubes[0].GetComponent<BoxCollider>().bounds.size.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        //else if (other.CompareTag("Coin"))
        //{
        //    other.gameObject.SetActive(false);
        //    int tmp;
        //    int.TryParse(counterTxt.text, out tmp);
        //    tmp += valueCoin;
        //    counterTxt.text = tmp.ToString();

        //} else if (other.CompareTag("Finish"))
        //{
        //    GameObject.FindGameObjectWithTag("Manager").GetComponent<GameMaster>().ShowNextLevelScreen();
        //} 

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tags.Wall))
        {
            LiberateCube();
        } 
        else if (collision.gameObject.CompareTag(Tags.PickUpCube))
        {
            AddCube(collision.gameObject);
        }
    }

    private void AddCube(GameObject cube)
    {
        cube.gameObject.tag = Tags.Cube;
        cube.gameObject.name = "Cube";
        cube.gameObject.SetActive(false);
     
        _player.transform.localPosition = new Vector3(_player.transform.localPosition.x,
                _player.transform.localPosition.y + _height,
                _player.transform.localPosition.z);

        cube.transform.SetParent(transform);
        cube.transform.localPosition = new Vector3(0f, _listCubes[_listCubes.Count - 1].transform.localPosition.y + _height, 0f);
        cube.SetActive(true);
        
        _listCubes.Add(cube);

    }

    private void LiberateCube()
    {
        GameObject obj = _listCubes[0];

        _listCubes[0].transform.SetParent(null);
        _listCubes.Remove(_listCubes[0]);
        
        StartCoroutine(RemoveCube(obj));
    }

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);

    private IEnumerator RemoveCube(GameObject obj)
    {
        yield return _waitForSeconds;
        obj.SetActive(false);
    }
}
