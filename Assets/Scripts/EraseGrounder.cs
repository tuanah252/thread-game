using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseGrounder : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objectPrefab;

    // Vị trí mà đối tượng được tạo ra
    private Vector3 spawnPosition;

    // Kiểm tra xem chuột đã được giữ
    private bool isDragging = false;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            objectPrefab.SetActive(true);
            // Lấy vị trí chuột khi được giữ
            spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = 0;

            // Đặt isDragging thành true
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            // Tạo đối tượng khi chuột được thả
            if (isDragging)
            {
                Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
                isDragging = false;
            }

            objectPrefab.SetActive(false);
        }


        if (isDragging)
        {
            // Lấy vị trí chuột hiện tại
            Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentMousePosition.z = 0;

            // Tính toán khoảng cách giữa vị trí chuột hiện tại và vị trí chuột ban đầu
            float distance = Vector3.Distance(spawnPosition, currentMousePosition);

            // Nếu khoảng cách lớn hơn 0.1, tạo đối tượng tạm thời và di chuyển nó theo chuột
            if (distance > 0.1f)
            {
                GameObject newObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
                newObject.transform.SetParent(transform);

                Vector3 direction = (currentMousePosition - spawnPosition).normalized;
                newObject.transform.position += direction * distance;
                Destroy(newObject, 1f);



            }

        }
    }
}
