using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMap : MonoBehaviour
{
    [SerializeField] private TargetNode[] nodes;
    [SerializeField] private GameObject prefab;
    private TargetNode currentNode;
    void Start()
    {
        
    }

    void Update()
    {
        if (currentNode != null)
        {
            foreach (var node in nodes)
            {
                if(node != currentNode)
                {
                    node.transformCoordinate(currentNode);
                }

                node.drawLine(prefab);
            }
        }
    }

    public void setCurrentNode(TargetNode node)
    {
        currentNode = node;
    }

    public void resetCurrentNode()
    {
        currentNode = null;
    }
}
