using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L5WinController : MonoBehaviour
{
    public GameObject messagePanel;

    private void Start()
    {

    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0; // 停止游戏时间
            messagePanel.SetActive(true); // 显示信息面板
        }
    }
    public void goL6()
    {
        Time.timeScale = 1; // 恢复游戏时间
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // 加载新场景
    }
}
