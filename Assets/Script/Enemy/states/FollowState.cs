using UnityEngine;

public class FollowState : ICrawlerState
{

    Crawler crawler;

    float timehandler;

    public void Enter(Crawler c)
    {
        crawler = c;
        crawler.agent.speed = 6f;
        crawler.setSight(false);
    }

    public void Execute()
    {
        crawler.move(crawler.player.position);

        if (playerSight.enemyInSight)
            timehandler += Time.deltaTime;
        else
            timehandler = 0;


        if(timehandler > 0.3f)
        {
            crawler.teleport();
            timehandler = 0;
        }
           
    }

    public void Exit()
    {
    }

    public void OnTriggerEnter(Collider2D o)
    {

    }
}
