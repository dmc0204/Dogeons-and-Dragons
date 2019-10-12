using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class GameEvent : ScriptableObject{
    private List<GameEventListener> listeners = new List<GameEventListener>();

    public void Raise() { 
        //loops thorugh list of listeners backwards and calls EventRaised
        //in case something removes itself from list
        for(int i = listeners.Count - 1; i >= 0; i--) {
            listeners[i].OnEventRaised();
        }
    }
    public void RegisterListener(GameEventListener listener) {
        bool doesntHave = listeners.TrueForAll(x => x != listener);
        if(!doesntHave) {
            listeners.Add(listener);
        }
    }
    
    public void DeregisterListener(GameEventListener listener) {
        listeners.Remove(listener);
    }

}