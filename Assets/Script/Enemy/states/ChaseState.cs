using UnityEngine;

public class ChaseState : ICrawlerState
{

    Crawler crawler;

    public void Enter(Crawler c)
    {
        crawler = c;
        crawler.agent.speed = 6.5f;
        crawler.setSight(true);
    }

    public void Execute()
    {
        crawler.move(crawler.player.position);
    }

    public void Exit()
    {
    }

    public void OnTriggerEnter(Collider2D o)
    {

    }
}
