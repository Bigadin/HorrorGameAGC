using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    NetworkVariable<int> num = new NetworkVariable<int>(1, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    void Update()
    {

        if (!IsOwner) return;
        num.Value = Random.Range(1, 20);
        Vector3 moveVec = Vector3.zero;

        if (Input.GetKey(KeyCode.Z)) moveVec.z = 1;
        if (Input.GetKey(KeyCode.S)) moveVec.z = -1;
        if (Input.GetKey(KeyCode.D)) moveVec.x = 1;
        if (Input.GetKey(KeyCode.Q)) moveVec.x = - 1;
        transform.position += moveVec * Time.deltaTime * 10f;

    }
}
