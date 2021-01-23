using UnityEngine;

public interface ICrawlerState
{
    void Execute();
    void Enter(Crawler crawler);
    void Exit();
    void OnTriggerEnter(Collider2D o);
}
