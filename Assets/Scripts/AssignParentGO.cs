using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
[ExecuteInEditMode]
public class AssignParentGO : MonoBehaviour
{
    public Object Script;
    public string VariableName;
    private System.Type scriptType;
    private System.Type variableType;
    public GameObject Parent;
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
            AssignRecursive(Parent);
        }
    }

    void AssignRecursive(GameObject a)
    {
        //Debug.Log(a.name + " " + b.name);

        for (int i = 0; i < a.transform.childCount; i++)
        {
            var child = a.transform.GetChild(i);
            //var d = b.transform.GetChild(i);
            //Debug.Log(child.name + " " + a.name);

            AssignGameObject(child.gameObject, a);

            if (child.childCount > 0)
                AssignRecursive(child.gameObject);

        }
    }


    void AssignGameObject(GameObject assignee, GameObject assignable)
    {
        var comp = assignee.GetComponent(scriptType);
        if (comp)
        {
            var field = comp.GetType().GetField(VariableName);
            if (field != null)
            {
                
                if (field.FieldType != typeof(GameObject))
                    field.SetValue(assignee.GetComponent(scriptType), assignable.GetComponent(field.FieldType));
                else
                    field.SetValue(assignee.GetComponent(scriptType), assignable);
            }
                
            else
            {
                var propriety = comp.GetType().GetProperty(VariableName);
                if (propriety != null)
                {
                    if (propriety.PropertyType != typeof(GameObject))
                        propriety.SetValue(assignee.GetComponent(scriptType), assignable.GetComponent(propriety.PropertyType));
                    else
                        propriety.SetValue(assignee.GetComponent(scriptType), assignable);
                }
            }

        }
        else
            Debug.LogWarning("Gameobject " + assignee.name + " does not have component of type " + scriptType);
    }
}
#endif