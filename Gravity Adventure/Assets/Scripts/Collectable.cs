using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// enum, this will help to identify each collectable.
public enum CollectableType
{
  healthPotion,
  manaPotion,
  money
}

public class Collectable : MonoBehaviour
{
  public CollectableType type = CollectableType.money;
  private SpriteRenderer sprite;
  private CircleCollider2D itemCollider;
  bool hasBeenCollected = false;
  public int value = 1;
  GameObject player;
  private void Awake()
  {
    sprite = GetComponent<SpriteRenderer>();
    itemCollider = GetComponent<CircleCollider2D>();
  }
  /// <summary>
  /// Start is called on the frame when a script is enabled just before
  /// any of the Update methods is called the first time.
  /// </summary>
  void Start()
  {
    player = GameObject.Find("Player");
  }
  void Show()
  {
    sprite.enabled = true;
    itemCollider.enabled = true;
    hasBeenCollected = false;
  }
  void Hide()
  {
    sprite.enabled = false;
    itemCollider.enabled = false;
  }
  void Collect()
  {
    Hide();
    hasBeenCollected = true;
    switch (this.type)
    {
      case CollectableType.money:
        GameManager.sharedInstance.CollectObject(this);
        break;
      case CollectableType.healthPotion:
        player.GetComponent<PlayerController>().CollectHealth(this.value);
        break;
      case CollectableType.manaPotion:
        player.GetComponent<PlayerController>().CollectMana(this.value);
        break;
    }
  }
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Player")
    {
      Collect();
    }
  }
}
