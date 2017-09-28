using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Message : MonoBehaviour
{
	public Text txt_state, txt_attention, txt_meditation, txt_alpha, txt_beta, txt_theta;
//	public Text txt_data;

	BrainWaveJson BrainWaveData;

	//腦波數值
	long attsum = 0, medsum = 0, lowalphasum = 0, highalphasum = 0, lowbetasum = 0, highbetasum = 0,
		lowgammasum = 0, midgammasum = 0, deltasum = 0, thetasum = 0;

	public class BrainWaveJson
	{
		public string attention;
		public string meditation;
		public string highAlpha;
		public string lowAlpha;
		public string highBeta;
		public string lowBeta;
		public string midGamma;
		public string lowGamma;
		public string delta;
		public string theta;
	}

	private void State (string state)
	{
		txt_state.text = "連線狀況：" + state;
	}

	private void Receive (string BrainWaveJsonDate)
	{
		new Thread (() => {

			//使用JsonUtillty的FromJson方法將存文字轉成Json
			BrainWaveData = JsonUtility.FromJson<BrainWaveJson> (BrainWaveJsonDate);

			txt_attention.text = "Attention : " + BrainWaveData.attention;
			txt_meditation.text = "Meditation : " + BrainWaveData.meditation;
			txt_alpha.text = "Alpha : " + (int.Parse (BrainWaveData.highAlpha) + int.Parse (BrainWaveData.lowAlpha)) / 2;
			txt_beta.text = "Beta : " + (int.Parse (BrainWaveData.highBeta) + int.Parse (BrainWaveData.lowBeta)) / 2;
			txt_theta.text = "Theta : " + BrainWaveData.theta;
			//txt_data.text = "highalpha:" + BrainWaveData.highAlpha + "\n"
//			+ "lowalpha:" + BrainWaveData.lowAlpha + "\n"
//			+ "highbeta:" + BrainWaveData.highBeta + "\n"
//			+ "lowbeta:" + BrainWaveData.lowBeta + "\n"
//			+ "midgamma:" + BrainWaveData.midGamma + "\n"
//			+ "lowgamma:" + BrainWaveData.lowGamma + "\n"
//			+ "delta:" + BrainWaveData.delta + "\n"
//			+ "theta:" + BrainWaveData.theta + "\n";
		}).Start ();
	}
}
