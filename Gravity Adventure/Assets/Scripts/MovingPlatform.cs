using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
  /// <summary>
  /// Sent when another object enters a trigger collider attached to this
  /// object (2D physics only).
  /// </summary>
  /// <param name="other">The other Collider2D involved in this collision.</param>
  private void OnTriggerEnter2D(Collider2D collision)
  {
      Animator animator = GetComponent<Animator>();
      animator.enabled = true;
  }
}
