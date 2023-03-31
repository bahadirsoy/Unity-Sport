using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Threading.Tasks;

namespace OpenAI
{
    public class DallEManager : MonoBehaviour
    {
        [SerializeField] Transform images;
        [SerializeField] Transform player;

        private OpenAIApi openai = new OpenAIApi();

        public void DrawCommand(string[] values)
        {
            
            Debug.Log("DallE Manager: " + "Intent: " + values[0] + " Action type: " + values[1]);
            /*if(values[1] == "")
            {
                SendImageRequest(values[2]);
            } else
            {*/
                SendImageRequest(values[1]);
            //}
        }

        private async void SendImageRequest(string text)
        {
            var response = await openai.CreateImage(new CreateImageRequest
            {
                Prompt = text,
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

                    Image closestImage = null;
                    float distance = 0;
                    int i = 0;
                    foreach(Transform image in images)
                    {
                        if(i == 0)
                        {
                            closestImage = image.gameObject.GetComponent<Image>();
                            distance = Vector3.Distance(player.position, image.position);
                        }
                        else
                        {
                            if(Vector3.Distance(player.position, image.position) < distance)
                            {
                                closestImage = image.gameObject.GetComponent<Image>();
                                distance = Vector3.Distance(player.position, image.position);
                            }
                        }
                        i++;
                    }
                    closestImage.sprite = sprite;

                }
            }
            else
            {
                Debug.LogWarning("No image was created from this prompt.");
            }
        }
    }
}
