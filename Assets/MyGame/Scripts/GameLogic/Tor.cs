using UnityEngine;

public class Tor : MonoBehaviour
{
    #region Privates
    bool audioHasPlayed;
    #endregion

    // Mithilfe eines Enums kann dieses Script sowohl für den Eingang als auch für den Ausgang verwendet werden

    public enum TorArt
    {
        Eingang,
        Ausgang
    }

    #region Fields
    public TorArt tor;
    #endregion

    void Update()
    {
        // Beim Minigame angekommen gibt es kein Zurück mehr, der Eingang schließt sich

        if(tor == TorArt.Eingang && Checkpoints.playerHasReachedMinigameOne)
        {
            transform.GetChild(0).gameObject.SetActive(true);

            // Grinding Sound soll nur einmal abgespielt werden

            if (!audioHasPlayed)
            {
                AudioManager.instance.Play(AudioManager.instance.eingangDoorGrinding);
                audioHasPlayed = true;
            }
        }

        // Sobald das Minigame richtig gelöst wurde, öffnet sich der Ausgang

        if(tor == TorArt.Ausgang && Checkpoints.playerHasDoneMinigameOne)
        {
            transform.GetChild(0).GetComponent<Animator>().SetTrigger("TorNachUnten");

            // Grinding Sound soll nur einmal abgespielt werden

            if (!audioHasPlayed)
            {
                AudioManager.instance.Play(AudioManager.instance.ausgangDoorGrinding);
                audioHasPlayed = true;
            }
        }
    }
}
