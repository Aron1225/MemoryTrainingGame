using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace MaterialUI
{
	public class ProgressBar : MonoBehaviour
	{
		[Header ("Options")]
		public bool textHasDecimal;
		public bool hasPopup = true;
		public float animationDuration = 0.5f;

		[Header ("References")]
		public RectTransform handle;
		public RectTransform popup;
		public Text popupText;
		public Slider slider;

		float currentPopupScale;
		float currentHandleScale;
		float currentPos;

		bool isSelected;
		int state;

		float animStartTime;
		float animDeltaTime;

		Vector3 tempVec3;

		void Start ()
		{
			slider = gameObject.GetComponent<Slider> ();

			popup.gameObject.GetComponent<Image> ().color = handle.gameObject.GetComponent<Image> ().color;

			UpdateText ();
		}

		void Update ()
		{
			if (state == 1) {
				// Updates the animDeltaTime every frame
				animDeltaTime = Time.realtimeSinceStartup - animStartTime;

				if (animDeltaTime <= animationDuration) {
					//  Animation in progress

					//  Resize handle
					tempVec3 = handle.localScale;
					tempVec3.x = Anim.Quint.Out (currentHandleScale, 1f, animDeltaTime, animationDuration);
					tempVec3.y = tempVec3.x;
					tempVec3.z = tempVec3.x;
					handle.localScale = tempVec3;

					//  If there's a popup, resize it
					if (hasPopup) {
						tempVec3 = popup.localScale;
						tempVec3.x = Anim.Quint.Out (currentPopupScale, 1f, animDeltaTime, animationDuration);
						tempVec3.y = tempVec3.x;
						tempVec3.z = tempVec3.x;
						popup.localScale = tempVec3;

						tempVec3 = popup.localPosition;
						tempVec3.y = Anim.Quint.Out (currentPos, 16f, animDeltaTime, animationDuration);
						popup.localPosition = tempVec3;
					}
				} else {
					//  Animation has completed
					state = 0;
				}
			} else if (state == 2) {
				//  Updates animDeltaTime each frame
				animDeltaTime = Time.realtimeSinceStartup - animStartTime;

				if (animDeltaTime <= animationDuration) {
					//  Animation in progess

					//  Resize handle
					tempVec3 = handle.localScale;
					tempVec3.x = Anim.Quint.Out (currentHandleScale, 0.6f, animDeltaTime, animationDuration);
					tempVec3.y = tempVec3.x;
					tempVec3.z = tempVec3.x;
					handle.localScale = tempVec3;

					//  If there's a popup, resize it
					if (hasPopup) {
						tempVec3 = popup.localScale;
						tempVec3.x = Anim.Quint.Out (currentPopupScale, 0f, animDeltaTime, animationDuration);
						tempVec3.y = tempVec3.x;
						tempVec3.z = tempVec3.x;
						popup.localScale = tempVec3;

						tempVec3 = popup.localPosition;
						tempVec3.y = Anim.Quint.Out (currentPos, 0f, animDeltaTime, animationDuration);
						popup.localPosition = tempVec3;
					}
				} else {
					//  Animation has finished
					state = 0;
				}
			}
		}

		//  Updates the popup text to reflect the slider value
		public void UpdateText ()
		{
			if (textHasDecimal) {
				popupText.text = slider.value.ToString ("0.0") + "%";

			} else {
				string tempText = slider.value.ToString ("0") + "%";
				popupText.text = tempText;
			}

			if (slider.value == 100)
				popupText.text = "Done";
		}


		public void LoadingAnimStart ()
		{
			// Updates the 'current' values to animate from
			currentHandleScale = handle.localScale.x;
			currentPopupScale = popup.localScale.x;
			currentPos = popup.localPosition.y;

			animStartTime = Time.realtimeSinceStartup;

			//  Starts animation
			isSelected = true;
			state = 1;
		}

		public void LoadingAnimFinished ()
		{
			if (isSelected) {
				// Updates the 'current' values to animate from
				currentHandleScale = handle.localScale.x;
				currentPopupScale = popup.localScale.x;
				currentPos = popup.localPosition.y;

				animStartTime = Time.realtimeSinceStartup;

				//  Starts animation
				isSelected = false;
				state = 2;
			}
		}
	}
}

