using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
public class AssignGO : MonoBehaviour
{
    public MonoBehaviour Script;
    public string VariableName;
    private System.Type scriptType;
    public GameObject Assignee;
    public GameObject Assignable;
    private bool done = false;
    public bool run;

    public void Start()
    {
        run = false;
        Debug.Log(Script.GetType());
    }

    private void Update()
    {
        scriptType = Script.GetType();
        
        if (run)
        {
            done = true;
            AssignRecursive(Assignee, Assignable);
        }
    }

    void AssignRecursive(GameObject a, GameObject b)
    {
        Debug.Log(a.name + " " + b.name);

        AssignGameObject(a, b);

        for (int i = 0; i < a.transform.childCount; i++)
        {
            var c = a.transform.GetChild(i);
            var d = b.transform.GetChild(i);
            Debug.Log("     " + c.name + " " + d.name);

            AssignGameObject(c.gameObject, d.gameObject);
            if (c.childCount > 0)
                AssignRecursive(c.gameObject, d.gameObject);

        }
    }


    void AssignGameObject(GameObject assignee, GameObject assignable)
    {

        var comp = assignee.GetComponent(scriptType);
        if (comp)
            comp.GetType().GetField(VariableName).SetValue(assignee.GetComponent(scriptType), assignable);
        else
            Debug.LogWarning("Gameobject " + assignee.name + " does not have component of type " + scriptType);
    }
}
#endif