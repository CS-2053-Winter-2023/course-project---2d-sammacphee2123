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
            Time.timeScale = 0; // ֹͣ��Ϸʱ��
            messagePanel.SetActive(true); // ��ʾ��Ϣ���
        }
    }
    public void goL6()
    {
        Time.timeScale = 1; // �ָ���Ϸʱ��
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // �����³���
    }
}
