using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class MeshManager : MonoBehaviour {

    public SkinnedMeshRenderer targetMesh;
    public Dictionary<string, Dictionary<string, SkinnedMeshRenderer>> currentMeshes;

    private void Awake() {
        currentMeshes = new Dictionary<string, Dictionary<string, SkinnedMeshRenderer>>();
        CreateMeshLayers();
    }

    public void AddMesh(EquippableItem item, string layer) {
        SkinnedMeshRenderer newMesh = Instantiate(item.Prefab.GetComponentInChildren<SkinnedMeshRenderer>());
        newMesh.transform.parent = targetMesh.transform;
        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        currentMeshes[layer][item.EquipmentType] = newMesh;
    }

    public void RemoveMesh(string itemToRemove, string layer) {
        if (currentMeshes[itemToRemove] != null)
            Destroy(currentMeshes[layer][itemToRemove].gameObject);
    }

    private void CreateMeshLayers() {
        Equipment.layers.ToList().ForEach(x => currentMeshes.Add(x, new Dictionary<string, SkinnedMeshRenderer>() {
            {"Torso" , null},
            {"Head" , null},
            {"RightForearm" , null},
            {"RightArm" , null},
            {"RightShoulder", null},
            {"LeftForearm" , null},
            {"LeftArm" , null},
            {"LeftShoulder" , null},
            {"RightLeg", null},
            {"LeftLeg" , null},
            {"Pants" , null},
            {"RightHand" , null},
            {"LeftHand" , null},
            {"Shield",null}
        }));
    }

}