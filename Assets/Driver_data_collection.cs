using System.Collections;
using UnityEngine;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class Driver_data_collection : MonoBehaviour
{
    public Rigidbody carRigidbody; // Assign this in Unity Inspector
    private static HttpClient client = new HttpClient();
    private string serverUrl = "http://127.0.0.1:8000/submit_speed"; // Replace with your backend API URL

    // Start is called before the first frame update
    void Start()
    {
        if (carRigidbody == null)
        {
            carRigidbody = GetComponent<Rigidbody>(); // Try to get Rigidbody if not assigned
        }
        
        // Start sending speed data
        StartCoroutine(SendSpeedData());
    }

    IEnumerator SendSpeedData()
    {
        while (true)
        {
            if (carRigidbody != null)
            {
                float speed = carRigidbody.velocity.magnitude * 3.6f; // Convert to km/h
                string jsonData = "{\"speed\": " + speed + "}";

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Ensure async operation by calling PostAsync
                PostDataAsync(content);

                // Wait 1 second before sending data again
                yield return new WaitForSeconds(1);
            }
        }
    }

    // This method handles sending data asynchronously
    async void PostDataAsync(StringContent content)
    {
        try
        {
            // Send data asynchronously to the FastAPI server
            HttpResponseMessage response = await client.PostAsync(serverUrl, content);
            
            if (response.IsSuccessStatusCode)
            {
                Debug.Log("Speed submitted successfully!");
            }
            else
            {
                Debug.LogError("Error submitting speed: " + response.StatusCode);
            }
        }
        catch (HttpRequestException e)
        {
            Debug.LogError("Request error: " + e.Message);
        }
    }
}
