using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] TMP_Text countText;

	int count = 0;

	void ClickAction() {
		count++;
		UpdateUI();
	}

	void UpdateUI() {
		countText.text = count.ToString();
	}
}