using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageModel 
{
    public MessageModel(string messenger, int status)
    {
        this.messenger = messenger;
        this.status = status;
    }

    // public MessageModel(int status, string notification)
    // {
    //     this.status = status;
    //     this.notification = notification;
    // }

    public  string messenger {get;set;}
    public int status{get;set;}
    public  string notification {get;set;}
    
}
