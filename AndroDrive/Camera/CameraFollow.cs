using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    
	public Controller2D target;
	public float verticalOffset;
	public float lookAheadDstX;
    public float lookAheadDstY;
	public float lookSmoothTimeX;
    public float lookSmoothTimeY;
	public float verticalSmoothTime;
	public Vector2 focusAreaSize;
    public Vector2 ClempAreaX;
    public Vector2 ClempAreaY;
    public Vector2 focusPosition;
    Vector2 tempVect;

	FocusArea focusArea;
  
	float currentLookAheadX;
    float currentLookAheadY;
	float targetLookAheadX;
    float targetLookAheadY;
	float lookAheadDirX;
    float lookAheadDirY;
	float smoothLookVelocityX;
	float smoothVelocityY;
    public float diff;
    public float focusTemp;
	bool lookAheadStopped;
    bool lookAheadStoppedY;
    Vector3 capsuleFix;
    bool level3 = false;

	void Start() {
         if (PlayerPrefs.GetInt("Spacing") == 1)
         {
             level3 = true;
         }
	  if (target !=null)
      {
      focusArea = new FocusArea (target.collider.bounds, focusAreaSize);
      }
      tempVect = focusAreaSize;
      if (level3)
      { 
      capsuleFix = new Vector3 (0,0.89f,0);
      }
      else
      {
        capsuleFix = new Vector3 (0,1.3333f,0);
      }
	}

	void LateUpdate() {
      if (!CameraShake.instance.shaking && target !=null){
        if (tempVect.y != focusAreaSize.y){
          focusArea = new FocusArea (target.collider.bounds, focusAreaSize);
           tempVect = focusAreaSize;
        }
		focusArea.Update (target.collider.bounds);
  
		focusPosition = focusArea.centre + Vector2.up * verticalOffset;

		if (focusArea.velocity.x != 0) {
			lookAheadDirX = Mathf.Sign (focusArea.velocity.x);
			if (Mathf.Sign(target.playerInput.x) == Mathf.Sign(focusArea.velocity.x) && target.playerInput.x != 0) {
				lookAheadStopped = false;
				targetLookAheadX = lookAheadDirX * lookAheadDstX;
			}
			else {
				if (!lookAheadStopped) {
					lookAheadStopped = true;
					targetLookAheadX = currentLookAheadX + (lookAheadDirX * lookAheadDstX - currentLookAheadX)/4f;
				}
			}
		}
       if (focusArea.velocity.y != 0) {
			lookAheadDirY = Mathf.Sign (focusArea.velocity.y);
		    lookAheadStoppedY = false;
		    targetLookAheadY= lookAheadDirY * lookAheadDstY;
       }
			
			else {
				if (!lookAheadStoppedY) {
					lookAheadStoppedY = true;
					targetLookAheadY = currentLookAheadY + (lookAheadDirY * lookAheadDstY - currentLookAheadY)/4f;
				}
			}
		
      

		currentLookAheadX = Mathf.SmoothDamp (currentLookAheadX, targetLookAheadX, ref smoothLookVelocityX, lookSmoothTimeX);
        currentLookAheadY = Mathf.SmoothDamp (currentLookAheadY, targetLookAheadY, ref smoothVelocityY, lookSmoothTimeY);
        
		//focusPosition.y = Mathf.SmoothDamp (transform.position.y, focusPosition.y, ref smoothVelocityY, verticalSmoothTime);
		focusPosition += Vector2.right * currentLookAheadX;
        focusPosition += Vector2.up * currentLookAheadY;
        diff = focusTemp - focusPosition.y;
        focusTemp = focusPosition.y;
        focusPosition = new Vector2 (Mathf.Clamp(focusPosition.x, ClempAreaX.x, ClempAreaX.y), Mathf.Clamp(focusPosition.y, ClempAreaY.x, ClempAreaY.y));
		transform.position = (Vector3)focusPosition + Vector3.forward * -10;
        if (target.tag == "Capsule")
        {
            transform.position = transform.position + capsuleFix;
        }
      }
	}

	void OnDrawGizmos() {
		Gizmos.color = new Color (1, 0, 0, .5f);
		Gizmos.DrawCube (focusArea.centre, focusAreaSize);
	}

	struct FocusArea {
		public Vector2 centre;
		public Vector2 velocity;
		float left,right;
		float top,bottom;


		public FocusArea(Bounds targetBounds, Vector2 size) {
			left = targetBounds.center.x - size.x;
			right = targetBounds.center.x + size.x;
			bottom = targetBounds.min.y;
			top = targetBounds.min.y + (size.y/1.3f);
			velocity = Vector2.zero;
			centre = new Vector2((left+right)/2,(top +bottom)/2);
		}

		public void Update(Bounds targetBounds) {
            if (!CameraShake.instance.shaking){
			float shiftX = 0;
			if (targetBounds.min.x < left) {
				shiftX = targetBounds.min.x - left;
			} else if (targetBounds.max.x > right) {
				shiftX = targetBounds.max.x - right;
			}
			left += shiftX;
			right += shiftX;

			float shiftY = 0;
			if (targetBounds.min.y < bottom) {
				shiftY = targetBounds.min.y - bottom;
			} else if (targetBounds.max.y > top) {
				shiftY = targetBounds.max.y - top;

           
			}
			top += shiftY;
			bottom += shiftY;
			centre = new Vector2((left+right)/2,(top +bottom)/2);
			velocity = new Vector2 (shiftX, shiftY);
		}
        }
	}

}
