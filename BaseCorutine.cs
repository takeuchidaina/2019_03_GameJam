using System.Collections;
using UnityEngine;

public class BaseCorutine  {

	private bool isProcess;

	public bool IsProcess{
		private set { isProcess = value; }
		get { return isProcess; }
	}

	public IEnumerator OnTimeAction(System.Action onStart, System.Action onEnd, float time) {

		isProcess = true;
		onStart();
		yield return new WaitForSeconds(time);
		onEnd();
		isProcess = false;
	}
}
