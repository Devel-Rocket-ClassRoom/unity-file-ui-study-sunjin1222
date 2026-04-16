using UnityEngine;

public class CryptoTest1 : MonoBehaviour
{
  private byte[] ecom;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            string plaintest = "Hello~ ASC!";
            ecom=CryptoUtil.Encrypt(plaintest);
            string base64 = System.Convert.ToBase64String(ecom);
            Debug.Log(base64);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            string plaintest = CryptoUtil.Decrypt(ecom);
            Debug.Log(plaintest);
        }
    }
}
