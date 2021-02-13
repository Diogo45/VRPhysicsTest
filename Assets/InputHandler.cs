using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum InputKey
{
    Up, Down, Held
}
public class InputHandler : MonoBehaviour
{

    

    public static InputHandler ih;

    public InputKey W;
    public InputKey S;

    // Start is called before the first frame update
    void Start()
    {
        if (ih == null)
            ih = this;
        else
            Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
            W = InputKey.Down;
        if (Input.GetKeyUp("w"))
            W = InputKey.Up;

        if (Input.GetKeyDown("s"))
            S = InputKey.Down;
        if (Input.GetKeyUp("s"))
            S = InputKey.Up;



    }
}
