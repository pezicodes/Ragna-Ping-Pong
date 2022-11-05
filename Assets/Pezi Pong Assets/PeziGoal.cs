using UnityEngine;
using UnityEngine.UI;

public class PeziGoal : MonoBehaviour
{   
    public Transform ballPos;
    public Transform PeziPos;
    public Transform GiddyPos;

    public Transform SavedBallPos;
    public Transform SavedPeziPos;
    public Transform SavedGiddyPos;
    
  
    public bool isPlayer1Goal;
    public AudioSource goaleffect;

    public PeziBall balll;

    public GameManager gm;
    // Hey Gideon, I linked the game manager

    void Start(){

        
       SavedBallPos.position = ballPos.transform.position;
       SavedPeziPos.position = PeziPos.transform.position;
       SavedGiddyPos.position = GiddyPos.transform.position;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Goal");
        goaleffect.Play();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * 1);

        CountScore();

        Invoke("ResetPositions", 0.8f);

    }



    public void CountScore(){

        if(isPlayer1Goal){

            gm.PeziGoals++;
            gm.PeziScore.text = gm.PeziGoals.ToString();
        }
        else{

            gm.GiddyGoals++;
            gm.GiddyScore.text = gm.GiddyGoals.ToString();
        }

    }

    void ResetPositions(){

        balll.Launch();
        ballPos.transform.position = SavedBallPos.position;
        PeziPos.transform.position = SavedPeziPos.position;
        GiddyPos.transform.position = SavedGiddyPos.position;
    }

    
}
