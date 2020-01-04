using UnityEngine;
using System.Collections;

public class exitwithesc : MonoBehaviour {

	public GameObject exitmenu;
    // Update is called once per frame
    void Start()
        {
        exitmenu.SetActive(false);
        }
     void Update()
        {
        if (Input.GetKey(KeyCode.Escape))
            {
            exitmenu.SetActive(true);
            }

        }
    public void no()
        {

        exitmenu.SetActive(false);
        }
    public void yes()
        {
        Application.Quit();

        }
    }


