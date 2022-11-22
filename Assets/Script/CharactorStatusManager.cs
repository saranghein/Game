using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorStatusManager : MonoBehaviour
{
	//status�������� ������� ���� ���̰� �κ��丮�� �� �̿��ϸ� ���� �� ���� ��������� �ø�
	// csv ���� ������ ����

	[System.Serializable]
	public class Status // ���� ����
	{
		public string status; // ���� �̸�(��)
		public int count = 0; // ���� ��
		public int[] counts = new int[30]; // ���� ��
	}

	[System.Serializable]
	public class StatusList
	{
		public Status[] status; // ���µ�
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
