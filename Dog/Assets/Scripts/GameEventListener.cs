<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEvent Event;
    public UnityEvent Response;
    private void OnEnable() {
        Event.RegisterListener(this);
    }

    private void OnDisable() {
        Event.DeregisterListener(this);
    }
    
    public void OnEventRaised() {
        Response.Invoke();
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEvent Event;
    public UnityEvent Response;
    private void OnEnable() {
        Event.RegisterListener(this);
    }

    private void OnDisable() {
        Event.DeregisterListener(this);
    }
    
    public void OnEventRaised() {
        Response.Invoke();
    }
}

>>>>>>> parent of 6cad998... Merge pull request #10 from dmc0204/Marcel-Branch
