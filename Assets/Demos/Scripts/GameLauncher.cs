using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class GameLauncher : MonoBehaviour
{

    [SerializeField]
    private NetworkRunner networkRunnerPrefab;
    [SerializeField]
    private NetworkPrefabRef playerAvatarPrefab;

    private NetworkRunner networkRunner;

    private async void Start()
    {
        // NetworkRunner�𐶐�����
        networkRunner = Instantiate(networkRunnerPrefab);
        // StartGameArgs�ɓn�����ݒ�ŁA�Z�b�V�����ɎQ������
        var result = await networkRunner.StartGame(new StartGameArgs
        {
            GameMode = GameMode.Shared,
            SceneManager = networkRunner.GetComponent<NetworkSceneManagerDefault>()
        });

        if (result.Ok)
        {
            Debug.Log("�Z�b�V�����ڑ�����!");

            // �v���C���[���g�̃A�o�^�[�𐶐�����
            networkRunner.Spawn(playerAvatarPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);

        }
        else
        {
            Debug.Log("�Z�b�V�����ڑ����s�I");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
