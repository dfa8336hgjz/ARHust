using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Vuforia;

public class TargetNode : MonoBehaviour
{
    [SerializeField] private TargetNode[] neighbor;
    [SerializeField] private Vector3 localPos;
    [SerializeField] private Vector3 localRot;

    private Dictionary<TargetNode, LineRenderer> connectLine;

    void Start()
    {
        connectLine = new Dictionary<TargetNode, LineRenderer>();
    }

    private void Update()
    {
        var components = VuforiaRuntimeUtilities.GetComponentsInChildrenExcluding<Component, DefaultObserverEventHandler>(gameObject);
        foreach (var component in components)
        {
            switch (component)
            {
                case Renderer rendererComponent:
                    rendererComponent.enabled = true;
                    break;
                case Collider colliderComponent:
                    colliderComponent.enabled = true;
                    break;
                case Canvas canvasComponent:
                    canvasComponent.enabled = true;
                    break;
                case RuntimeMeshRenderingBehaviour runtimeMeshComponent:
                    runtimeMeshComponent.enabled = true;
                    break;
            }
        }
    }

    public void transformCoordinate(TargetNode currentNode)
    {
        transform.position = currentNode.transform.position + currentNode.transform.rotation * (this.localPos - currentNode.localPos);
        
        //Quaternion rotationX = Quaternion.Euler(this.localPos.x - currentNode.localPos.x, 0, 0);
        //Quaternion rotationY = Quaternion.Euler(0, this.localPos.y - currentNode.localPos.y, 0);
        //Quaternion rotationZ = Quaternion.Euler(0, 0, this.localPos.z - currentNode.localPos.z);

        //Quaternion totalRotation = rotationX * rotationY * rotationZ;
        //transform.rotation = currentNode.transform.rotation * totalRotation;
    }

    public void drawLine(GameObject prefab)
    {
        foreach(var node in neighbor)
        {
            if (!connectLine.ContainsKey(node))
            {
                GameObject thisObject = Instantiate(prefab);
                LineRenderer line = thisObject.GetComponent<LineRenderer>();
                line.positionCount = 2;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, node.transform.position);

                connectLine.Add(node, line);
            }
            else{
                connectLine[node].gameObject.SetActive(true);
                connectLine[node].SetPosition(0, transform.position);
                connectLine[node].SetPosition(1, node.transform.position);
            }
        }
    }

}
