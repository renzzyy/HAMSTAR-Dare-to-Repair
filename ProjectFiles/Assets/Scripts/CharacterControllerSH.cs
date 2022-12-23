using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterControllerSH : MonoBehaviour
{

    [SerializeField] private float jumpPower = 400f;							
	[Range(0, 1)] [SerializeField] private float crouchSpeed = .36f;			
	[Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;	
	[SerializeField] private bool airControl = false;							
	[SerializeField] private LayerMask groundLayer;							
	[SerializeField] private Transform groundCheck;							
	[SerializeField] private Transform ceilingCheck;							
	[SerializeField] private Collider2D crouchColliderDisable;				

	const float groundRadius = .2f; 
	private bool isGrounded;            
	const float ceilingRadius = .2f; 
	private Rigidbody2D rb;
	private bool isFacingRight = true;  
	private Vector3 velocity = Vector3.zero;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnCrouchEvent;
	private bool m_wasCrouching = false;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		if (OnCrouchEvent == null)
			OnCrouchEvent = new BoolEvent();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = isGrounded;
		isGrounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundRadius, groundLayer);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				isGrounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}

	public void Move(float move, bool crouch, bool jump)
	{
		if (!crouch)
		{
			if (Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, groundLayer))
			{
				crouch = true;
			}
		}

		if (isGrounded || airControl)
		{
			if (crouch)
			{
				if (!m_wasCrouching)
				{
					m_wasCrouching = true;
					OnCrouchEvent.Invoke(true);
				}

				move *= crouchSpeed;

				if (crouchColliderDisable != null)
					crouchColliderDisable.enabled = false;
			} else {
				if (crouchColliderDisable != null)
					crouchColliderDisable.enabled = true;

				if (m_wasCrouching)
				{
					m_wasCrouching = false;
					OnCrouchEvent.Invoke(false);
				}
			}

			Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
			rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);

			if (move > 0 && !isFacingRight)
			{
				Flip();
			}
			else if (move < 0 && isFacingRight)
			{
				Flip();
			}
		}

		if (isGrounded && jump)
		{
			isGrounded = false;
			rb.AddForce(new Vector2(0f, jumpPower));
		}
	}

	private void Flip()
	{
		isFacingRight = !isFacingRight;
		Vector3 localScale = transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}
}

