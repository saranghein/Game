using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorStatusManager : MonoBehaviour
{
	//status구현에는 사용하지 않을 것이고 인벤토리할 때 이용하면 좋을 것 같아 참고용으로 올림
	// csv 파일 변수에 저장

	[System.Serializable]
	public class Status // 상태 정보
	{
		public string status; // 상태 이름(행)
		public int count = 0; // 상태 값
		public int[] counts = new int[30]; // 상태 열
	}

	[System.Serializable]
	public class StatusList
	{
		public Status[] status; // 상태들
	}

	public StatusList statusList = new StatusList();
	void Awake()
	{

		List<Dictionary<string, object>> data_test = CSVReader.Read("status");
		statusList.status = new Status[data_test.Count];
		for (var i = 0; i < data_test.Count; i++)
		{
			statusList.status[i] = new Status();
			statusList.status[i].status = (string)data_test[i]["status"];

			for (var j = 0; j < 30; j++)
			{
				statusList.status[i].counts[j] = (int)data_test[i]["count" + j.ToString()];
			}
		}

	}
}
