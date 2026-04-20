using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] TMP_Text countText;
	[SerializeField] TMP_Text incomeText;
	[SerializeField] StoreUpgrade[] storeUpgrades;
	[SerializeField] int updatesPerSecond = 5;

	[Header("Generator values")]
	[HideInInspector] public float count = 0;
	float lastIncomeValue = 0;
	float nextTimeCheck = 0;

	private void Start() {
		UpdateUI();
	}

	void Update() {
		if (nextTimeCheck < Time.timeSinceLevelLoad) {
		IdleCalculate();
		nextTimeCheck = Time.timeSinceLevelLoad + (1f / updatesPerSecond);
		}
	}

	void IdleCalculate() {
		float sum = 0;
		foreach (var storeUpgrade in storeUpgrades)
		{
			sum += storeUpgrade.CalculateIncomePerSecond();
			storeUpgrade.UpdateUI();
		}
		lastIncomeValue = sum;
		count += sum / updatesPerSecond;
		UpdateUI();
	}

	public void ClickAction() {
		count++;
		UpdateUI();
	}

	public bool PurchaseAction(int cost) {
		if (count >= cost) {
			count -= cost;
			UpdateUI();
			return true;
		}
		return false;
	}

	void UpdateUI() {
		countText.text = Mathf.RoundToInt(count).ToString();
		incomeText.text = lastIncomeValue.ToString() + "/s";
	}
}