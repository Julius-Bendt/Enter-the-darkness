using UnityEngine;

public class IdleState : ICrawlerState
{

    Crawler crawler;

    Vector3 pos;

    public void Enter(Crawler c)
    {
        crawler = c;
        crawler.agent.speed = 2;
        crawler.setSight(false);

        pos = c.randomPos();
    }

    public void Execute()
    {
        crawler.move(pos);

        if (crawler.distanceToPlayer <= 10)
        {
            crawler.teleport();
            pos = crawler.randomPos();
        }


        /*
        Debug.Log("distane to next pos: " + Vector3.Distance(crawler.transform.position, crawler.agent.destination));
        Debug.Log("path status: " + crawler.agent.pathStatus);
        */

        if (Vector3.Distance(crawler.transform.position, crawler.agent.destination) <= 2f)
        {
            Debug.Log("[IDLESTATE] new pos");

            Vector3 p = crawler.randomPos();
            
            while(Vector3.Distance(p,pos) <= 30)
            {
                p = crawler.randomPos();
            } 
            pos = crawler.randomPos();
        }
    }

    public void Exit()
    {
    }

    public void OnTriggerEnter(Collider2D o)
    {

    }
}
