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
        // NetworkRunnerを生成する
        networkRunner = Instantiate(networkRunnerPrefab);
        // StartGameArgsに渡した設定で、セッションに参加する
        var result = await networkRunner.StartGame(new StartGameArgs
        {
            GameMode = GameMode.Shared,
            SceneManager = networkRunner.GetComponent<NetworkSceneManagerDefault>()
        });

        if (result.Ok)
        {
            Debug.Log("セッション接続成功!");

            // プレイヤー自身のアバターを生成する
            networkRunner.Spawn(playerAvatarPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);

        }
        else
        {
            Debug.Log("セッション接続失敗！");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
