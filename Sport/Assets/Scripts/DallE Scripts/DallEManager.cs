using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Threading.Tasks;

namespace OpenAI
{
    public class DallEManager : MonoBehaviour
    {
        [SerializeField] private Image image;

        private OpenAIApi openai = new OpenAIApi();

        public void DrawCommand(string[] values)
        {
            Debug.Log("DallE Manager: " + "Intent: " + values[0] + " Action type: " + values[2]);

            if(values[2].Contains("Draw"))
            {
                SendImageRequest();
            }
        }

        private async void SendImageRequest()
        {
            image.sprite = null;

            var response = await openai.CreateImage(new CreateImageRequest
            {
                Prompt = "fat orange cat",
                Size = ImageSize.Size256
            });

            if (response.Data != null && response.Data.Count > 0)
            {
                using (var request = new UnityWebRequest(response.Data[0].Url))
                {
                    request.downloadHandler = new DownloadHandlerBuffer();
                    request.SetRequestHeader("Access-Control-Allow-Origin", "*");
                    request.SendWebRequest();

                    while (!request.isDone) await Task.Yield();

                    Texture2D texture = new Texture2D(2, 2);
                    texture.LoadImage(request.downloadHandler.data);
                    var sprite = Sprite.Create(texture, new Rect(0, 0, 256, 256), Vector2.zero, 1f);
                    Debug.Log("burdayiz");
                    image.sprite = sprite;
                }
            }
            else
            {
                Debug.LogWarning("No image was created from this prompt.");
            }
        }
    }
}
