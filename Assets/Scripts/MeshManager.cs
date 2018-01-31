using UnityEngine;
using System.Collections.Generic;

public class MeshManager : MonoBehaviour {

    public SkinnedMeshRenderer targetMesh;
    public Dictionary<string, SkinnedMeshRenderer> currentMeshes;

    private void Awake() {

        currentMeshes = new Dictionary<string, SkinnedMeshRenderer>() {
            {"Torso" , null},
            {"Head" , null},
            {"RightHand" , null},
            {"RightArm1" , null},
            {"RightArm2" , null},
            {"RightShoulder", null},
            {"LeftHand" , null},
            {"LeftArm1" , null},
            {"LeftArm2" , null},
            {"LeftShoulder" , null},
            {"RightLeg1", null},
            {"RightLeg2" , null},
            {"LeftLeg1" , null},
            {"LeftLeg2" , null},
            {"Shield" , null},
        };

    }

    public void AddMesh(Item item) {
        SkinnedMeshRenderer newMesh = Instantiate(item.ItemPrefab.GetComponentInChildren<SkinnedMeshRenderer>());
        newMesh.transform.parent = targetMesh.transform;
        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        currentMeshes[item.ItemType] = newMesh;
    }

    public void RemoveMesh(string itemToRemove) {
        if (currentMeshes[itemToRemove] != null)
            Destroy(currentMeshes[itemToRemove].gameObject);
    }

}