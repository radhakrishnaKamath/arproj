using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class NotificationFCMScript : MonoBehaviour {

	public InputField DeviceID;
	public Text Notification;
	public Button SendNotifications;
	public GameObject popup;
	string notif_json,data_json;
	//string device1 = "dVSmQ-pxfVI:APA91bFF41KfuFKgT_HjQH4jMOyblsJYKmpB2-fVkKCzRo2JsHicu4onUO8VDoweTErmUa1jV99KWqz7uJpxMCXaNYLD_nN7F7z2pFspq_Ue82ECcsrFm2iTNTMuNY9icajSauK9BkPo";
	//string device2 = "crVMaa1Q4aY:APA91bHJSTT1Ajt0uAavvk76JRHvH8w6j3wBetSDIYtSYL5y51q_B5TTZut8DM-kV3gYTUhqAGKRmQ41ANfdXGK1PzYIDNs9O241Z5BkOOvLIX8Jb7U4Pa6MtNGRCzH-Y4lM6ETurHXI";
	//string device3 = "ch0daiOk-9Y:APA91bF5FvVrf0jrigqLXBRDy6ZakgkQbeoTybHlYFYJU5Hc7Ngl_pl4jJqxr-khYhLIVwmJqTOsnNQzucuHlcWf4_XwsCEIM764s4U5bIGus7hdx01ul3hQYawZpylBrxPD9mwT80UR";
	string [] fcmToken = new string[]{"dVSmQ-pxfVI:APA91bFF41KfuFKgT_HjQH4jMOyblsJYKmpB2-fVkKCzRo2JsHicu4onUO8VDoweTErmUa1jV99KWqz7uJpxMCXaNYLD_nN7F7z2pFspq_Ue82ECcsrFm2iTNTMuNY9icajSauK9BkPo","crVMaa1Q4aY:APA91bHJSTT1Ajt0uAavvk76JRHvH8w6j3wBetSDIYtSYL5y51q_B5TTZut8DM-kV3gYTUhqAGKRmQ41ANfdXGK1PzYIDNs9O241Z5BkOOvLIX8Jb7U4Pa6MtNGRCzH-Y4lM6ETurHXI","ch0daiOk-9Y:APA91bF5FvVrf0jrigqLXBRDy6ZakgkQbeoTybHlYFYJU5Hc7Ngl_pl4jJqxr-khYhLIVwmJqTOsnNQzucuHlcWf4_XwsCEIM764s4U5bIGus7hdx01ul3hQYawZpylBrxPD9mwT80UR"};

	// Use this for initialization
	void Start () {
		Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
		Firebase.Messaging.FirebaseMessaging.Subscribe("/topics/math-team1-prob");
		Firebase.Messaging.FirebaseMessaging.MessageReceived += OnMessageReceived;
		SendNotifications.onClick.AddListener (SendRequest);
	}

	void SendRequest ()
	{
		/*System.Collections.Generic.IDictionary<string, string> iter = new System.Collections.Generic.Dictionary<string,string>();
		iter.Add("hello","world");
		Firebase.Messaging.FirebaseMessage message = new Firebase.Messaging.FirebaseMessage();
		message.To = "82479389392" + "@gcm.googleapis.com";
		message.MessageId = "m-1234565890";
		message.Data = iter;
		message.Data = iter;
		Firebase.Messaging.FirebaseMessaging.Send(message);*/

		//Notif_data notif = new Notif_data ();
		//notif.title = "Invitation to play";
		//notif.body = "You have got an invitation";
		//Data data = new Data ();
		//data.invitation = true;
		//notif_json = JsonUtility.ToJson (notif);
		//data_json = JsonUtility.ToJson (data);
		StartCoroutine(Upload());
		//foreach (String fcm in fcmToken) {
		//	StartCoroutine(Upload());
		//}
		//StartCoroutine(Request());
	}

	IEnumerator Upload() {
        WWWForm form = new WWWForm();
		UnityWebRequest www = UnityWebRequest.Get("http://5cf6283f.ngrok.io/invitation");
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            Debug.Log("Form upload complete!");
            Debug.Log (www.downloadHandler.text);
        }
    }

	/*IEnumerator Request (String fcm)
	{
		WWWForm form = new WWWForm();
		form.AddField("notification",notif_json);
		form.AddField("data",data_json);
		//form.AddField("to",device1); 	

		List<IMultipartFormSection> form = new List<IMultipartFormSection>();
		form.Add( new MultipartFormDataSection("notification",notif_json));
		form.Add( new MultipartFormDataSection("data",data_json));
		form.Add( new MultipartFormDataSection("to",fcm));
		form.Add( new MultipartFormDataSection("Authorization","key=AAAAEzQnmtA:APA91bEVjPiRF_YcpvwirMY9AfZ3qE1uZWP68ETVTtvnZ-MIbHM-3iSPTBC7oKGsUHrXBrgWO7tfp4vVdZi5M-iuQEGU_F0d5zc0rv1xl9uIkSr25WoIOpOrO49P76a4enH3UsNc7m1v"));
		form.Add( new MultipartFormDataSection("Content-Type","application/json"));

		var headers = form.headers;
		headers["Authorization"] = "key=AAAAEzQnmtA:APA91bEVjPiRF_YcpvwirMY9AfZ3qE1uZWP68ETVTtvnZ-MIbHM-3iSPTBC7oKGsUHrXBrgWO7tfp4vVdZi5M-iuQEGU_F0d5zc0rv1xl9uIkSr25WoIOpOrO49P76a4enH3UsNc7m1v";
		headers["Content-Type"] = "application/json";

		UnityWebRequest www = UnityWebRequest.Post("https://fcm.googleapis.com/fcm/send", form);
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError) {
			Notification.text = "" + www.error;
        }
        else {
			Notification.text = "Form upload complete!";
        }
	}*/

	// Update is called once per frame
	void Update () {
		
	}

	public void OnTokenReceived(object sender, Firebase.Messaging.TokenReceivedEventArgs token) {
		UnityEngine.Debug.Log("Received Registration Token: " + token.Token);
		DeviceID.text = "" + token.Token;
	}

	public void OnMessageReceived(object sender, Firebase.Messaging.MessageReceivedEventArgs e) {
		UnityEngine.Debug.Log("Received a new message from: " + e.Message.From);
		Notification.text = "notification received " + e.Message.Data.Count;
		if (e.Message.Data.Count > 0) {
			Notification.text = "notification handling";
			Instantiate(popup);
			foreach (System.Collections.Generic.KeyValuePair<string, string> iter in e.Message.Data) {
				Notification.text = "notification received" + " " + iter.Key + ": " + iter.Value;
			}
		}
	}
}

[Serializable]
class Notif_data
{
    public string title;
    public string body;
}

class Data
{
    public bool invitation;
}
